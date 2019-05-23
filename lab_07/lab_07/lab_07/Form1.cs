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
        int[] cutter;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;
        Pen pen; // lines
        Pen pen_choosen;

        public Form1()
        {
            InitializeComponent();

            lines = new List<List<PointF>>();
            lines.Add(new List<PointF>());
            last_line = lines[0];
            cutter = new int[4];

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;
            pen = new Pen(Color.Black, 1);
            pen_choosen = new Pen(Color.Red, 1);
            pictureBoxColor.BackColor = Color.Red;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Возвращает десятичное значение кода нахождения точки
        // относительно окна
        int GetPositioning(PointF p)
        {
            int sum = 0;

            if (p.X < cutter[0]) // левее
                sum += 8;
            if (p.X > cutter[1]) // правее
                sum += 4;
            if (p.Y > cutter[2]) // ниже
                sum += 2;
            if (p.Y < cutter[3]) // выше
                sum += 1;
                
            return sum;
        }

        // Проверяет видимость точки относительно окна
        int IsVisible(PointF a, PointF b)
        {
            int SumA = GetPositioning(a);
            int SumB = GetPositioning(b);

            int visibility = -1;

            if (SumA == 0 && SumB == 0)
                visibility = 1;
            else
            {
                // проверка тривиальной невидимости отрезка
                if ((SumA & SumB) != 0)
                    visibility = 0;
            }
            return visibility;
        }

        // Алгоритм Коэна — Сазерленда для отрезка
        void CohenSutherland(PointF a, PointF b)
        {
            int orientation_flag = 1;
            float slope = 3000;

            if (b.X - a.X == 0)
                orientation_flag = -1; // вертикальный
            else
            {
                slope = (b.Y - a.Y) / (b.X - a.X);
                if (slope == 0)
                    orientation_flag = 0; // горизонтальный
            }

            for (int i = 1; i <= 4; i++)
            {
                int SumA = GetPositioning(a);
                int SumB = GetPositioning(b);

                int visible = IsVisible(a, b);
                if (visible == 1)
                {
                    g.DrawLine(pen_choosen, a, b);
                    canvasBase.Refresh();
                    return;
                }
                else if (visible == 0)
                    return;

                // проверка пересечения отезка и стороны окна                    
                //???зачем
                // проверка нахождения a вне окна
                if (SumA == 0)
                {
                    Swap(ref a, ref b);
                    Swap(ref SumA, ref SumB);
                }

                // поиск пересечений отрезка со сторонами окна
                if ((orientation_flag != -1) && (i <= 2))
                {
                    a.Y = slope * (cutter[i - 1] - a.X) + a.X;
                    a.X = cutter[i - 1];
                }
                else
                {
                    if (orientation_flag != 0)
                    {
                        if (orientation_flag != -1)
                            a.X = (1 / slope) * (cutter[i - 1] - a.Y) + a.X;
                        a.Y = cutter[i - 1];
                    }
                }
                g.DrawLine(pen_choosen, a, b);
            }
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

                g_move.DrawLine(pen, a, b);
            }
        }

        // Получить значения и отобразить отсекатель
        private void buttonGetCutter_Click(object sender, EventArgs e)
        {
            lines.Clear();
            g.Clear(Color.White);
            canvasBase.Refresh();

            cutter[0] = Convert.ToInt32(textBoxLeft.Text);
            cutter[1] = Convert.ToInt32(textBoxRight.Text);
            cutter[2] = Convert.ToInt32(textBoxDown.Text);
            cutter[3] = Convert.ToInt32(textBoxUp.Text);

            g.DrawRectangle(pen, cutter[0], cutter[3], cutter[1] - cutter[0], cutter[2] - cutter[3]);
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
            Point mousePos = canvasBase.PointToClient(MousePosition);

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
                        last_line.Add(new PointF(last_line[0].X, mousePos.X));
                    }
                    else
                    {
                        last_line.Add(mousePos);
                    }

                    g.DrawLine(pen, last_line[0], last_line[1]);
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
            }
            canvasBase.Refresh();
        }
    }
}
