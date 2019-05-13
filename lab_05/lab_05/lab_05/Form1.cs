using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_05
{
    public partial class Form1 : Form
    {
        List<List<Point>> Polygons;
        List<Point> LastPolygon;
        List<Edge>[] y_group;
        ListOfActiveEdges ActiveEdges;

        Graphics g;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            y_group = new List<Edge>[pictureBox1.Height];
            ActiveEdges = new ListOfActiveEdges(pictureBox1.Width);
            
            Polygons = new List<List<Point>>();
            Polygons.Add(new List<Point>());
            LastPolygon = Polygons[Polygons.Count - 1];
            g = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black, 1);
        }

        // Рисует все сохраненные точки
        private void DrawAllLines()
        {
            int i;
            for (i = 0; i < Polygons.Count() - 1; i++)
            {
                if (Polygons[i].Count > 1)
                {
                    g.DrawLines(pen, Polygons[i].ToArray());
                    g.DrawLine(pen, Polygons[i][0], Polygons[i][Polygons[i].Count - 1]);
                }
            }
            // последний многоугольник
            if (Polygons[i].Count > 1)
            {
                g.DrawLines(pen, Polygons[i].ToArray());
            }
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentEdge()
        {
            if (LastPolygon.Count > 0)
            {
                Point a = LastPolygon[LastPolygon.Count - 1];
                Point b = pictureBox1.PointToClient(MousePosition);

                if (ModifierKeys == Keys.Control)
                    b.Y = a.Y;

                g.DrawLine(pen, a, b);
            }
        }

        // Перемещение мыши внутри холста
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // отчистка экрана
            pictureBox1.Refresh();
            DrawAllLines();    
            DrawCurrentEdge();
        }

        // Нажатие на холст
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    LastPolygon.Add(new Point(pictureBox1.PointToClient(MousePosition).X, LastPolygon[LastPolygon.Count - 1].Y));
                }
                else
                {
                    LastPolygon.Add(pictureBox1.PointToClient(MousePosition));
                }
            }

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Polygons.Add(new List<Point>());
                LastPolygon = Polygons[Polygons.Count - 1];
            }

            DrawAllLines();
        }
    }
}
