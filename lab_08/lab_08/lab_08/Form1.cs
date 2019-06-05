using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_08
{
    struct Segment
    {
        public PointF start;
        public PointF end;

        public Segment(PointF a, PointF b)
        {
            start = a;
            end = b;
        }

        private float GetCoordX(float t)
        {
            return start.X + (end.X - start.X) * t;
        }
        private float GetCoordY(float t)
        {
            return start.Y + (end.Y - start.Y) * t;
        }
        public PointF GetDot(float t)
        {
            return new PointF(GetCoordX(t), GetCoordY(t));
        }
    };


    public partial class Form1 : Form
    {
        Cutter cutter;
        List<Segment> lines;
        List<PointF> last_line;

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
            lines = new List<Segment>();
            last_line = new List<PointF>();

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;

            pen_cutter = new Pen(Color.Black, 1);
            pen_lines = new Pen(Color.Red, 1);
            pen_highlight = new Pen(Color.Blue, 1);
            pictureBoxColor.BackColor = Color.Blue;

            radioButtonCutter.Checked = true;

            /*cutter.AddVertex(1, 0);
            cutter.AddVertex(0, 1);
            cutter.AddVertex(0, 2);
            cutter.AddVertex(1, 3);
            cutter.AddVertex(2, 3);
            cutter.AddVertex(3, 2);
            cutter.AddVertex(3, 1);
            cutter.AddVertex(2, 0);

            cutter.CutCyrusBeck(new Segment(new PointF(-1, 1), new PointF(3, 3)));*/
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentLine()
        {
            bool flag_draw = false;

            PointF a = new PointF();
            PointF b = canvasBase.PointToClient(MousePosition);
            Pen pen = pen_lines;

            if (radioButtonLines.Checked && (last_line.Count() == 1))
            {
                a = last_line[0];
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

        // Нажатие на холст при вводе линии
        private void Line_Click(PointF mousePos)
        {
            if (last_line.Count() == 0)
            {
                last_line.Add(mousePos);
            }
            else
            {
                if (ModifierKeys == Keys.Control) // горизонтальная линия
                {
                    last_line.Add(new PointF(mousePos.X, last_line[0].Y));
                }
                else if (ModifierKeys == Keys.Alt) // вертикальная линия
                {
                    last_line.Add(new PointF(last_line[0].X, mousePos.Y));
                }
                else
                {
                    last_line.Add(mousePos);
                }

                g.DrawLine(pen_lines, last_line[0], last_line[1]);
                canvasBase.Refresh();
                lines.Add(new Segment(last_line[0], last_line[1]));
                last_line.Clear();
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
                    Line_Click(mousePos);
                else if (radioButtonCutter.Checked)
                    Cutter_Click(mousePos);
            }
            else if ((((MouseEventArgs)e).Button == MouseButtons.Right) && (radioButtonCutter.Checked))
            {
                cutter.Finish();
                g.DrawLine(pen_cutter, cutter.GetVertex(-1), cutter.GetVertex(0));
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
            lines.Clear();
            last_line.Clear();
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

            Segment tmp;
            for (int i = 0; i < lines.Count(); i++)
            {
                tmp = cutter.CutCyrusBeck(lines[i]);
                g.DrawLine(pen_highlight, tmp.start, tmp.end);
                canvasBase.Refresh();
            }
            canvasBase.Refresh();
        }

        // Добавить точку в отсекатель или линию
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
                Line_Click(dot);
            }
        }
    }
}

