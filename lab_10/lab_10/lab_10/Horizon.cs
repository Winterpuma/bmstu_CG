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

    public struct dot
    {
        public double x;
        public double y;

        public dot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Horizon
    {
        private spacing x, z;
        private double[][] y;

        private int[] horMax, horMin;
        private Func<double, double, double> f;

        private Color color = Color.Red;
        
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

        public void Draw(Graphics g, Pen pen)
        {
            double Xright = -1, Yright = -1, x_left = -1, y_left = -1;
            horMin = new int[(int)g.DpiX];
            horMax = new int[(int)g.DpiX];
            for (int i = 0; i < (int)g.DpiX; i++)
            {
                horMin[i] = (int)g.DpiY;
                horMax[i] = 0;
            }

            // Вычисление ф-и на каждой плоскости z = const 
            // Начиная с ближайшей к наблюдателю
            for (double z_cur = z.min; z_cur < z.max; z_cur += z.step)
            {
                double Xpred = x.min, Ypred = f(x.min, z_cur);
                double x_cur = Xpred, y = Ypred;
                // Видовое преобразование к xпред и yпред, z

                // Обработка левого бокового ребра
                ProcessEdge((int)Xpred, (int)Ypred, ref x_left, ref y_left);
                Visibility Pflag = IsVisible(Xpred, Ypred);
                
                // для каждой точки на кривой лежащей в плоскости z = const
                for (x_cur = x.min; x_cur < x.max; x_cur += x.step)
                {
                    y = f(x_cur, z_cur);
                    // видовое преобразование

                    // проверка видимости текущей точки, заполениние горизонта
                    Visibility Tflag = IsVisible(x_cur, y);

                    if (Tflag == Pflag)
                    {
                        if (Tflag == Visibility.above || Tflag == Visibility.below)
                        {
                            g.DrawLine(pen, (float)Xpred, (float)Ypred, (float)x_cur, (float)y);
                            UpdateHorizons((int)Xpred, (int)Ypred, (int)x_cur, (int)y);
                        }
                    }
                    else // видимость изменилась->вочисляем пересечение, заполняем массив горизонта
                    {
                        double Xi, Yi;
                        dot i;

                        if (Tflag == Visibility.notVisible)
                        {
                            if (Pflag == Visibility.above)
                                i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMax);
                            else
                                i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMin);
                            DrawAndUpdate(g, pen, Xpred, Ypred, i.x, i.y);
                        }
                        else
                        {
                            if (Tflag == Visibility.above)
                            {
                                if (Pflag == Visibility.notVisible)
                                {
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMax);
                                    DrawAndUpdate(g, pen, i.x, i.y, x_cur, y);
                                }
                                else
                                {
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMin);
                                    DrawAndUpdate(g, pen, Xpred, Ypred, i.x, i.y);
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMax);
                                    DrawAndUpdate(g, pen, i.x, i.y, x_cur, y);
                                }
                            }
                            else
                            {
                                if (Pflag == Visibility.notVisible)
                                {
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMax);
                                    DrawAndUpdate(g, pen, i.x, i.y, x_cur, y);
                                }
                                else
                                {
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMax);
                                    DrawAndUpdate(g, pen, Xpred, Ypred, i.x, i.y);
                                    i = GetIntersection((int)Xpred, (int)Ypred, (int)x_cur, (int)y, horMin);
                                    DrawAndUpdate(g, pen, i.x, i.y, x_cur, y);
                                }
                            }
                        }
                    }
                    // Вновь инициализировать
                    Pflag = Tflag;
                    Xpred = x_cur;
                    Ypred = y;
                } // след x
                ProcessEdge(x_cur, y, ref Xright, ref Yright);  // обработка правого концевого ребра
            } //след z
        }

        private void DrawAndUpdate(Graphics g, Pen pen, double x1, double y1, double x2, double y2)
        {
            g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            UpdateHorizons((int)x1, (int)y2, (int)x2, (int)y2);

        }

        // Обработка бокового ребра
        private void ProcessEdge(double x, double y, ref double xEdge, ref double yEdge)
        {
            if (xEdge != -1) // Если не первая кривая
                UpdateHorizons((int)xEdge, (int)yEdge, (int)x, (int)y);
            xEdge = x;
            yEdge = y;
        }

        // Линейная интерполяция для заполения массивов горизонтов между x1 и x2
        private void UpdateHorizons(int x1, int y1, int x2, int y2)
        {
            int y;
            if (x2 - x1 == 0) // вертикальный
            {
                horMax[x2] = Math.Max(horMax[x2], y2);
                horMin[x2] = Math.Min(horMin[x2], y2);
            }
            else
            {
                double slope = (y2 - y1) / (x2 - x1);
                for (int x = x1; x < x2; x++)
                {
                    y = (int) slope * (x - x1) + y1;
                    horMax[x] = Math.Max(horMax[x], y);
                    horMin[x] = Math.Min(horMin[x], y);
                }
            }
        }

        // Проверка видимости точки относительно текущего горизонта
        private Visibility IsVisible(double x, double y)
        {
            if (y < horMax[(int)x] && y > horMin[(int)x])
                return Visibility.notVisible;
            else if (y >= horMax[(int)x])
                return Visibility.above;
            else
                return Visibility.below;
        }

        // Вычисление пересечения текущей кривой с горизонтом
        private dot GetIntersection(int x1, int y1, int x2, int y2, int[] hor)
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

            return new dot(Xi, Yi);
        }
    }
}
