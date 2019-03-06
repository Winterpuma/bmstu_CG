/*
На плоскости задан прямоугольник координатами (по порядку обхода)
вершин и множество точке. Найти такой теугольник с вершинами в точках множества, 
для которого прямая, соединяющая центр прямоугольника и центр тяжести треугольника 
(точка пересечения медиан) образует минимальный угол с осью ординат(Y). 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO
// Corectness of input
// Scaling
// Change negative angle

namespace lab_01
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen figures = new Pen(Color.Red, 3);
        Pen highlight = new Pen(Color.Black, 4);

        Pen myPen = new Pen(Color.Red, 3);
        Font drawFont = new Font("Arial", 10);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        const int ds = 2; // dot size
        const int ds2 = ds * 2;
        //List<PointF> drawlist;

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
            g = panel1.CreateGraphics();
        }

        // Auto numeration of Rows
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView1.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gather and check data
            List<PointF> points = ParseTable(dataGridView1);
            List<PointF> rect = ParseTable(dataGridView2, 0);

            if (rect.Count == 0 || points.Count == 0)
                return;

            PointF[] new_rect = new PointF[4];
            PointF[] new_tr = new PointF[3];

            rect.Insert(1, new PointF(rect[0].X, rect[1].Y));
            rect.Add(new PointF(rect[2].X, rect[0].Y));

            // Find dots for task
            PointF[] res_tr = FindTriangle(points, rect);

            // Point conversion
            Converter conv = SetMinMax(rect, res_tr);

            for (int i = 0; i < 3; i++)
                new_tr[i] = conv.GetPointF(res_tr[i]);
            for (int i = 0; i < 4; i++)
                new_rect[i] = conv.GetPointF(rect[i]);

            PointF tr_center = GetWeightCenter(new_tr[0], new_tr[1], new_tr[2]);
            PointF rect_center = GetLineCenter(new_rect[0], new_rect[2]);

            // Draw
            g.Clear(panel1.BackColor);

            DrawFigure(conv, new_rect, rect.ToArray(), 4);
            DrawFigure(conv, new_tr, res_tr, 3);
            g.DrawLine(figures, rect_center, tr_center);

            panel1.Update();
        }

        private void DrawFigure(Converter conv, PointF[] dots, PointF[] old, int n)
        {
            g.DrawPolygon(figures, dots);
            for (int i = 0; i < n; i++)
                g.DrawEllipse(highlight, dots[i].X - ds, dots[i].Y - ds, ds2, ds2);
            for (int i = 0; i < n; i++)
                g.DrawString("(" + ((int)old[i].X).ToString() + "," + ((int)old[i].Y).ToString() + ")", drawFont, drawBrush, conv.GetPointWithMargin(old[i]));
        }

        private List<PointF> ParseTable(DataGridView data, int flag = 1)
        {
            bool go = true; // all data correct
            bool check_x, check_y;
            float x, y;
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < data.RowCount - flag; i++)
            {
                if (data.Rows[i].Cells[0].Value == null || data.Rows[i].Cells[1].Value == null)
                {
                    go = false;
                    data.Rows[i].ErrorText = "Empty cell!";
                }
                else
                {
                    check_x = float.TryParse(data.Rows[i].Cells[0].Value.ToString(), out x);
                    check_y = float.TryParse(data.Rows[i].Cells[1].Value.ToString(), out y);
                    if (check_x & check_y)
                    {
                        if (go)
                            points.Add(new PointF(x, y));
                        data.Rows[i].ErrorText = null;
                    }
                    else
                    {
                        go = false;
                        data.Rows[i].ErrorText = "Wrong Value!";
                    }
                }
            }
            if (!go)
                points.Clear();

            return points;
        }

        /* --- MATH --- */

        private Converter SetMinMax(List<PointF> rect, PointF[] res_tr)
        {
            float min_x, min_y, max_x, max_y;
            min_x = rect[0].X;
            min_y = rect[0].Y;
            max_x = rect[0].X;
            max_y = rect[0].Y;

            // NOTE EDIT
            for (int i = 1; i < 4; i++)
            {
                min_x = Math.Min(min_x, rect[i].X);
                min_y = Math.Min(min_y, rect[i].Y);
                max_x = Math.Max(max_x, rect[i].X);
                max_y = Math.Max(max_y, rect[i].Y);
            }
            for (int i = 0; i < 3; i++)
            {
                min_x = Math.Min(min_x, res_tr[i].X);
                min_y = Math.Min(min_y, res_tr[i].Y);
                max_x = Math.Max(max_x, res_tr[i].X);
                max_y = Math.Max(max_y, res_tr[i].Y);
            }

            return new Converter(new PointF(min_x, min_y), new PointF(max_x, max_y), panel1.Size, 5);
        }

        private PointF GetWeightCenter(PointF a, PointF b, PointF c)
        {
            return new PointF((a.X + b.X + c.X) / 3, (a.Y + b.Y + c.Y) / 3);
        }

        private PointF GetLineCenter(PointF a, PointF b)
        {
            return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        private double FindAngleOY(PointF b, PointF e)
        {
            double vectX = b.X - e.X;
            double vectY = b.Y - e.Y;

            double axisX = 0;
            double axisY = 1;

            double numerator = vectX * axisX + vectY * axisY;
            double denominator = Math.Sqrt(vectX * vectX + vectY * vectY); // * Math.Sqrt(axisX*axisX + axisY*axisY); 

            double res = Math.Acos(numerator / denominator);
            return (res > Math.PI / 2) ? res - Math.PI / 2 : res;
        }
        
        private PointF[] FindTriangle(List<PointF> points, List<PointF> rect)
        {
            double min_angle = Math.PI;
            double current_angle = -1;
            int[] i_min_points = new int[3];
            PointF[] min_points = new PointF[3];
            PointF rect_center = GetLineCenter(rect[0], rect[1]);

            for (int i = 0; i < points.Count - 2; i++)
            {
                for (int j = i + 1; j < points.Count - 1; j++)
                {
                    for (int k = j + 1; k < points.Count; k++)
                    {
                        current_angle = FindAngleOY(GetWeightCenter(points[i], points[j], points[k]), rect_center);
                        if (current_angle < min_angle)
                        {
                            min_angle = current_angle;
                            i_min_points[0] = i;
                            i_min_points[1] = j;
                            i_min_points[2] = k;
                        }
                    }
                }
            }
            min_points[0] = points[i_min_points[0]];
            min_points[1] = points[i_min_points[1]];
            min_points[2] = points[i_min_points[2]];
            return min_points;
        }
    }
}
