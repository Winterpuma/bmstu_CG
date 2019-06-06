using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_10
{
    public struct spacing
    {
        public double min;
        public double max;
        public double step;
        public int amount;

        public spacing(double min, double max, double step)
        {
            this.min = min;
            this.max = max;
            this.step = step;
            amount = (int)Math.Ceiling((max - min) / step);
        }
    }

    public enum Visibility
    {
        below = -1,
        notVisible,
        above

    }

    public class Horizon
    {
        private spacing x, z;
        private double[][] y;

        private int[] upperHor, lowerHor;
        private Func<double, double, double> f;
        
        public Horizon(Func<double, double, double> f, spacing x, spacing z)
        {
            this.x = x;
            this.z = z;
            this.f = f;
            y = GetArray();
        }

        public double[][] GetArray()
        {
            double[][] res = new double[z.amount][];
            double x_cur = x.min, z_cur = z.min;
            for (int i = 0; i < z.amount; i++)
            {
                res[i] = new double[x.amount];
                for (int j = 0; j < x.amount; j++)
                {
                    res[i][j] = f(x_cur, z_cur);
                    x_cur += x.step;
                }
                z_cur += z.step;
            }
            return res;
        }

        public void Calculate(Bitmap b)
        {
            double Xright = -1, Yright = -1, x_left = -1, y_left = -1;
            int[] horMin = new int[b.Width];
            int[] horMax = new int[b.Width];
            for (int i = 0; i < b.Width; i++)
            {
                horMin[i] = b.Height;
                horMax[i] = 0;
            }

            // Вычисление ф-и на каждой плоскости z = const 
            // Начиная с ближайшей к наблюдателю
            for (double z_cur = z.max; z_cur < z.min; z_cur += z.step)
            {
                double Xpred = x.min, Ypred = f(x.min, z_cur);

                // Видовое преобразование к xпред и yпред, z

                // Обработка левого бокового ребра

                // для каждой точки на кривой
                for (double x_cur = x.min; x_cur < x.max; x_cur += x.step)
                {
                    double y = f(x_cur, z_cur); 
                    // видовое преобразование

                    // проверка видимости текущей точки, заполениние горизонта

                }
            }
        }

        // Линейная интерполяция для заполения массивов горизонтов между x1 и x2
        private void UpdateHorizons(int x1, int y1, int x2, int y2)
        {
            int y;
            if (x2 - x1 == 0) // вертикальный
            {
                upperHor[x2] = Math.Max(upperHor[x2], y2);
                lowerHor[x2] = Math.Min(lowerHor[x2], y2);
            }
            else
            {
                double slope = (y2 - y1) / (x2 - x1);
                for (int x = x1; x < x2; x++)
                {
                    y = (int) slope * (x - x1) + y1;
                    upperHor[x] = Math.Max(upperHor[x], y);
                    lowerHor[x] = Math.Min(lowerHor[x], y);
                }
            }
        }

        // Проверка видимости точки относительно текущего горизонта
        private Visibility IsVisible(int x, int y)
        {
            if (y < upperHor[x] && y > lowerHor[x])
                return Visibility.notVisible;
            else if (y >= upperHor[x])
                return Visibility.above;
            else
                return Visibility.below;
        }

        // Вычисление пересечения текущей кривой с горизонтом
        private PointF GetIntersection(int x1, int y1, int x2, int y2, int[] hor)
        {
            int Xi;
            double Yi;
            int Ysign, Csign;
            double slope;

            if (x2 - x1 == 0) // проверка бесконечности наклона
            {
                Xi = x2;
                Yi = hor[x2];
            }
            else // ищем пересечение
            {
                slope = (y2 - y1) / (x2 - x1);
                Ysign = Math.Sign(y1 + slope - hor[x1 + 1]);
                Csign = Ysign;

                Yi = y1 + slope;
                Xi = x1 + 1;

                while (Csign == Ysign) // Пока не изменится знак разности значений y
                {
                    Yi += slope;
                    Xi++;
                    Csign = Math.Sign(Yi - hor[Xi]);
                }
                
                if (Math.Abs(Yi - slope - hor[Xi - 1]) <=
                    Math.Abs(Yi - hor[Xi - 1]))
                {
                    Yi -= slope;
                    Xi--;
                }
            }

            return new PointF(Xi, (float)Yi);
        }
    }
}
