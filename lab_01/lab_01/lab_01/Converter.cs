using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01
{
    class Converter
    {
        private PointF min, max, center;
        private Size panel_s, image_s;
        private double bottom, k_x, k_y;

        public Converter(PointF min, PointF max, Size panel_size, int bottom)
        {
            this.min = min;
            this.max = max;
            panel_s = panel_size;
            image_s = new Size((int)(max.X - min.X + 2 * bottom), (int)(max.Y - min.Y + 2 * bottom));
            center = new PointF(min.X + image_s.Width / 2, min.Y + image_s.Height / 2);

            this.bottom = bottom;
            k_x = (panel_s.Width) / ((double)image_s.Width);
            k_y = (panel_s.Height) / ((double)image_s.Height);
            k_x = k_y = Math.Min(k_y, k_x);
        }

        public float GetY(float y)
        {
            double new_y = y - center.Y;
            double scaled_y = new_y * k_y + bottom * k_y;
            return (float)(panel_s.Height - scaled_y - panel_s.Height / 2);
        }

        public float GetX(float x)
        {
            double new_x = x - center.X;
            double scaled_x = new_x * k_x + bottom * k_x;
            return (float)(scaled_x + panel_s.Width / 2);
        }

        public PointF GetPointF(PointF point)
        {
            return new PointF((int)GetX(point.X), (int)GetY(point.Y));
        }

        public PointF GetPointWithMargin(PointF point)
        {
            return new PointF((int)GetX(point.X) + 5, (int)GetY(point.Y) + 5);
        }
    }
}
