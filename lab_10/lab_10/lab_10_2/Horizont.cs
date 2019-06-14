using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_10_2
{
    public struct spacing
    {
        public double B;
        public double E;
        public double D;
        public int amount;

        public spacing(double min, double max, double step)
        {
            this.B = min;
            this.E = max;
            this.D = step;
            amount = (int)Math.Ceiling((max - min) / step);
        }
    }

    class Horizont
    {
        Size screenSize;
        int[] DOWN, TOP;
        private Func<double, double, double> f;
        Pen penDraw;

        public Horizont(Pen p, Size s, Func<double, double, double> function)
        {
            DOWN = new int[s.Width];
            TOP = new int[s.Width];
            screenSize = s;
            f = function;
            penDraw = p;
        }

        private void prepareArrays()
        {
            for (int i = 0; i < TOP.Length; i++)
            {
                DOWN[i] = screenSize.Height;
                TOP[i] = 0;
            }
        }
        

        void GetIntersection(int x1, int y1, int x2, int y2, int[] horizon, ref int xi, ref int yi)
        {
            xi = x1;
            yi = y1;
            int delta_x = x2 - x1;
            int delta_y_c = y2 - y1;
            int delta_y_p = horizon[x2] - horizon[x1];
            double m = delta_y_c / (double)(delta_x);
            if (delta_x == 0)
            {
                xi = x2;
                yi = horizon[x2];
            }
            else if (y1 == horizon[x1] && y2 == horizon[x2])
            {
                xi = x1;
                yi = y1;
            }
            else
            {
                xi = x1 - (int)(Math.Round(delta_x * (y1 - horizon[x1]) / (double)(delta_y_c - delta_y_p)));
                yi = (int)(Math.Round((xi - x1) * m + y1));
            }
        }

        
        void horizon(int x1, int y1, int x2, int y2, Graphics painter)
        {
            if (x2 < 0 || x2 > screenSize.Width - 1)
                return;
            if (x1 < 0 || x1 > screenSize.Width - 1)
                return;

            if (x2 < x1)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }
            if (x2 - x1 == 0)
            {
                TOP[x2] = Math.Max(TOP[x2], y2);
                DOWN[x2] = Math.Min(DOWN[x2], y2);
                if (x2 >= 0 && x2 <= screenSize.Width)
                {
                    painter.DrawLine(penDraw, x1, y1, x2, y2);
                }
            }
            else
            {
                int x_prev = x1;
                int y_prev = y1;
                double m = (y2 - y1) / (double)(x2 - x1);
                for (int x = x1; x <= x2; x++)
                {
                    int y = (int)(Math.Round(m * (x - x1) + y1));
                    TOP[x] = Math.Max(TOP[x], y);
                    DOWN[x] = Math.Min(DOWN[x], y);
                    if (x >= 0 && x <= screenSize.Width)
                    {
                        painter.DrawLine(penDraw, x_prev, y_prev, x, y);
                    }
                }
            }
        }

        // Обработка ребер
        void ProcessEdge(ref int x, ref int y, ref int xEdge, ref int yEdge, Graphics painter)
        {
            if (xEdge != -1)
            {
                horizon(xEdge, yEdge, x, y, painter);
            }
            xEdge = x;
            yEdge = y;
        }

        // Проверяет видимость текущей точки
        int Visible(int x, int y)
        {
            if (y < TOP[x] && y > DOWN[x]) return 0;
            if (y >= TOP[x]) return 1;
            return -1;

        }

        // Преобразование координат
        void rotate_x(ref double y, ref double z, ref double tetax)
        {
            tetax = tetax * Math.PI / 180;
            double buf = y;
            y = Math.Cos(tetax) * y - Math.Sin(tetax) * z;
            z = Math.Cos(tetax) * z + Math.Sin(tetax) * buf;
        }
        void rotate_y(ref double x, ref double z, double tetay)
        {
            tetay = tetay * Math.PI / 180;
            double buf = x;
            x = Math.Cos(tetay) * x - Math.Sin(tetay) * z;
            z = Math.Cos(tetay) * z + Math.Sin(tetay) * buf;
        }
        void rotate_z(ref double x, ref double y, double tetaz)
        {
            tetaz = tetaz * Math.PI / 180;
            double buf = x;
            x = Math.Cos(tetaz) * x - Math.Sin(tetaz) * y;
            y = Math.Cos(tetaz) * y + Math.Sin(tetaz) * buf;
        }
        void transform(ref double x, ref double y, ref double z, double tetax, double tetay, double tetaz, ref int res_x, ref int res_y)
        {
            double coef = 35;
            double x_center = screenSize.Width / 2;
            double y_center = screenSize.Width / 2;
            double x_tmp = x;
            double y_tmp = y;
            double z_tmp = z;
            rotate_x(ref y_tmp, ref z_tmp, ref tetax);
            rotate_y(ref x_tmp, ref z_tmp, tetay);
            rotate_z(ref x_tmp, ref y_tmp, tetaz);
            res_x = (int)(Math.Round(x_tmp * coef + x_center));
            res_y = (int)(Math.Round(y_tmp * coef + y_center));
        }

        public void HorizonAlgo(spacing parX, spacing parZ, Graphics painter, double tetax, double tetay, double tetaz)
        {
            prepareArrays();

            int x_left = -1, y_left = -1, x_right = -1, y_right = -1;
            int x_prev = 0, y_prev = 0; 
            for (double z = parZ.E; z >= parZ.B; z -= parZ.D)
            {
                    double y_p = f(parX.B, z);
                    transform(ref parX.B, ref y_p, ref z, tetax, tetay, tetaz, ref x_prev, ref y_prev);
                    ProcessEdge(ref x_prev, ref y_prev, ref x_left, ref y_left, painter);
                    int Pflag = Visible(x_prev, y_prev);
                    for (double x = parX.B; x <= parX.E; x += parX.D)
                    {
                        int x_curr = 0, y_curr = 0;
                        int xi = 0, yi = 0;
                        y_p = f(x, z);
                        transform(ref x, ref y_p, ref z, tetax, tetay, tetaz, ref x_curr, ref y_curr);
                        int Tflag = Visible(x_curr, y_curr);
                        if (Tflag == Pflag)
                        {
                            if (Pflag != 0)
                            {
                                horizon(x_prev, y_prev, x_curr, y_curr, painter);
                            }
                        }
                        else if (Tflag == 0)
                        {
                            if (Pflag == 1)
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, TOP, ref xi, ref yi);
                            }
                            else
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, DOWN, ref xi, ref yi);
                            }
                            horizon(x_prev, y_prev, xi, yi, painter);
                        }
                        else if (Tflag == 1)
                        {
                            if (Pflag == 0)
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, TOP, ref xi, ref yi);
                                horizon(x_prev, y_prev, xi, yi, painter);
                            }
                            else
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, TOP, ref xi, ref yi);
                                horizon(x_prev, y_prev, xi, yi, painter);
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, DOWN, ref xi, ref yi);
                                horizon(xi, yi, x_curr, y_curr, painter);
                            }
                        }
                        else
                        {
                            if (Pflag == 0)
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, DOWN, ref xi, ref yi);
                                horizon(x_prev, y_prev, xi, yi, painter);
                            }
                            else
                            {
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, TOP, ref xi, ref yi);
                                horizon(x_prev, y_prev, xi, yi, painter);
                                GetIntersection(x_prev, y_prev, x_curr, y_curr, DOWN, ref xi, ref yi);
                                horizon(xi, yi, x_curr, y_curr, painter);
                            }
                        }
                        Pflag = Tflag;
                        x_prev = x_curr;
                        y_prev = y_curr;
                    }
                    ProcessEdge(ref x_prev, ref y_prev, ref x_right, ref y_right, painter);

                }
            }
        

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
