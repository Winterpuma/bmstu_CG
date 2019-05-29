using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab_07
{
    public partial class Form1 : Form
    {
        List<List<PointF>> lines;
        List<PointF> last_line;
        Cutter cutter;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;

        Pen pen_cutter;//!!!
        Pen pen_lines; // lines
        Pen pen_choosen;

        public Form1()
        {
            InitializeComponent();

            lines = new List<List<PointF>>();
            lines.Add(new List<PointF>());
            last_line = lines[0];
            cutter = new Cutter();

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;

            pen_cutter = new Pen(Color.Black, 1);
            pen_lines = new Pen(Color.Red, 1);
            pen_choosen = new Pen(Color.Blue, 1);

            pictureBoxColor.BackColor = Color.Blue;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Проверяет, используюя коды двух точек, пересечение бесконечной стороны и линии
        bool Intersect(int T1, int T2, int side)
        {
            int coord = (int)Math.Pow(2, 3 - side);

            if ((T1 & coord) != (T2 & coord))
                return true;
            else
                return false;
        }

        // Алгоритм Коэна — Сазерленда для отрезка
        void CohenSutherland(PointF a, PointF b)
        {
            int orientation_flag = 0; // общего
            float slope = 1; // наклон

            if (b.X - a.X == 0)
                orientation_flag = -1; // вертикальный
            else
            {
                slope = (b.Y - a.Y) / (b.X - a.X);
                if (slope == 0)
                    orientation_flag = 1; // горизонтальный
            }

            for (int i = 0; i < 4; i++)
            {
                // Находим коды
                int SumA = cutter.GetPositioning(a);
                int SumB = cutter.GetPositioning(b);
                
                int visible = cutter.IsVisible(a, b);
                if (visible == 1) // Тривиальная видимость
                {
                    g.DrawLine(pen_choosen, a, b);
                    return;
                }
                else if (visible == 0) // Тривиальная невидимость
                    return;

                // Проверяем пересечение отрезка и стороны окна
                //Console.WriteLine("Sum:" + SumA.ToString() + SumB.ToString());
                if (!Intersect(SumA, SumB, i))
                {
                    //Console.WriteLine("not intersecting" + i.ToString());
                    continue;
                }

                // Если точка а внутри стороны
                if ((SumA & (int)Math.Pow(2, 3 - i)) == 0)
                {
                    //Console.WriteLine("A inside");
                    Swap(ref a, ref b);
                }

                // Поиск пересечений отрезка со стороной
                if (orientation_flag != -1) // не вертикальный
                {
                    if (i < 2) // если рассматриваем левую или правую сторону отсекателя
                    {
                        a.Y = slope * (cutter[i] - a.X) + a.Y;
                        a.X = cutter[i];
                        continue;
                    }
                    else
                        a.X = (1 / slope) * (cutter[i] - a.Y) + a.X;
                }
                a.Y = cutter[i];
            }
            g.DrawLine(pen_choosen, a, b);
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

        // Получить значения и отобразить отсекатель
        private void buttonGetCutter_Click(object sender, EventArgs e)
        {
            lines.Clear();
            lines.Add(new List<PointF>());
            last_line = lines[0];

            g.Clear(Color.White);
            canvasBase.Refresh();

            cutter.left = Convert.ToInt32(textBoxLeft.Text);
            cutter.right = Convert.ToInt32(textBoxRight.Text);
            cutter.down = Convert.ToInt32(textBoxDown.Text);
            cutter.up = Convert.ToInt32(textBoxUp.Text);

            g.DrawRectangle(pen_cutter, cutter.left, cutter.up, cutter.right - cutter.left, cutter.down - cutter.up);
            canvasBase.Refresh();
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
                    lines.Add(new List<PointF>());
                    last_line = lines[lines.Count() - 1];
                }
            }
        }

        // Смена цвет выделения
        private void buttonColorFill_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxColor.BackColor = colorDialog.Color;
                pen_choosen.Color = colorDialog.Color;
            }
        }

        // Очистка холста
        private void buttonClear_Click(object sender, EventArgs e)
        {
            lines.Clear();
            lines.Add(new List<PointF>());
            last_line = lines[0];

            g.Clear(Color.White);
            canvasBase.Refresh();
        }

        // Отсечение
        private void buttonCut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lines.Count() -1; i++)
            {
                CohenSutherland(lines[i][0], lines[i][1]);
                canvasBase.Refresh();
            }
            canvasBase.Refresh();
        }
    }
}
