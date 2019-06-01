using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_08
{
    class Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector(float a = 0, float b = 0, float c = 0)
        {
            x = a;
            y = b;
            z = c;
        }

        public Vector(PointF end, PointF start)
        {
            x = end.X - start.X;
            y = end.Y - start.Y;
            z = 0;
        }

        public static void VectorMultiplication(Vector a, Vector b, ref Vector res)
        {
            res.x = a.y * b.z - a.z * b.y;
            res.y = a.z * b.x - a.x * b.z;
            res.z = a.x * b.y - a.y * b.x;
        }

        public static float ScalarMultiplication(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
