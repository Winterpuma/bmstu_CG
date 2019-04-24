from calculations import sign

# БР вещественный для теста
def float_test(ps, pf):
    dx = pf[0] - ps[0]
    dy = pf[1] - ps[1]
    sx = sign(dx)
    sy = sign(dy)
    dy = abs(dy)
    dx = abs(dx)
    if dy >= dx:
        dx, dy = dy, dx
        pr = 1
    else:
        pr = 0
    m = dy / dx
    e = m - 1 / 2
    x = ps[0]
    y = ps[1]
    while x != pf[0] or y != pf[1]:
        if e >= 0:
            if pr == 1:
                x += sx
            else:
                y += sy
            e -= 1
        if e <= 0:
            if pr == 0:
                x += sx
            else:
                y += sy
        e += m


# Брезенхема с действительными коэффами
def draw_line_brez_float(canvas, ps, pf, fill):
    dx = pf[0] - ps[0]
    dy = pf[1] - ps[1]
    sx = sign(dx)
    sy = sign(dy)
    dy = abs(dy)
    dx = abs(dx)
    
    if dy >= dx:
        dx, dy = dy, dx
        steep = 1 # шагаем по y
    else:
        steep = 0
        
    tg = dy / dx # tангенс угла наклона
    e = tg - 1 / 2 # начальное значение ошибки
    x = ps[0] # начальный икс
    y = ps[1] # начальный игрек
    stairs = []
    st = 1
    while x != pf[0] or y != pf[1]:
        canvas.create_line(x, y, x + 1, y + 1, fill=fill)
        # выбираем пиксель
        if e >= 0:
            if steep == 1: # dy >= dx
                x += sx
            else: # dy < dx
                y += sy
            e -= 1 # отличие от целого
            stairs.append(st)
            st = 0
        if e <= 0:
            if steep == 0: # dy < dx
                x += sx
            else: # dy >= dx
                y += sy
            st += 1
            e += tg # отличие от целого

    if st:
        stairs.append(st)
    return stairs
