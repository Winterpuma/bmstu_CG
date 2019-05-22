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
            pen_fill = new Pen(Color.Red, 1);
            pictureBoxColor.BackColor = Color.Red;

            radioButtonDelayNone.Checked = true;
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

        // Рисует все сохраненные точки
        private void DrawAll()
        {
            int i;
            for (i = 0; i < Polygons.Count(); i++)
            {
                if (Polygons[i].Count > 1)
                    g.DrawPolygon(pen, Polygons[i].ToArray());
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
                else if (ModifierKeys == Keys.Alt)
                {
                    LineByLineSeedAlgorithm(saved_picture, mousePos, pen_fill.Color, pen.Color, radioButtonDeleyPix.Checked, radioButtonDelayLine.Checked);
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

        // Закраска
        private void buttonFill_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawAll();
            canvasBase.Refresh();
            Point seed = new Point(Convert.ToInt32(textBoxX.Text), Convert.ToInt32(textBoxY.Text));

            // алгоритмы
            //SimpleSeedAlgorithm(saved_picture, seed, pen_fill.Color, pen.Color);
            LineByLineSeedAlgorithm(saved_picture, seed, pen_fill.Color, pen.Color, radioButtonDeleyPix.Checked, radioButtonDelayLine.Checked);

            canvasBase.Refresh();
        }

        // Возвращает true, если пиксель уже закрашен или граничный
        private bool PixelIsFillOrBorder(Bitmap b, int x, int y, Color c_new_fill, Color c_border)
        {
            if ((x >= 0) && (x < b.Width) && (y >= 0) && (y < b.Height))
            {
                Color c_curr = b.GetPixel(x, y);
                if (c_curr.ToArgb() == c_new_fill.ToArgb() || 
                    c_curr.ToArgb() == c_border.ToArgb())
                    return true;
            }
            return false;
        }

        // Возвращает true, если цвет пикселя совпадает с color
        private bool PixelIsSameColor(Bitmap b, int x, int y, Color color)
        {
            if ((x >= 0) && (x < b.Width) && (y >= 0) && (y < b.Height))
                return b.GetPixel(x, y).ToArgb() == color.ToArgb();
            
            return false;
        }

        // Простой алгоритм заполнения
        private void SimpleSeedAlgorithm(Bitmap b, Point seed, Color c_new_fill, Color c_border, bool wait_pix = false)
        {
            Stack<Point> stack = new Stack<Point>();
            Point p_curr;
            Color c_curr;

            stack.Push(seed);
            while (stack.Count > 0)
            {
                p_curr = stack.Pop();
                c_curr = b.GetPixel(p_curr.X, p_curr.Y);
                if (c_curr != c_new_fill && c_curr != c_border)
                    b.SetPixel(p_curr.X, p_curr.Y, c_new_fill);

                if (!PixelIsFillOrBorder(b, p_curr.X + 1, p_curr.Y, c_new_fill, c_border))
                    stack.Push(new Point(p_curr.X + 1, p_curr.Y));
                if (!PixelIsFillOrBorder(b, p_curr.X, p_curr.Y + 1, c_new_fill, c_border))
                    stack.Push(new Point(p_curr.X, p_curr.Y + 1));
                if (!PixelIsFillOrBorder(b, p_curr.X - 1, p_curr.Y, c_new_fill, c_border))
                    stack.Push(new Point(p_curr.X - 1, p_curr.Y));
                if (!PixelIsFillOrBorder(b, p_curr.X, p_curr.Y - 1, c_new_fill, c_border))
                    stack.Push(new Point(p_curr.X, p_curr.Y - 1));
                canvasBase.Refresh();
            }
        }

        // Находим затравочные пиксели на строке от x_left до x_right
        private void FindSeed(Stack<Point> stack, Bitmap b, int x_left, int x_right, int y, Color c_new_fill, Color c_border)
        {
            int x = x_left;
            bool flag = false; // найден незакрашенный пиксель
            while (x <= x_right)
            {
                // Проходим до конца незакрашенного интервала
                while (!PixelIsFillOrBorder(b, x, y, c_new_fill, c_border) && x <= x_right)
                {
                    flag = true;
                    x++;
                }

                // В стек помещаем крайний справа пиксель
                if (flag)
                    if (x == x_right && !(PixelIsFillOrBorder(b, x, y, c_new_fill, c_border) && x < x_right))
                        stack.Push(new Point(x, y));
                    else
                        stack.Push(new Point(x - 1, y));

                // Продолжим проверку, если интервал был прерван
                do
                {
                    x++;
                }
                while (PixelIsFillOrBorder(b, x, y, c_new_fill, c_border) && x < x_right);
            }
        }

        // Построчный алгоритм заполнения с затравкой
        private void LineByLineSeedAlgorithm(Bitmap b, Point seed, Color c_fill, Color c_border, bool wait_pix = false, bool wait_line = false)
        {
            Stack<Point> stack = new Stack<Point>();
            Point pix;
            int x, y;
            int x_right, x_left;
            stack.Push(seed);

            while (stack.Count > 0)
            {
                pix = stack.Pop();
                x = pix.X;
                y = pix.Y;

                if (PixelIsSameColor(b, x, y, c_fill))
                    continue;

                while (!PixelIsSameColor(b, x, y, c_border) && x < b.Width)
                {
                    b.SetPixel(x, y, c_fill);
                    if (wait_pix) // Эти проверки на задержку замедляют алгоритм без задержки 
                        canvasBase.Refresh();
                    x++;
                }
                x_right = x - 1;

                x = pix.X - 1;
                while (!PixelIsSameColor(b, x, y, c_border) && x > 0)
                {
                    b.SetPixel(x, y, c_fill);
                    if (wait_pix)
                        canvasBase.Refresh();
                    x--;
                }
                x_left = x + 1;

                if (y > 0)
                    FindSeed(stack, b, x_left, x_right, y - 1, c_fill, c_border);
                if (y < canvasBase.Height - 1)
                    FindSeed(stack, b, x_left, x_right, y + 1, c_fill, c_border);
                if (wait_line)
                    canvasBase.Refresh();
            }
            canvasBase.Refresh();
        }

        // Добавить очередную вершину многоугольника
        private void buttonEnterDot_Click(object sender, EventArgs e)
        {
            Point new_point = new Point(Convert.ToInt32(textBoxX.Text), Convert.ToInt32(textBoxY.Text));
            LastPolygon.Add(new_point);
            DrawEdgeStatic();
            canvasBase.Refresh();
        }
    }
}
