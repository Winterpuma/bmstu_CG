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
            int x, y;
            double t = 0;
            //double step1 = 1 / (double)Math.Min(a, b);
            //double step2 = 1 / (double)Math.Max(a, b);
            
            double step1 = 1 / (double)a;
            double step2 = 1 / (double)b;

            int aa = a * a;
            int bb = b * b;

            //int rdel2 = (int)Math.Round(Math.Min(aa, bb) / Math.Sqrt(aa + bb));
            double tSwap = (a / b) * (Math.PI / 4);
            for (t = 0, x = 0; t < tSwap; t += step1)
            {
                x = Convert.ToInt32(a * Math.Cos(t));
                y = Convert.ToInt32(b * Math.Sin(t));

                DrawHack.DrawSymmetric(bitmap, center, x, y, color);
            }

            for (; t <= Math.PI / 2; t += step2)
            {
                x = Convert.ToInt32(a * Math.Cos(t));
                y = Convert.ToInt32(b * Math.Sin(t));

                DrawHack.DrawSymmetric(bitmap, center, x, y, color);
            }
            
        }
    }
}
