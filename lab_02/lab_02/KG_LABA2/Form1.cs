using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_02
{
    public partial class Form1 : Form
    {
        DataPack datalist;
        Stack<DataPack> memory;

        public delegate void EventHandler(Object sender, EventArgs e);

        //Pen myPen = new Pen(Color.PaleVioletRed, 2); 
        Pen myPen = new Pen(Color.FromArgb(115, 113, 142), 2);
        int scale = 20;
        
        Graphics g;
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Brush filling;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(3); //b
            textBox2.Text = Convert.ToString(2); //a
            textBox3.Text = Convert.ToString(400); //h
            textBox11.Text = Convert.ToString(300); //w
            textBox12.Text = Convert.ToString(40); //step

            textBox6.Text = textBox9.Text = Convert.ToString((int)panel6.Size.Width / 2);
            textBox5.Text = textBox8.Text = Convert.ToString((int)panel6.Size.Height / 2);

            textBox4.Text = Convert.ToString(0);
            textBox10.Text = Convert.ToString(1);
            textBox7.Text = Convert.ToString(1);
            textBox13.Text = Convert.ToString(0);
            textBox14.Text = Convert.ToString(0);
            
            label15.Text = null;

            memory = new Stack<DataPack>();
            
            filling = new SolidBrush(panel6.BackColor);
            g = panel6.CreateGraphics();
        }
        
        private void panel6_Resize(object sender, EventArgs e)
        {
            g = panel6.CreateGraphics();
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            label15.Text = e.Location.ToString();
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.Text = textBox9.Text = e.Location.X.ToString();
            textBox5.Text = textBox8.Text = e.Location.Y.ToString();

            if (e.Button == MouseButtons.Right)
            {
                textBox6.Text = textBox9.Text = Convert.ToString((int)panel6.Size.Width / 2);
                textBox5.Text = textBox8.Text = Convert.ToString((int)panel6.Size.Height / 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, w, h, step;
            float center_x = panel6.Width / 2;
            float center_y = panel6.Height / 2;
            
            try
            {
                a = Convert.ToInt32(textBox2.Text);
                b = Convert.ToInt32(textBox1.Text);
                w = Convert.ToInt32(textBox3.Text);
                h = Convert.ToInt32(textBox11.Text);
                step = Convert.ToInt32(textBox12.Text);
            }
            catch
            {
                MessageBox.Show("Некорректные данные.\nНачальные параметры должны быть целыми положительными числами.", "Ошибка");
                return;
            }
            if (IsDataWrong(a, b, w, h, step))
                return;
            
            datalist = new DataPack();
            
            GenerateCardioid(datalist, center_x, center_y, scale, a, b);
            GenerateRect(datalist, center_x, center_y, w, h);
            GenerateHatching(datalist, datalist.GetRectMin(), datalist.GetRectMax(), step);

            g.FillRectangle(filling, 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);
        }
        
        #region Generate coords
        private void GenerateCardioid(DataPack datalist, float centerX, float centerY, float radius, int a, int b)
        {
            int sum = a + b;
            double x, y;
            double pi4 = Math.PI * 4;

            for (double t = 0; t < pi4; t += 0.10)
            {
                x = centerX + radius * (sum * Math.Cos(t) - a * Math.Cos(sum * (t / a)));
                y = centerY - radius * (sum * Math.Sin(t) - a * Math.Sin(sum * (t / a)));
                datalist.CardioidAddPoint((float)x, (float)y);
            }
        }

        private void GenerateRect(DataPack datalist, float centerX, float centerY, float width, float height)
        {
            float w = width / 2;
            float h = height / 2;
            datalist.RectangleAddPoint(centerX - w, centerY - h);
            datalist.RectangleAddPoint(centerX + w, centerY - h);
            datalist.RectangleAddPoint(centerX + w, centerY + h);
            datalist.RectangleAddPoint(centerX - w, centerY + h);
        }
        
        private void GenerateHatching(DataPack datalist, PointF min, PointF max, int step)
        {
            float x1, y1;
            float x2, y2;
            float delta;
            for (int i = 0; i < Math.Max((max.X - min.X), (max.Y - min.Y))*2; i += step)
            {
                delta = min.Y + i - max.Y;
                if (delta > 0)
                {
                    x1 = min.X + delta;
                    y1 = max.Y;
                }
                else
                {
                    x1 = min.X;
                    y1 = min.Y + i;
                }

                delta = min.X + i - max.X;
                if (delta > 0)
                {
                    x2 = max.X;
                    y2 = min.Y + delta;
                }
                else
                {
                    x2 = min.X + i;
                    y2 = min.Y;
                }
                if (x1 < max.X)
                    datalist.HatchingAddPoint(x1, y1, x2, y2);
            }
        }
        #endregion

        #region Transformations
        //turn
        private void button2_Click(object sender, EventArgs e)
        {
            float x, y;
            x = y = 0f;
            if ((getFloat(textBox6, ref x) == 1) || (getFloat(textBox5, ref y) == 1))
                return;

            PointF centre = new PointF(x, y);
            double angle=0;
            try
            {
                textBox4.Text = textBox4.Text.Replace('.', ',');
                angle = Convert.ToDouble(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в формате данных.");
                return;
            }
            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);
            datalist = datalist.turning(angle*Math.PI/180, centre);
            g.FillRectangle(filling, 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }

        //transfer
        private void button4_Click(object sender, EventArgs e)
        {
            float x, y;
            x = y = 0f;
            if ((getFloat(textBox14, ref x) == 1) || (getFloat(textBox13, ref y) == 1))
                return;

            PointF delta = new PointF(x, y);
            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);
            datalist = datalist.transfering(delta);
            g.FillRectangle(filling, 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }

        //scale
        private void button3_Click(object sender, EventArgs e)
        {
            float x,y;
            x = y = 0f;
            if((getFloat(textBox9,ref x)==1) || (getFloat(textBox8,ref y)==1))
                return;
            PointF centre = new PointF(x, y);

            if ((getFloat(textBox10, ref x) == 1) || (getFloat(textBox7, ref y) == 1))
                return;
            PointF zoomK = new PointF(x,y);

            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);
            datalist = datalist.zooming(centre,zoomK);
            g.FillRectangle(filling, 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }
        #endregion

        #region Check input
        private float getFloat(TextBox tb,ref float rez)
        {
            double val = 0;
            try
            {
                tb.Text=tb.Text.Replace('.', ',');
                val = Convert.ToDouble(tb.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в формате данных.");
                return 1;
            }
            rez = (float)val;
            return 0;
        }

        private bool IsDataWrong(int a, int b, int w, int h, int step)
        {
            if (a <= 0 || b <= 0 || w <= 0 || h <= 0 || step <= 0)
            {
                MessageBox.Show("Некорректные данные.\nНачальные параметры должны быть целыми числами больше нуля.", "Ошибка");
                return true;
            }
            return false;
        }

        #endregion

        //****Step back****
        private void button5_Click(object sender, EventArgs e)
        {
            if (memory.Count == 0)
            {
                MessageBox.Show("Операций не найдено");
                return;
            }
            datalist = memory.Pop();
            //panel1.Controls.Clear();
            //panel1.Controls.AddRange(datalist.PanelRecovery());
            g.FillRectangle(filling, 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }
    }
}
