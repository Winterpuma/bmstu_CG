using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_05
{
    class ListOfActiveEdges
    {
        List<Edge> ActiveEdges = new List<Edge>();
        int y = 0; // текущая сканирующая строка
        int RightBorder = 1000; 

        public void AddYgroup(List<Edge> Ygroup)
        {
            ActiveEdges.AddRange(Ygroup);
            y++;
        }

        public void Update()
        {
            for (int i = 0; i < ActiveEdges.Count; i++)
            {
                ActiveEdges[i].dy -= 1;
                ActiveEdges[i].x += ActiveEdges[i].dx;
                if (ActiveEdges[i].dy < 0)
                    ActiveEdges.RemoveAt(i);
            }
        }

        private List<int> GetXvalues()
        {
            List<int> x = new List<int>();

            int size = ActiveEdges.Count;
            for (int i = 0; i < size; i++)
                x.Add(Convert.ToInt32(ActiveEdges[i].x));

            if (size % 2 == 1)
                x.Add(RightBorder);

            return x;
        }

        public void Draw(Graphics DrawingArea, Pen pen)
        {
            List<int> x = GetXvalues();

            for (int i = 0; i < x.Count; i += 2)
                DrawingArea.DrawLine(pen, x[i], y, x[i + 1], y);
        }
    }
}
