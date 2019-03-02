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
        List<Point> drawlist;

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
        }

        // Auto numeration of Rows
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView1.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x, y;
            int n_rows = dataGridView1.RowCount;
            List<Point> points = new List<Point>();

            for (int i = 0; i < n_rows-1; i++)
            {
                x = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                y = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                points.Add(new Point(x, y));
            }

            draw(points, panel1);
        }

        private void draw(List<Point> points, Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);
            for (int i = 0; i < points.Count; i++)
            {
                g.DrawEllipse(Pens.Red, points[i].x, points[i].y, 5, 5);
            }

            panel.Update();
        }
    }
}
