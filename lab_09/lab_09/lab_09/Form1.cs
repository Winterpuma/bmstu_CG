using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_09
{
    public partial class Form1 : Form
    {
        Cutter cutter;
        List<PointF> polygon;
        bool polygon_finished = false;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;

        Pen pen_cutter;
        Pen pen_lines;
        Pen pen_highlight;

        public Form1()
        {
            InitializeComponent();

            cutter = new Cutter();
            polygon = new List<PointF>();

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;

            pen_cutter = new Pen(Color.Black, 1);
            pen_lines = new Pen(Color.Red, 1);
            pen_highlight = new Pen(Color.Blue, 2);
            pictureBoxColor.BackColor = Color.Blue;

            radioButtonCutter.Checked = true;
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentLine()
        {
            bool flag_draw = false;

            PointF a = new PointF();
            PointF b = canvasBase.PointToClient(MousePosition);
            Pen pen = pen_lines;

            if (radioButtonLines.Checked && (polygon.Count() != 0) && !polygon_finished)
            {
                a = polygon[polygon.Count() - 1];
                flag_draw = true;
            }
            else if (radioButtonCutter.Checked && (!cutter.IsEmpty()) && (!cutter.IsFinished()))
            {
                pen = pen_cutter;
                a = cutter.GetVertex(-1);
                flag_draw = true;
            }

            if (flag_draw)
            {
                if (ModifierKeys == Keys.Control)
                    b.Y = a.Y;
                else if (ModifierKeys == Keys.Alt)
                    b.X = a.X;

                g_move.DrawLine(pen, a, b);
            }
        }

        // Перемещение мыши внутри холста
        private void canvasBase_MouseMove(object sender, MouseEventArgs e)
        {
            labelLocation.Text = canvasBase.PointToClient(MousePosition).ToString();
            canvasBase.Refresh(); // Убирает g_move с холста
            DrawCurrentLine();
        }

        // Нажатие на холст при вводе отсекаемого многоугольника
        private void Polygon_Click(PointF mousePos)
        {
            if (polygon_finished)
                return;

            if (polygon.Count() == 0)
            {
                polygon.Add(mousePos);
            }
            else
            {
                if (ModifierKeys == Keys.Control) // горизонтальная линия
                {
                    polygon.Add(new PointF(mousePos.X, polygon.Last().Y));
                }
                else if (ModifierKeys == Keys.Alt) // вертикальная линия
                {
                    polygon.Add(new PointF(polygon.Last().X, mousePos.Y));
                }
                else
                {
                    polygon.Add(mousePos);
                }

                g.DrawLine(pen_lines, polygon.Last(), polygon[polygon.Count - 2]);
                canvasBase.Refresh();
            }
        }

        // Нажатие на холст при вводе отсекателя
        private void Cutter_Click(PointF mousePos)
        {
            if (cutter.IsFinished())
                return;

            if (cutter.IsEmpty())
            {
                cutter.AddVertex(mousePos);
            }
            else
            {
                if (ModifierKeys == Keys.Control) // горизонтальная линия
                {
                    cutter.AddVertex(mousePos.X, cutter.GetVertex(-1).Y);
                }
                else if (ModifierKeys == Keys.Alt) // вертикальная линия
                {
                    cutter.AddVertex(cutter.GetVertex(-1).X, mousePos.Y);
                }
                else
                {
                    cutter.AddVertex(mousePos);
                }

                g.DrawLine(pen_cutter, cutter.GetVertex(-1), cutter.GetVertex(-2));
                canvasBase.Refresh();
            }
        }


        // Нажатие на холст
        private void canvasBase_Click(object sender, EventArgs e)
        {
            PointF mousePos = new PointF(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);//canvasBase.PointToClient(MousePosition);

            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (radioButtonLines.Checked)
                    Polygon_Click(mousePos);
                else if (radioButtonCutter.Checked)
                    Cutter_Click(mousePos);
            }
            else if ((((MouseEventArgs)e).Button == MouseButtons.Right))
            {
                if (radioButtonCutter.Checked)
                {
                    cutter.Finish();
                    g.DrawLine(pen_cutter, cutter.GetVertex(-1), cutter.GetVertex(0));
                }
                else if (radioButtonLines.Checked)
                {
                    polygon_finished = true;
                    g.DrawLine(pen_lines, polygon[0], polygon.Last());
                }
            }
        }

        // Смена цвет выделения
        private void buttonColorFill_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxColor.BackColor = colorDialog.Color;
                pen_highlight.Color = colorDialog.Color;
            }
        }

        // Очистка холста
        private void buttonClear_Click(object sender, EventArgs e)
        {
            polygon.Clear();
            polygon_finished = false;
            cutter.Clear();

            g.Clear(Color.White);
            canvasBase.Refresh();
        }

        // Отсечение
        private void buttonCut_Click(object sender, EventArgs e)
        {
            cutter.Finish();
            g.DrawLine(pen_cutter, cutter.GetVertex(0), cutter.GetVertex(-1));
            if (!cutter.IsConvex())
            {
                MessageBox.Show("Многоугольник не выпуклый.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<PointF> tmp = cutter.CutSutherlandHodgman(polygon);

            if (checkBoxFill.Checked)
                g.FillPolygon(Brushes.Blue, tmp.ToArray());
            g.DrawPolygon(pen_highlight, tmp.ToArray());

            canvasBase.Refresh();
        }

        // Добавить точку в отсекатель или многоугольник
        private void buttonAddDot_Click(object sender, EventArgs e)
        {
            // оставить фичей добавление таким способом горизонтальных/вертикальных или добавить флаг в функции??
            PointF dot = new PointF((float)Convert.ToDouble(textBoxX.Text), (float)Convert.ToDouble(textBoxY.Text));
            if (radioButtonCutter.Checked)
            {
                Cutter_Click(dot);
            }
            else if (radioButtonLines.Checked)
            {
                Polygon_Click(dot);
            }
        }
    }
}
