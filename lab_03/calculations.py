# Знак числа
def sign(x):
    if x < 0:
        return -1
    elif x > 0:
        return 1
    return 0


# Массив цветов одного оттенка разной интенсивности
def get_rgb_intensity(canvas, color, bg_color, intensity):
    grad = []
    (r1, g1, b1) = canvas.winfo_rgb(color) # разложение цвета линни на составляющие ргб
    (r2, g2, b2) = canvas.winfo_rgb(bg_color) # разложение цвета фона на составляющие ргб
    r_ratio = float(r2 - r1) / intensity # получение шага интенсивности
    g_ratio = float(g2 - g1) / intensity
    b_ratio = float(b2 - b1) / intensity
    for i in range(intensity):
        nr = int(r1 + (r_ratio * i)) # заполнение массива разными оттенками
        ng = int(g1 + (g_ratio * i))
        nb = int(b1 + (b_ratio * i))
        grad.append("#%4.4x%4.4x%4.4x" % (nr, ng, nb))
    grad.reverse()
    return grad
