using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01
{
    class Point
    {
        public float x;
        public float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        // Weight Center of triangle
        public Point GetWeightCenter(Point a, Point b, Point c)
        {
            return new Point((a.x + b.x + c.x) / 3, (a.y + b.y + c.y) / 3);
        }

        public Point GetLineCenter(Point a, Point b)
        {
            return new Point((a.x + b.x) / 2, (a.y + b.y) / 2);
        }
    }
}
