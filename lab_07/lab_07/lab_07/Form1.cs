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
        List<PointF[]> lines;
        int[] cutter;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;
        Pen pen; // lines
        Pen pen_choosen;

        public Form1()
        {
            InitializeComponent();

            lines = new List<PointF[]>();
            lines.Add(new PointF[2]);
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

            if (p.X < cutter[0])
                sum += 8;
            if (p.X > cutter[1])
                sum += 4;
            if (p.Y < cutter[2])
                sum += 2;
            if (p.Y > cutter[3])
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
                    g.DrawLine(pen_choosen, a, b);
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

    }
}
