using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_07
{
    class Cutter
    {
        public int left = 0;
        public int right = 0;
        public int up = 0;
        public int down = 0;

        // Получение кода точки относительно отсекателя
        public int GetPositioning(PointF p)
        {
            int sum = 0;

            if (p.X < left)
                sum += 8;
            if (p.X > right)
                sum += 4;
            if (p.Y > down)
                sum += 2;
            if (p.Y < up)
                sum += 1;

            return sum;
        }

        // Проверка видимости отрезка относительно отсекателя
        public int IsVisible(PointF a, PointF b)
        {
            int SumA = GetPositioning(a);
            int SumB = GetPositioning(b);

            int visibility = -1; // не ясно

            if (SumA == 0 && SumB == 0)
                visibility = 1; // полностью видимо
            else
            {
                // проверка тривиальной невидимости отрезка
                if ((SumA & SumB) != 0)
                    visibility = 0;
            }
            return visibility;
        }

        // Индексатор
        public int this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0:
                        return left;
                    case 1:
                        return right;
                    case 2:
                        return down;
                    case 3:
                        return up;
                    default:
                        return -1;
                }
            }
        }
    }
}
