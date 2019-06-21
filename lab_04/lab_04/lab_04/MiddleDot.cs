using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_04
{
    class MiddleDot
    {
        public static void DrawCircle(Bitmap bitmap, Point center, int RX, Color color)
        {

            int x = 0;
            int y = RX;
            int p = 1 - RX; // 5/4 значение 
            DrawHack.DrawSymmetric(bitmap, center, x, y, color);
            DrawHack.DrawSymmetric(bitmap, center, y, x, color);

            while (x < y)
            {
                x++;
                if (p < 0) // выбираем правый
                {
                    p += 2 * x + 1;
                }
                else // выбираем диагональный
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                DrawHack.DrawSymmetric(bitmap, center, x, y, color);
                DrawHack.DrawSymmetric(bitmap, center, y, x, color);
            }
        }
        
        public static void DrawEllipse(Bitmap bitmap, Point center, int a, int b, Color color)
        {
            int aa = a * a;
            int bb = b * b;
            int bb2 = 2 * bb;
            int aa2 = 2 * aa;

            int rdel2 = (int)(aa / Math.Sqrt(aa + bb)); //производная для ограничения


            int x = 0;
            int y = b;

            int df = 0;
            int f = (int)(bb - aa * y + 0.25 * aa + 0.5);

            int delta = -aa2 * y;
            for (x = 0; x <= rdel2; x++)
            {
                DrawHack.DrawSymmetric(bitmap, center, x, y, color);

                if (f >= 0)
                {
                    y -= 1;
                    delta += aa2;
                    f += delta;
                }
                df += bb2; ;
                f += df + bb;
            }
            
            delta = bb2 * x;
            f += (int)(-bb * (x + 0.75) - aa * (y - 0.75));
            df = -aa2 * y;
            
            for (; y >= 0; y--)
            {
                DrawHack.DrawSymmetric(bitmap, center, x, y, color);

                if (f < 0)
                {
                    x += 1;
                    delta += bb2;
                    f += delta;
                }
                df += aa2;
                f += df + aa;
            }
        }

    }
}
