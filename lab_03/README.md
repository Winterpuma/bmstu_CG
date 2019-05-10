# Растровая развертка отрезка (разложение в растр)
Процесс определения пикселей, наилучшим образом аппроксимирующих заданный отрезок. 
Простейшие  случаи – горизонтальный, вертикальный и под 45°. В большинстве случаев проявляется лестничный (ступенчатый) эффект.  

**Общие требования:**
1.	Отрезок должен выглядеть как отрезок прямой, начинаться и заканчиваться в заданных точках
2.	Интенсивность (яркость) вдоль отрезка должна быть постоянной. Отрезки, имеющие разные углы наклона, 
    должны быть одной интенсивности. Восприятие человека зависит не только от интенсивности свечения объекта, 
    но и от расстояния между светящимися объектами //чтобы удовлетворить этому требованию, 
    надо **высвечивать точки с переменной интенсивностью от расстояния** – потребует дополнительных вычислений,
без особой нужды не используется
3.	Алгоритмы (особенно нижнего уровня) должны работать быстро

Все алгоритмы имеют пошаговый характер – на очередном шаге высвечиваем пиксель, и производим вычисления, используемые в следующем шаге.

## Цифровой дифференциальный анализатор
Если прямая задана каноническим уравнением (Ax + By + C = 0), то производная (dy/dx) = const. 
Если заданы начальная и конечная точки х1у1 и х2у2, то высчитывается delta(y) или delta(x) и округляетя.
**Если угол наклона <45, то |dX|=1, если > то |dY|=1**

**Недостатки** – работает с целочисленной арифметикой (координаты текущей точки). Работает медленнее за счет операции округления.

## Алгоритм Брезенхема float
[Алгоритм Брезенхэма Википедия](https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%91%D1%80%D0%B5%D0%B7%D0%B5%D0%BD%D1%85%D1%8D%D0%BC%D0%B0)

**Ошибка еi** – величина изменяющаяся на каждом шаге, расстояние между идуальным отрезком и ближайшей точкой растра.  
0 <= ei <= 1, если е < 0.5, то ордината пикселя не меняется,  Если > 0.5, то выбирается верхний пиксель (yi+1 = yi + 1). 
Начальное значение ошибки e = m, где m – тангенс угла наклона. У yид ордината идеального отрезка, в
вещественных а не целых координатах.

Если на очередном шаге мы корректируем значение у, то мы должны также скорректировать и ошибку.

Допускается начальное e=m-0.5 и дальше сравнивать ошибку с нулем, а не с 0.5. (С 0 сравнение идет быстрее)

**Недостатки** - не все переменные являются переменными целого типа (e, m - действительные).

## Алгоритм Брезенхема int
Для перехода к алгоритму работающему только с целыми мы ошибку умножаем на 2dx.

## Устранение ступенчатости (сглаживание)
Используется при отображении ребёр многоугольника, который закрашивается. Идея состоит в сглаживании резких переходов от ступени к ступени. Сглаживание основывается на том, что каждый пиксель высвечивается со своим уровнем интенсивности. Уровень выбирается пропорционально площади части пикселя. **1 пиксель – квадрат с единичной стороной, а не математическая точка.**  

Так как интенсивность **I~Si площади**, то
1) отрезок связан (покрывает) на i шаге с одним пикселем. Обозначим Yi расстояние по вертикали от точки пересечения отрезка с пикселем, до левой нижней границы пикселя. Обозначим тангенс угла наклона отрезка через m, тогда **Si =** Sпр+Sтр = Yi*1 + 1*m/2 = **Yi + m/2**

## Ву
[Алгоритм Ву википдия](https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%92%D1%83)