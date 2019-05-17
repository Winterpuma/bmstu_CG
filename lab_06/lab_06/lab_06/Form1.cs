using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_06
{
    public partial class Form1 : Form
    {
        List<List<Point>> Polygons;
        List<Point> LastPolygon;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;
        Pen pen; // edges
        Pen pen_fill;

        public Form1()
        {
            InitializeComponent();

            Polygons = new List<List<Point>>();
            Polygons.Add(new List<Point>());
            LastPolygon = Polygons[Polygons.Count - 1];

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;
            pen = new Pen(Color.Black, 1);
            pen_fill = new Pen(Color.Beige, 1);
            pictureBoxColor.BackColor = Color.Beige;
        }

        // Очистка экрана
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Polygons.Clear();
            Polygons.Add(new List<Point>());
            LastPolygon.Clear();
            LastPolygon = Polygons[0];
            g.Clear(Color.White);
            canvasBase.Refresh();
            g.DrawLine(Pens.Black, 0, 0, 0, 0);
        }

        // Смена цвет заливки
        private void buttonColorFill_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxColor.BackColor = colorDialog.Color;
                pen_fill.Color = colorDialog.Color;
            }
        }

        // Рисует ребро многоугольника
        private void DrawEdgeStatic(bool last_edge = false)
        {
            if (LastPolygon.Count >= 2)
            {
                Point a = LastPolygon[LastPolygon.Count - 1];
                Point b;
                if (!last_edge)
                    b = LastPolygon[LastPolygon.Count - 2];
                else
                    b = LastPolygon[0];

                g.DrawLine(pen, a, b);
            }
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentEdge()
        {
            if (LastPolygon.Count > 0)
            {
                Point a = LastPolygon[LastPolygon.Count - 1];
                Point b = canvasBase.PointToClient(MousePosition);

                if (ModifierKeys == Keys.Control)
                    b.Y = a.Y;

                g_move.DrawLine(pen, a, b);
            }
        }

        // Нажатие на холст
        private void canvasBase_Click(object sender, EventArgs e)
        {
            Point mousePos = canvasBase.PointToClient(MousePosition);

            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    LastPolygon.Add(new Point(mousePos.X, LastPolygon[LastPolygon.Count - 1].Y));
                }
                else
                {
                    LastPolygon.Add(mousePos);
                }
                
                DrawEdgeStatic();
            }

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                DrawEdgeStatic(true);
                Polygons.Add(new List<Point>());
                LastPolygon = Polygons[Polygons.Count - 1];
            }
        }

        // Перемещение мыши внутри холста
        private void canvasBase_MouseMove(object sender, MouseEventArgs e)
        {
            labelLocation.Text = canvasBase.PointToClient(MousePosition).ToString();
            canvasBase.Refresh(); // Убирает g_move с холста
            DrawCurrentEdge();
        }
    }
}
