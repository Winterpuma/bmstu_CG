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

namespace lab_01
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pretty = new Pen(Color.Black, 3);
        List<PointF> drawlist;

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

        private List<PointF> getPointsList(DataGridView data, int flag = 1)
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

            List<PointF> points = getPointsList(dataGridView1);
            List<PointF> rect = getPointsList(dataGridView2, 0);

            rect.Insert(1, new PointF(rect[0].X, rect[1].Y));
            rect.Add(new PointF(rect[2].X, rect[0].Y));

            draw(points, panel1, rect);
        }

        private void draw(List<PointF> points, Panel panel, List<PointF> rect)
        {
            g.Clear(panel.BackColor);
            for (int i = 0; i < points.Count; i++)
            {
                g.DrawEllipse(pretty, points[i].X, points[i].Y, 5, 5);
            }

            g.DrawPolygon(pretty, rect.ToArray());

            panel.Update();
        }

    }
}
