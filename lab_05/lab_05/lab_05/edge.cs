using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_05
{
    public class Edge
    {
        public float x; // координата пересечения x наивысшей сканирующей строки и данного ребра
        public int dy; // количество сканирующих строк пересекающих ребро
        public float dx; // шаг изменения x при переходе от одной скан. стр. к следующей
    }
}
