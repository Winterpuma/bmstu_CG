using System;
using System.Drawing;

namespace lab_04
{
    class Canonical
    {
        // Нарисовать окружность
        public static void DrawCircle(Bitmap b, Point center, int radius, Color color)
        {
            int x = 0, y;
            int rr = radius * radius;
            double halfR = radius / Math.Sqrt(2); 

            for (x = 0; x <= halfR; x++)
            {
                y = Convert.ToInt32(Math.Sqrt(rr - x * x));

                DrawHack.DrawSymmetric(b, center, x, y, color);
                DrawHack.DrawSymmetric(b, center, y, x, color);
            }
        }

        // Нарисовать эллипс
        public static void DrawEllipse(Bitmap b, Point center, int radiusX, int radiusY, Color color)
        {
            // x^2/a^2+y^2/b^2=1

            int rx2 = radiusX * radiusX; // a^2
            int ry2 = radiusY * radiusY; // b^2

            // Производная при y`=-1 , является границей для оптимального рисования
            // y`=-b/a*x/sqrt(a^2-x^2)
            int rdel2 = (int)Math.Round(rx2 / Math.Sqrt(rx2 + ry2));

            int x = 0, y = 0;
            double m = (double)radiusY / radiusX; // b/a
            for (x = 0; x <= rdel2; x++)
            {
                y = (int)Math.Round(Math.Sqrt(rx2 - x * x) * m);  //y=b/a*sqrt(a^2-x^2)
                DrawHack.DrawSymmetric(b, center, x, y, color);
            }

            // Производная , является границей для оптимального рисования
            rdel2 = (int)Math.Round(ry2 / Math.Sqrt(rx2 + ry2));
            m = 1 / m; //переворачиваем m

            for (y = 0; y <= rdel2; y++)
            {
                x = (int)Math.Round(Math.Sqrt(ry2 - y * y) * m); //аналогично выше
                DrawHack.DrawSymmetric(b, center, x, y, color);
            }
        }

    }
}
