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
        List<Edge> ActiveEdges;
        private int RightBorder; 

        public ListOfActiveEdges(int Width)
        {
            ActiveEdges = new List<Edge>();
            RightBorder = Width;
        }

        public void Clear()
        {
            ActiveEdges.Clear();
        }

        public void AddYgroup(List<Edge> Ygroup)
        {
            foreach (Edge e in Ygroup)
                e.ResetEdge();
            ActiveEdges.AddRange(Ygroup);
        }

        public void Update()
        {
            for (int i = 0; i < ActiveEdges.Count; i++)
            {
                ActiveEdges[i].dy -= 1;
                ActiveEdges[i].x += ActiveEdges[i].dx;
            }
            ActiveEdges.RemoveAll(el => el.dy == 0);
        }

        private List<int> GetXvalues()
        {
            List<int> x = new List<int>();

            int size = ActiveEdges.Count;
            for (int i = 0; i < size; i++)
                x.Add(Convert.ToInt32(ActiveEdges[i].x));
            x.Sort();

            return x;
        }

        public void Draw(System.Windows.Forms.PictureBox pb, Graphics DrawingArea, Pen pen, int y, int delay = 0)
        {
            List<int> x = GetXvalues();

            if (delay != 0)
            {
                for (int i = 0; i < x.Count; i += 2)
                {
                    DrawingArea.DrawLine(pen, x[i], y, x[i + 1], y);
                    pb.CancelAsync();
                    pb.Refresh();
                    System.Threading.Thread.Sleep(delay);
                }
            }
            else
            {
                for (int i = 0; i < x.Count; i += 2)
                    DrawingArea.DrawLine(pen, x[i], y, x[i + 1], y);
            }
        }
    }
}
