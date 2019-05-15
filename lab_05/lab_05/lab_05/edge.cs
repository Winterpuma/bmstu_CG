using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_05
{
    public class Edge
    {
        public int dy; // количество сканирующих строк пересекающих ребро
        public float x; // координата пересечения x наивысшей сканирующей строки и данного ребра
        public float dx; // шаг изменения x при переходе от одной скан. стр. к следующей

        public int save_dy; 
        public float save_x;

        public Edge(int dy, float x, float dx)
        {
            save_dy = dy;
            save_x = x;
            this.dy = dy;
            this.x = x;
            this.dx = dx;
        }

        public void ResetEdge()
        {
            dy = save_dy;
            x = save_x;
        }
    }
}
