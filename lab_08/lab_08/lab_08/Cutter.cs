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
        List<PointF> vertex;

        public Cutter()
        {
            vertex = new List<PointF>();
        }

        public void AddVertex(PointF dot)
        {
            vertex.Add(dot);
        }
        public void AddVertex(int x, int y)
        {
            vertex.Add(new PointF(x, y));
        }

        public void Clear()
        {
            vertex.Clear();
        }
      
        // Проверка выпуклости
        public bool IsConvex()
        {
            return true; //!
        }

        // Алгоритм Кируса-Бека по отсечению отрезка
        public Line CutCyrusBeck(Line l)
        {
            return new Line(); //!
        }



    }
}
