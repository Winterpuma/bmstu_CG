using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_08
{
    class Cutter
    {
        private List<PointF> vertex;
        public bool finished_input = false;

        public Cutter()
        {
            vertex = new List<PointF>();
        }

        public void AddVertex(PointF dot)
        {
            vertex.Add(dot);
        }
        public void AddVertex(float x, float y)
        {
            vertex.Add(new PointF(x, y));
        }

        public void Clear()
        {
            vertex.Clear();
            finished_input = false;
        }

        public bool IsEmpty()
        {
            return true ? (vertex.Count == 0) : false;
        }

        // Получение вершины по индексу
        public PointF GetVertex(int index)
        {
            if (index < 0)
                return vertex[vertex.Count + index]; // Вершина с конца
            else 
                return vertex[index % vertex.Count];
        }
      
        // Проверка выпуклости
        public bool IsConvex()
        {
            if (vertex.Count < 3)
                return false;

            Vector a = new Vector(vertex[1], vertex[0]);
            Vector b = new Vector();
            Vector res = new Vector();

            int sign = 0;

            for (int i = 0; i < vertex.Count; i++)
            {
                b = new Vector(GetVertex(i + 1), GetVertex(i));
                Vector.VectorMultiplication(a, b, ref res);

                if (sign == 0)
                    sign = Math.Sign(res.z);
                else if ((sign != Math.Sign(res.z)) && (res.z != 0))
                    return false;

                a = b;
            }

            if (sign == 0)
                return false;

            return true;
        }

        // Алгоритм Кируса-Бека по отсечению отрезка
        public Line CutCyrusBeck(Line l)
        {
            return new Line(); //!
        }



    }
}
