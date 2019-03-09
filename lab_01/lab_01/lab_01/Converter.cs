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
        private PointF min, max;
        private Size panel_s;
        private double margin, scale;

        public Converter(PointF min, PointF max, Size panel_size, int margin)
        {
            this.min = min;
            this.max = max;
            this.margin = margin;
            panel_s = panel_size;
            scale = (panel_s.Width - margin*2) / Math.Max(max.X - min.X, max.Y - min.Y);
        }

        public float GetX(float x)
        {
            return (float)((x  - min.X) * scale + margin);
        }

        public float GetY(float y)
        {
            return (float)((max.Y - y) * scale + margin);
        }

        public PointF GetPointF(PointF point)
        {
            return new PointF(GetX(point.X), GetY(point.Y));
        }

        public PointF GetPointWithMargin(PointF point)
        {
            return new PointF((int)GetX(point.X) + 4, (int)GetY(point.Y) + 4);
        }
    }
}
