# Отсечение регулярным отсекателем
* Может попросить нарисовать все возможные типы отрезков (которые будут проверяться по разному). 
(Горизонтальные; вертикальные; тривиально невидимо; тривиально видимо; частично видимо; частично видимо, в итоге невидимо)
* Как называются такие отрезки -указывает-? (Видимые, невидимые, частично видимые) 
* Всегда ли частично видимые отрезки частично видимы? (Нет, они могут оказаться полностью невидимыми)

* Почему мы можем не проверять горизонтальность отрезка в поиске пересечений (самый конец алгоритма).
(Потому что мы в ту точку программы **не дойдем** т.к. уже было произведено отсечение левой и правой стороной. 
И отрезок уже полностью видим или полностью невидим)
