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

namespace lab_01
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen figures = new Pen(Color.Black, 3);
        Pen highlight = new Pen(Color.Red, 4);
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

        // Get list of points from table
        private List<PointF> GetPointsList(DataGridView data, int flag = 1)
        {
            float x, y;
            int n_rows = data.RowCount;
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < n_rows - flag; i++)
            {
                x = (float)Convert.ToDouble(data.Rows[i].Cells[0].Value);
                y = (float)Convert.ToDouble(data.Rows[i].Cells[1].Value);
                points.Add(new PointF(x, y));
            }

            return points;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gather data
            List<PointF> points = GetPointsList(dataGridView1);
            List<PointF> rect = GetPointsList(dataGridView2, 0);

            rect.Insert(1, new PointF(rect[0].X, rect[1].Y));
            rect.Add(new PointF(rect[2].X, rect[0].Y));

            // Find dots for task
            PointF rect_center = GetLineCenter(rect[0], rect[2]);
            PointF[] res_tr = FindTriangle(points, rect);
            PointF tr_center = GetWeightCenter(res_tr[0], res_tr[1], res_tr[2]);

            // Draw
            g.Clear(panel1.BackColor);
            for (int i = 0; i < points.Count; i++)
                g.DrawEllipse(figures, points[i].X, points[i].Y, 5, 5);


            for (int i = 0; i < 3; i++)
                g.DrawEllipse(Pens.Aqua, res_tr[i].X, res_tr[i].Y, 8, 8);

            g.DrawLine(figures, rect_center, tr_center);
            g.DrawEllipse(highlight, tr_center.X, tr_center.Y, 5, 5);
            g.DrawEllipse(highlight, rect_center.X, rect_center.Y, 5, 5);

            g.DrawPolygon(figures, res_tr);
            g.DrawPolygon(figures, rect.ToArray()); // rect

            panel1.Update();
            //draw(points, panel1, rect, res_tr);
        }

        private void GetWeightCenter(PointF a, PointF b, PointF c, PointF res)
        {
            res.X = (a.X + b.X + c.X) / 3;
            res.Y = (a.Y + b.Y + c.Y) / 3;
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
            PointF triangle_center = new PointF();

            for (int i = 0; i < points.Count - 2; i++)
            {
                for (int j = i + 1; j < points.Count - 1; j++)
                {
                    for (int k = j + 1; k < points.Count; k++)
                    {
                        //GetWeightCenter(points[i], points[j], points[k], triangle_center);
                        //current_angle = FindAngleOY(triangle_center, rect_center);
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

        private void draw(List<PointF> points, Panel panel, List<PointF> rect, PointF[] tr_points)
        {
            PointF tr_center = new PointF();
            GetWeightCenter(tr_points[0], tr_points[1], tr_points[2], tr_center);

            g.Clear(panel.BackColor);
            for (int i = 0; i < points.Count; i++)
                g.DrawEllipse(figures, points[i].X, points[i].Y, 5, 5);
            

            for (int i = 0; i < 3; i++)
                g.DrawEllipse(Pens.Aqua, tr_points[i].X, tr_points[i].Y, 8, 8);

            //g.DrawLine(pretty, GetLineCenter(rect[0], rect[1]), )

            g.DrawPolygon(figures, rect.ToArray());

            panel.Update();
        }
    }
}
