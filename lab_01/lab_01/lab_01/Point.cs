using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01
{
    class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Weight Center of triangle
        public Point GetWeightCenter(Point a, Point b, Point c)
        {
            return new Point((a.x + b.x + c.x) / 3, (a.y + b.y + c.y) / 3);
        }
    }
}
