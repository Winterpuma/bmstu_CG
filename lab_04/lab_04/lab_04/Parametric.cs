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
            double t = 0, step = 1 / (float)Math.Max(radiusX, radiusY);
            int x, y;

            for (t = 0; t < Math.PI / 2; t += step)
            {
                x = Convert.ToInt32(radiusX * Math.Cos(t));
                y = Convert.ToInt32(radiusY * Math.Sin(t));

                DrawHack.DrawSymmetric(b, center, x, y, color);
            }
        }
    }
}
