using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_04
{
    class DrawHack
    {
        // Отобразить симметрично точку относительно центра
        public static void DrawSymmetric(Bitmap b, Point center, Point diff, Color color)
        {
            b.SetPixel(center.X + diff.X, center.Y + diff.Y, color);
            b.SetPixel(center.X - diff.X, center.Y - diff.Y, color);
            b.SetPixel(center.X + diff.X, center.Y - diff.Y, color);
            b.SetPixel(center.X - diff.X, center.Y + diff.Y, color);
        }

        public static void DrawSymmetric(Bitmap b, Point center, int diffX, int diffY, Color color)
        {
            b.SetPixel(center.X + diffX, center.Y + diffY, color);
            b.SetPixel(center.X - diffX, center.Y - diffY, color);
            b.SetPixel(center.X + diffX, center.Y - diffY, color);
            b.SetPixel(center.X - diffX, center.Y + diffY, color);
        }
    }
}
