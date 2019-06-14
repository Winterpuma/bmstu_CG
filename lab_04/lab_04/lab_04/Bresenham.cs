using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_04
{
    class Bresenham
    {
        // <0 внутри, >0 вне, =0 на окружности 
        public static int F(int x, int y, int rr)
        {
            return x * x + y * y - rr;
        }

        private static void DiagonalStep(ref int x, ref int y, ref int d)
        {
            x++;
            y--;
            d += 2 * (x - y + 1); // новое расстояние до точки по диагонали
        }
        private static void HorizontalStep(ref int x, ref int d)
        {
            x++;
            d += 2 * x + 1;
        }
        private static void VerticalStep(ref int y, ref int d)
        {
            y--;
            d += -2 * y + 1;
        }

        public static void DrawCircle(Bitmap b, Point center, int radius, Color color)
        {
            int x = 0, y = radius;

            int d = 2 * (1 - radius); // первоначальная ошибка
            int d1, d2;

            double halfR = radius / Math.Sqrt(2);

            for (x = 0; x <= halfR;)
            {
                DrawHack.DrawSymmetric(b, center, x, y, color);
                DrawHack.DrawSymmetric(b, center, y, x, color);

                if (d == 0) // диагональная точка лежит на окружности
                {
                    DiagonalStep(ref x, ref y, ref d);
                }
                else if (d < 0) //диагональная точка внутри окружности
                { 
                    d1 = 2 * d + 2 * y - 1;
                    if (d1 > 0)
                        DiagonalStep(ref x, ref y, ref d);
                    else
                        HorizontalStep(ref x, ref d);
                }
                else // диагональная точка вне окружности
                {
                    d2 = 2 * d - 2 * x - 1;
                    if (d2 < 0)
                        DiagonalStep(ref x, ref y, ref d);
                    else
                        VerticalStep(ref y, ref d);
                }
            } 
        }


        private static void DiagonalStep(ref int x, ref int y, ref int d, int aa, int aa2, int bb, int bb2)
        {
            x++;
            y--;
            d += bb2 * x + bb + aa - aa2 * y; //b*b(2x+1)+a*a(1-2y)
        }
        private static void HorizontalStep(ref int x, ref int d, int bb, int bb2)
        {
            x++;
            d += bb2 * x + bb; // b*b(2x+1)
        }
        private static void VerticalStep(ref int y, ref int d, int aa, int aa2)
        {
            y--;
            d += aa - aa2 * y;  // a*a(1-2y)
        }

        public static void DrawEllipse(Bitmap bitmap, Point center, int a, int b, Color color)
        {
            int aa = a * a;//a^2
            int bb = b * b;//b^2
            int bb2 = 2 * bb;
            int aa2 = 2 * aa;
            int x = 0, y = b;
            //f(x,y)=x^2*b^2+a^2y^2-a^2*b^2=0 из каноического          

            //error=b^2*(x+1)^2 + a^2*(y-1)^2-a^2*b^2=
            int d = aa + bb - aa2 * y;
            int d1, d2;

            while (y >= 0)
            {
                DrawHack.DrawSymmetric(bitmap, center, x, y, color);

                if (d == 0) // диагональная точка лежит на окружности
                {
                    DiagonalStep(ref x, ref y, ref d, aa, aa2, bb, bb2);
                }
                else if (d < 0) //диагональная точка внутри окружности
                {
                    d1 = 2 * d + y * aa2 - aa;
                    if (d1 > 0)
                        DiagonalStep(ref x, ref y, ref d, aa, aa2, bb, bb2);
                    else
                        HorizontalStep(ref x, ref d, bb, bb2);
                }
                else // диагональная точка вне окружности
                {
                    d2 = 2 * d - bb2 * x - bb;
                    if (d2 < 0)
                        DiagonalStep(ref x, ref y, ref d, aa, aa2, bb, bb2);
                    else
                        VerticalStep(ref y, ref d, aa, aa2);
                }
            }
        }
    }
}
