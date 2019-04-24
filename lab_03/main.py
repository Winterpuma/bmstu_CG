from tkinter import *
from tkinter import messagebox
from math import fabs, ceil, radians, cos, sin, floor
import matplotlib.pyplot as plt
import time

from CDA import cda_test, draw_line_cda
from BresenhamFloat import float_test, draw_line_brez_float
from BresenhamInt import int_test, draw_line_brez_int
from BresenhamSmooth import smoth_test
from Wu import vu_test

from calculations import sign, get_rgb_intensity

canvW, canvH = 800, 650
line_r = 150

def draw_line_brez_smoth(canvas, ps, pf, fill):
    I = 100
    fill = get_rgb_intensity(canvas, fill, bg_color, I)
    dx = pf[0] - ps[0]
    dy = pf[1] - ps[1]
    sx = sign(dx)
    sy = sign(dy)
    dy = abs(dy)
    dx = abs(dx)
    if dy >= dx:
        dx, dy = dy, dx
        steep = 1 #
    else:
        steep = 0 #
    tg = dy / dx * I # тангенс угла наклона (умножаем на инт., чтобы не приходилось умножать внутри цикла
    e = I / 2 # интенсивность для высвечивания начального пикселя
    w = I - tg # пороговое значение
    x = ps[0]
    y = ps[1]
    stairs = []
    st = 1
    while x != pf[0] or y != pf[1]:
        canvas.create_line(x, y, x + 1, y + 1, fill=fill[round(e) - 1])
        if e < w:
            if steep == 0: # dy < dx
                x += sx # -1 if dx < 0, 0 if dx = 0, 1 if dx > 0
            else: # dy >= dx
                y += sy # -1 if dy < 0, 0 if dy = 0, 1 if dy > 0
            st += 1 # stepping
            e += tg
        elif e >= w:
            x += sx
            y += sy
            e -= w
            stairs.append(st)
            st = 0
    if st:
        stairs.append(st)
    return stairs

def draw_line_vu(canvas, ps, pf, fill):
    x1 = ps[0]
    x2 = pf[0]
    y1 = ps[1]
    y2 = pf[1]
    I = 100
    stairs = []
    fills = get_rgb_intensity(canvas, fill, bg_color, I)
    if x1 == x2 and y1 == y2:
        canvas.create_line(x1, y1, x1 + 1, y1 + 1, fill = fills[100])

    steep = abs(y2 - y1) > abs(x2 - x1)

    if steep:
        x1, y1 = y1, x1
        x2, y2 = y2, x2
    if x1 > x2:
        x1, x2 = x2, x1
        y1, y2 = y2, y1

    dx = x2 - x1
    dy = y2 - y1

    if dx == 0:
        tg = 1
    else:
        tg = dy / dx

    # first endpoint
    xend = round(x1)
    yend = y1 + tg * (xend - x1)
    xpx1 = xend
    y = yend + tg

    # second endpoint
    xend = int(x2 + 0.5)
    xpx2 = xend
    st = 0

    # main loop
    if steep:
        for x in range(xpx1, xpx2):
            canvas.create_line(int(y), x + 1, int(y) + 1, x + 2,
                               fill = fills[int((I - 1) * (abs(1 - y + int(y))))])
            canvas.create_line(int(y) + 1, x + 1, int(y) + 2, x + 2,
                               fill = fills[int((I - 1) * (abs(y - int(y))))])

            if (abs(int(x) - int(x + 1)) >= 1 and tg > 1) or \
                    (not 1 > abs(int(y) - int(y + tg)) >= tg):
                stairs.append(st)
                st = 0
            else:
                st += 1
            y += tg
    else:
        for x in range(xpx1, xpx2):
            #print((I - 1)*round(abs(1 - y + floor(y))))
            canvas.create_line(x + 1, int(y), x + 2, int(y) + 1,
                               fill = fills[round((I - 1) * (abs(1 - y + floor(y))))])
            #print((I - 1)*round(abs(y - floor(y))))
            canvas.create_line(x + 1, int(y) + 1, x + 2, int(y) + 2,
                               fill = fills[round((I - 1) * (abs(y - floor(y))))])

            if (abs(int(x) - int(x + 1)) >= 1 and tg > 1) or \
                    (not 1 > abs(int(y) - int(y + tg)) >= tg):
                stairs.append(st)
                st = 0
            else:
                st += 1
            y += tg
    return stairs

# Получение параметров для отрисовки
def draw(test_mode):
    choise = method_list.curselection()
    if len(choise) == 1:
        xs, ys = fxs.get(), fys.get()
        xf, yf = fxf.get(), fyf.get()
        if not xs and not ys:
            messagebox.showwarning('Ошибка ввода',
                                   'Не заданы координаты начала отрезка!')
        elif not xs or not ys:
            messagebox.showwarning('Ошибка ввода',
                                   'Не задана одна из координат начала отрезка!')
        elif not xf and not yf:
            messagebox.showwarning('Ошибка ввода',
                                   'Не заданы координаты конца отрезка!')
        elif not xf or not yf:
            messagebox.showwarning('Ошибка ввода',
                                   'Не задана одна из координат конца отрезка!')
        else:
            #try:
                xs, ys = round(float(xs)), round(float(ys))
                xf, yf = round(float(xf)), round(float(yf))
                if xs != xf or ys != yf:
                    if not test_mode:
                        if choise[0] == 5:
                            canvas.create_line([xs, ys], [xf, yf], fill=line_color)
                        else:
                            funcs[choise[0]](canvas, [xs, ys], [xf, yf], fill=line_color)
                    else:
                        angle = fangle.get()
                        if angle:
                            try:
                                angle = int(angle)
                            except:
                                messagebox.showwarning('Ошибка ввода',
                                                      'Введено нечисловое значение для шага анализа!')
                            if angle:
                                test(1, choise[0], funcs[choise[0]], angle, [xs, ys], [xf, yf])
                            else:
                                messagebox.showwarning('Ошибка ввода',
                                                           'Задано нулевое значение для угла поворота!')

                        else:
                            messagebox.showwarning('Ошибка ввода',
                                                   'Не задано значение для шага анализа!')
                else:
                    messagebox.showwarning('Ошибка ввода',
                                           'Начало и конец отрезка совпадают!')
            #except:
                #messagebox.showwarning('Ошибка ввода',
                #                       'Нечисловое значение для параметров отрезка!')
    elif not len(choise):
        messagebox.showwarning('Ошибка ввода',
                               'Не выбран метод построения отрезка!')
    else:
        messagebox.showwarning('Ошибка ввода',
                               'Выбрано более одного метода простроения отрезка!')


# Получение параметров для анализа
def analyze(mode):
    #try:
        length = len_line.get()
        if length:
            length = int(length)
        else:
            length = 100
        if not mode:
            time_bar(length)
        else:
            ind = method_list.curselection()
            if ind:
                if ind[-1] != 5:
                    smoth_analyze(ind, length)
                else:
                    messagebox.showwarning('Предупреждение',
                                           'Стандартный метод не может '
                                           'быть проанализирован на ступенчатость!')
            else:
                messagebox.showwarning('Предупреждение',
                                       'Не выбрано ни одного'
                                       'метода построения отрезка!')
    #except:
     #   messagebox.showwarning('Предупреждение',
    #                           'Введено нечисловое значение для длины отрезка!')


# замер времени
def test(flag, ind, method, angle, pb, pe):
    global line_color
    total = 0
    steps = int(360 // angle)
    for i in range(steps):
        cur1 = time.time()
        if flag == 0:
            #method(pb, pe)
            method(canvas, pb, pe, fill=bg_color)#line_color)
        else:
            method(canvas, pb, pe, fill=line_color)
        cur2 = time.time()
        turn_point(radians(angle), pe, pb)
        total += cur2 - cur1
    return total / steps


# гистограмма времени
def time_bar(length):
    close_plt()
    plt.figure(2, figsize=(9, 7))
    times = []
    angle = 1
    pb = [center[0], center[1]]
    pe = [center[0] + 100, center[1]]
    for i in range(5):
#        times.append(test(0, i, test_funcs[i], angle, pb, pe))
        times.append(test(0, i, funcs[i], angle, pb, pe))
    clean()
    Y = range(len(times))
    L = ('Digital\ndifferential\nanalyzer', 'Bresenham\n(real coeffs)',
         'Bresenham\n(int coeffs)', 'Bresenham\n(smooth)', 'Wu')
    plt.bar(Y, times, align='center')
    plt.xticks(Y, L)
    plt.ylabel("Work time in sec. (line len. " + str(length) + ")")
    plt.show()

# Поворот точки для сравнения ступенчатости
def turn_point(angle, p, center):
    x = p[0]
    p[0] = round(center[0] + (x - center[0]) * cos(angle) + (p[1] - center[1]) * sin(angle))
    p[1] = round(center[1] - (x - center[0]) * sin(angle) + (p[1] - center[1]) * cos(angle))

# Анализ ступечатости
def smoth_analyze(methods, length):
    close_plt()
    names = ('Digital\ndifferential\nanalyzer', 'Bresenham\n(real coeffs)',
             'Bresenham\n(int coeffs)', 'Bresenham\n(smooth)', 'Wu')
    plt.figure(1)
    plt.title("Stepping analysis")
    plt.xlabel("Angle")
    plt.ylabel("Number of steps(line length " + str(length) + ")")
    plt.grid(True)
    plt.legend(loc='best')

    for i in methods:
        max_len = []
        nums = []
        angles = []
        angle = 0
        step = 2
        pb = [center[0], center[1]]
        pe = [center[0] + length, center[1]]

        for j in range(90 // step):
            stairs = funcs[i](canvas, pb, pe, line_color)
            turn_point(radians(step), pe, pb)
            if stairs:
                max_len.append(max(stairs))
            else:
                max_len.append(0)
            nums.append(len(stairs))
            angles.append(angle)
            angle += step
        clean()
        plt.figure(1)
        plt.plot(angles, nums, label=names[i])
        plt.legend()
    plt.show()

# Оси координат
def draw_axes():
    return
    color = 'gray'
    canvas.create_line(0, 2, canvW, 2, fill="darkred", arrow=LAST)
    canvas.create_line(2, 0, 2, canvH, fill="darkred", arrow=LAST)
    for i in range(50, canvW, 50):
        canvas.create_text(i, 10, text=str(abs(i)), fill=color)
        canvas.create_line(i, 0, i, 5, fill=color)

    for i in range(50, canvH, 50):
        canvas.create_text(15, i, text=str(abs(i)), fill=color)
        canvas.create_line(0, i, 5, i, fill=color)

# очистка канваса
def clean():
    canvas.delete("all")
    draw_axes()

# Справка
def show_info():
    messagebox.showinfo('Информация',
                        'С помощью данной программы можно построить отрезки пятью способами:\n'
                        '1) методом цифрового дифференциального анализатора;\n'
                        '2) методом Брезенхема с действитльными коэфициентами;\n'
                        '3) методом Брезенхема с целыми коэфициентами;\n'
                        '4) методом Брезенхема со сглаживанием;\n'
                        '5) методом Ву;\n'
                        '6) стандартым методом.\n'
                        '\nДля построения отрезка необходимо задать его начало\n'
                        'и конец и выбрать метод построения из списка предложенных.\n'
                        '\nДля визуального анализа (построения пучка отрезков)\n'
                        'необходимо задать начало и конец,\n'
                        'выбрать метод для анализа,\n'
                        'а также угол поворота отрезка.\n'
                        '\nДля анализа ступенчатости можно выбрать сразу несколько методов.\n'
                        'Чтобы это сделать, зажмите SHIFT при выборе.\n'
                        'Анализ ступенчатости и времени исполнения приводится\n'
                        'в виде графиков pyplot.\n'
                        'Введите длину отрезка, если хотите сделать анализ программы\n'
                        'при построении отрезков определенной длины.')

# Список методов прорисовки отрезка
def fill_list(lst):
    lst.insert(END, "Цифровой дифференциальный анализатор")
    lst.insert(END, "Брезенхем (float)")
    lst.insert(END, "Брезенхем (int)")
    lst.insert(END, "Брезенхем с устранением ступенчатости")
    lst.insert(END, "Ву")
    lst.insert(END, "Стандартный")


def set_bgcolor(color):
    global bg_color
    bg_color = color
    canvas.configure(bg=bg_color)


def set_linecolor(color):
    global line_color
    line_color = color
    lb_lcolor.configure(bg=line_color)

def close_plt():
    plt.figure(1)
    plt.close()
    plt.figure(2)
    plt.close()

def close_all():
    if messagebox.askyesno("Выход", "Вы действительно хотите завершить программу?"):
        close_plt()
        root.destroy()

root = Tk()
root.geometry('1120x660')
root.resizable(0, 0)
root.title('Лабораторная работа №3')
color_menu = "#7586c5"

x_menu = 810
w_menu = 300

# коэффициенты для линии
coords_frame = Frame(root, bg=color_menu, height=200, width=w_menu)
coords_frame.place(x=x_menu, y=110)

# угол
angle_frame = Frame(root, bg=color_menu, height=200, width=w_menu)
angle_frame.place(x=x_menu, y=210)


# выбор цвета
color_frame = Frame(root, bg=color_menu, height=150, width=w_menu)
color_frame.place(x=x_menu, y=300)

# сравнение
comparison_frame = Frame(root, bg=color_menu, height=200, width=w_menu)
comparison_frame.place(x=x_menu, y=450)

# очистить, справка
menu_frame = Frame(root, bg=color_menu, height=50, width=w_menu)
menu_frame.place(x=x_menu, y=600)

canv = Canvas(root, width=canvW, height=canvH, bg='white')
canvas = canv
canvas_test = canv
canv.place(x=0, y=000)
center = (375, 200)

# Список Алгоритмов
method_list = Listbox(root, selectmode=EXTENDED)
method_list.place(x=810, y=10, width=w_menu, height=100)
fill_list(method_list)
funcs = (draw_line_cda, draw_line_brez_float, draw_line_brez_int,
         draw_line_brez_smoth, draw_line_vu, canvas.create_line)
test_funcs = (cda_test, float_test, int_test, smoth_test, vu_test)

lb1 = Label(coords_frame, bg=color_menu, text='Начало линии:')
lb2 = Label(coords_frame, bg=color_menu, text='Конец линии:')
lb1.place(x=0, y=5)
lb2.place(x=0, y=50)

lbx1 = Label(coords_frame, bg=color_menu, text='X:')
lby1 = Label(coords_frame, bg=color_menu, text='Y:')
lbx2 = Label(coords_frame, bg=color_menu, text='X:')
lby2 = Label(coords_frame, bg=color_menu, text='Y:')
lbx1.place(x=5, y=25)
lby1.place(x=90, y=25)
lbx2.place(x=5, y=75)
lby2.place(x=90, y=75)

fxs = Entry(coords_frame, bg="white")
fys = Entry(coords_frame, bg="white")
fxf = Entry(coords_frame, bg="white")
fyf = Entry(coords_frame, bg="white")
fxs.place(x=30, y=25, width=35)
fys.place(x=115, y=25, width=35)
fxf.place(x=30, y=75, width=35)
fyf.place(x=115, y=75, width=35)
fxs.insert(0, str(canvW/2))
fys.insert(0, str(canvH/2))
fxf.insert(0, str(canvW/2 + line_r))
fyf.insert(0, str(canvH/2 + line_r))

btn_draw = Button(coords_frame, text=u"Построить", command=lambda: draw(0), width=140, height=25)
btn_draw.place(x=200, y=35, width=80, height=30)

lb_angle = Label(angle_frame, bg=color_menu, text="Угол поворота\n(в градусах):")
lb_angle.place(x=2, y=2)

fangle = Entry(angle_frame, bg="white")
fangle.place(x=30, y=40, width=25)
fangle.insert(0, "15")

btn_viz = Button(angle_frame, text=u"Солнышко", command=lambda: draw(1))
btn_viz.place(x=120, y=30, width=120, height=25)

lb_len = Label(comparison_frame, bg=color_menu, text="Длина линии\n(по умолчанию 100):")
lb_len.place(x=2, y=2)
len_line = Entry(comparison_frame, bg="white")
len_line.place(x=40, y=40, width=40)
btn_time = Button(comparison_frame, text=u"Сравнение времени\nпостроения", command=lambda: analyze(0))
btn_time.place(x=3, y=70, width=140, height=40)
btn_smoth = Button(comparison_frame, text=u"Сравнение\nступенчатости", command=lambda: analyze(1))
btn_smoth.place(x=150, y=70, width=140, height=40)

btn_clean = Button(menu_frame, text=u"Очистить экран", command=clean)
btn_clean.place(x=25, y=0, width=95)
btn_help = Button(menu_frame, text=u"Справка", command=show_info)
btn_help.place(x=170, y=0, width=95)
#btn_exit = Button(menu_frame, text=u"Выход", command=close_all)
#btn_exit.place(x=60, y=0, width=95)


### --------------- выбор цветов ---------------
line_color = 'black'
bg_color = 'white'

size = 15
white_line = Button(color_frame, bg="white", activebackground="white",
                    command=lambda: set_linecolor('white'))
white_line.place(x=15, y=30, height=size, width=size)
black_line = Button(color_frame, bg="yellow", activebackground="black",
                    command=lambda: set_linecolor("yellow"))
black_line.place(x=30, y=30, height=size, width=size)
red_line = Button(color_frame, bg="orange", activebackground="orange",
                  command=lambda: set_linecolor("orange"))
red_line.place(x=45, y=30, height=size, width=size)
orange_line = Button(color_frame, bg="red", activebackground="red",
                     command=lambda: set_linecolor("red"))
orange_line.place(x=60, y=30, height=size, width=size)
yellow_line = Button(color_frame, bg="purple", activebackground="purple",
                     command=lambda: set_linecolor("purple"))
yellow_line.place(x=75, y=30, height=size, width=size)
green_line = Button(color_frame, bg="darkblue", activebackground="darkblue",
                    command=lambda: set_linecolor("darkblue"))
green_line.place(x=90, y=30, height=size, width=size)
doger_line = Button(color_frame, bg="darkgreen", activebackground="darkgreen",
                    command=lambda: set_linecolor("darkgreen"))
doger_line.place(x=105, y=30, height=size, width=size)
blue_line = Button(color_frame, bg="black", activebackground="black",
                   command=lambda: set_linecolor("black"))
blue_line.place(x=120, y=30, height=size, width=size)

white_bg = Button(color_frame, bg="white", activebackground="white",
                  command=lambda: set_bgcolor("white"))
white_bg.place(x=15, y=110, height=size, width=size)
black_bg = Button(color_frame, bg="yellow", activebackground="yellow",
                  command=lambda: set_bgcolor("yellow"))
black_bg.place(x=30, y=110, height=size, width=size)
red_bg = Button(color_frame, bg="orange", activebackground="orange",
                command=lambda: set_bgcolor("orange"))
red_bg.place(x=45, y=110, height=size, width=size)
orange_bg = Button(color_frame, bg="red", activebackground="red",
                   command=lambda: set_bgcolor("red"))
orange_bg.place(x=60, y=110, height=size, width=size)
yellow_bg = Button(color_frame, bg="purple", activebackground="purple",
                   command=lambda: set_bgcolor("purple"))
yellow_bg.place(x=75, y=110, height=size, width=size)
green_bg = Button(color_frame, bg="darkblue", activebackground="darkblue",
                  command=lambda: set_bgcolor("darkblue"))
green_bg.place(x=90, y=110, height=size, width=size)
dodger_bg = Button(color_frame, bg="darkgreen", activebackground="darkgreen",
                   command=lambda: set_bgcolor("darkgreen"))
dodger_bg.place(x=105, y=110, height=size, width=size)
blue_bg = Button(color_frame, bg="black", activebackground="black",
                 command=lambda: set_bgcolor("black"))
blue_bg.place(x=120, y=110, height=size, width=size)

lb_line = Label(color_frame, bg=color_menu, text='Цвет линии (текущий:       ): ')
lb_line.place(x=2, y=5)
lb_lcolor = Label(color_frame, bg=line_color)
lb_lcolor.place(x=135, y=9, width=12, height=12)
lb_bg = Label(color_frame, bg=color_menu, text='Цвет фона: ')
lb_bg.place(x=2, y=80)

draw_axes()
root.mainloop()
