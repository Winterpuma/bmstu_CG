# Алгоритм цифрового дифференциального анализатора

#from math import round

def cda_test(ps, pf):
    dx = abs(pf[0] - ps[0])
    dy = abs(pf[1] - ps[1])
    if dx > dy:
        L = dx
    else:
        L = dy
    sx = (pf[0] - ps[0]) / L
    sy = (pf[1] - ps[1]) / L
    x = ps[0]
    y = ps[1]
    while abs(x - pf[0]) > 1 or abs(y - pf[1]) > 1:
        x += sx
        y += sy


def draw_line_cda(canvas, ps, pf, fill):
    dx = abs(pf[0] - ps[0])
    dy = abs(pf[1] - ps[1])

    # for stairs counting
    if dx:
        tg = dy / dx
    else:
        tg = 0

    # steep - max growth
    if dx > dy:
        steep = dx
    else:
        steep = dy
    sx = (pf[0] - ps[0]) / steep # step of x
    sy = (pf[1] - ps[1]) / steep # step of y

    # set line to start
    x = ps[0]
    y = ps[1]
    stairs = []
    st = 1
    while abs(x - pf[0]) > 1 or abs(y - pf[1]) > 1:
        canvas.create_line(round(x), round(y), round(x + 1), round(y + 1), fill=fill)
        if (abs(int(x) - int(x + sx)) >= 1 and tg > 1) or (abs(int(y) - int(y + sy)) >= 1 >= tg):
            stairs.append(st)
            st = 0
        else:
            st += 1
        x += sx
        y += sy
    if st:
        stairs.append(st)
    return stairs
