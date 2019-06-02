using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_09
{
    class Segment
    {
        public PointF start;
        public PointF end;

        public Segment(PointF a, PointF b)
        {
            start = a;
            end = b;
        }

        private double GetCoordX(double t)
        {
            return start.X + (end.X - start.X) * t;
        }

        private double GetCoordY(double t)
        {
            return start.Y + (end.Y - start.Y) * t;
        }

        // Получение точки на отрезке по параметру t
        public PointF GetDot(double t)
        {
            return new PointF((float)GetCoordX(t), (float)GetCoordY(t));
        }

        // Проверяем видимость точки относительно отрезка
        public int IsDotVisible(PointF dot)
        {
            // Порядок обхода!!?
            // Смотрим знак векторного произведения
            return Math.Sign((dot.X - start.X) * (end.Y - start.Y) -
                (dot.Y - start.Y) * (end.X - start.X));
        }

        // Определяем факт пересечения двух отрезков
        public static bool IsIntersecting(Segment a, Segment b)
        {
            int vis1 = b.IsDotVisible(a.start);
            int vis2 = b.IsDotVisible(a.end);

            // Ребро многоугольника, которое начинается или заканчивается на стороне
            // окна, не пересекается с ней. Эта точка должна быть занесена в результат ранее
            if ((vis1 > 0 && vis2 < 0) || (vis1 < 0 && vis2 > 0))
                return true;
            return false;
        }
    }
}
