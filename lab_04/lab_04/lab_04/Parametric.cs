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

        public static void DrawEllipse(Bitmap bitmap, Point center, int a, int b, Color color)
        {
            double angle = 0;

            int x = a, y = 0;
            int aa = a * a;
            int bb = b * b;
            
            int y_dot = (int)Math.Round(bb / Math.Sqrt(aa + bb)); // точка перегиба

            // 1 октанта
            double step = 1 / (double)b;
            while (y <= y_dot)
            {
                x = Convert.ToInt32(a * Math.Cos(angle));
                y = Convert.ToInt32(b * Math.Sin(angle));

                DrawHack.DrawSymmetric(bitmap, center, x, y, color);

                angle += step;
            }

            // 2 октанта
            step = 1 / (double)a;
            while (x > 0)
            {
                x = Convert.ToInt32(a * Math.Cos(angle));
                y = Convert.ToInt32(b * Math.Sin(angle));

                DrawHack.DrawSymmetric(bitmap, center, x, y, color);

                angle += step;
            }
        }
    }
}
