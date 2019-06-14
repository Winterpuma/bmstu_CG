using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_04
{
    class Parametric
    {

        public static void DrawCircle(Bitmap b, Point center, int radius, Color color)
        {
            double t = 0, step = 1 / (float)radius;
            int x, y;

            for (t = 0; t < Math.PI / 4; t += step)
            {
                x = Convert.ToInt32(radius * Math.Cos(t));
                y = Convert.ToInt32(radius * Math.Sin(t));

                DrawHack.DrawSymmetric(b, center, x, y, color);
                DrawHack.DrawSymmetric(b, center, y, x, color);
            }
        }

        public static void DrawEllipse(Bitmap b, Point center, int radiusX, int radiusY, Color color)
        {
            int x, y;
            double t = 0;
            double step1 = 1 / (double)Math.Min(radiusX, radiusY);
            double step2 = 1 / (double)Math.Max(radiusX, radiusY);

            int rx2 = radiusX * radiusX; // a^2
            int ry2 = radiusY * radiusY; // b^2
            
            int rdel2 = (int)Math.Round(rx2 / Math.Sqrt(rx2 + ry2));

            for (t = 0, x = 0; x <= rdel2; t += step1)
            {
                x = Convert.ToInt32(radiusX * Math.Cos(t));
                y = Convert.ToInt32(radiusY * Math.Sin(t));

                DrawHack.DrawSymmetric(b, center, x, y, color);
            }

            for (t = 0, x = 0; t <= Math.PI / 2; t += step2)
            {
                x = Convert.ToInt32(radiusX * Math.Cos(t));
                y = Convert.ToInt32(radiusY * Math.Sin(t));

                DrawHack.DrawSymmetric(b, center, x, y, color);
            }
            
        }
    }
}
