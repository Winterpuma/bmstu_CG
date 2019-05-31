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
    struct Line
    {
        public PointF start;
        public PointF end;

        public Line(PointF a, PointF b)
        {
            start = a;
            end = b;
        }
    };

    public partial class Form1 : Form
    {
        Cutter cutter;
        List<Line> lines;
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
            lines = new List<Line>();
            last_line = new List<PointF>();

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;

            pen_cutter = new Pen(Color.Black, 1);
            pen_lines = new Pen(Color.Red, 1);
            pen_highlight = new Pen(Color.Blue, 1);

            pictureBoxColor.BackColor = Color.Blue;
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentLine()
        {
            if (last_line.Count() == 1)
            {
                PointF a = last_line[0];
                PointF b = canvasBase.PointToClient(MousePosition);

                if (ModifierKeys == Keys.Control)
                    b.Y = a.Y;
                else if (ModifierKeys == Keys.Alt)
                    b.X = a.X;

                g_move.DrawLine(pen_lines, a, b);
            }
        }

        // Перемещение мыши внутри холста
        private void canvasBase_MouseMove(object sender, MouseEventArgs e)
        {
            labelLocation.Text = canvasBase.PointToClient(MousePosition).ToString();
            canvasBase.Refresh(); // Убирает g_move с холста
            DrawCurrentLine();
        }

        // Нажатие на холст
        private void canvasBase_Click(object sender, EventArgs e)
        {
            PointF mousePos = new PointF(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);//canvasBase.PointToClient(MousePosition);

            if (((MouseEventArgs)e).Button == MouseButtons.Left)
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
                    lines.Add(new Line(last_line[0], last_line[1]));
                    last_line.Clear();
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
            lines.Clear();
            last_line.Clear();
            cutter.Clear();

            g.Clear(Color.White);
            canvasBase.Refresh();
        }

        // Отсечение
        private void buttonCut_Click(object sender, EventArgs e)
        {
            Line tmp;
            for (int i = 0; i < lines.Count(); i++)
            {
                tmp = cutter.CutCyrusBeck(lines[i]);
                g.DrawLine(pen_highlight, tmp.start, tmp.end);
                canvasBase.Refresh();
            }
            canvasBase.Refresh();
        }
    }
}

