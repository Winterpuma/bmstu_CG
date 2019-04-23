from calculations import sign

# БР целый
def int_test(ps, pf):
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
    m = 2 * dy
    e = m - dx
    ed = 2 * dx
    x = ps[0]
    y = ps[1]
    while x != pf[0] or y != pf[1]:
        if e >= 0:
            if pr == 1:
                x += sx
            else:
                y += sy
            e -= ed
        if e <= 0:
            if pr == 0:
                x += sx
            else:
                y += sy
        e += m


# Брезенхема с целыми коэффами
def draw_line_brez_int(canvas, ps, pf, fill):
    dx = pf[0] - ps[0]
    dy = pf[1] - ps[1]
    sx = sign(dx)
    sy = sign(dy)
    dy = abs(dy)
    dx = abs(dx)
    if dy >= dx:
        dx, dy = dy, dx
        steep = 1
    else:
        steep = 0
    e = 2 * dy - dx # отличие от вещественного (e = tg - 1 / 2) tg = dy / dx
    x = ps[0]
    y = ps[1]
    stairs = []
    st = 1
    while x != pf[0] or y != pf[1]:
        canvas.create_line(x, y, x + 1, y + 1, fill=fill)
        if e >= 0:
            if steep == 1:
                x += sx
            else:
                y += sy
            stairs.append(st)
            st = 0
            e -= 2 * dx # отличие от вещественного (e -= 1)
        if e <= 0:
            if steep == 0:
                x += sx
            else:
                y += sy
            st += 1
            e += 2 * dy # difference (e += tg)

    if st:
        stairs.append(st)
    return stairs
