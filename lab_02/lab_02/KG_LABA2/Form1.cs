﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_LABA2
{
    public partial class Form1 : Form
    {
        DataPack datalist;
        Stack<DataPack> memory;

        public delegate void EventHandler(Object sender, EventArgs e);

        Pen myPen = new Pen(Color.Red, 2);
        int scale = 20;
        
        Graphics g;
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Brush filling = Brushes.White;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(3);
            textBox2.Text = Convert.ToString(2);
            textBox3.Text = Convert.ToString(400);
            textBox11.Text = Convert.ToString(300);

            textBox6.Text = textBox9.Text = Convert.ToString((int)panel6.Size.Width / 2);
            textBox5.Text = textBox8.Text = Convert.ToString((int)panel6.Size.Height / 2);

            textBox4.Text = Convert.ToString(0);
            textBox10.Text = Convert.ToString(1);
            textBox7.Text = Convert.ToString(1);
            textBox13.Text = Convert.ToString(0);
            textBox14.Text = Convert.ToString(0);

            memory = new Stack<DataPack>();

            //button5.Visible = false;
            button6.Visible = false;
            g = panel6.CreateGraphics();
            firststep();

        }

       

        private void panel1_Resize(object sender, EventArgs e)
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
            /*textBox1.Text = Convert.ToString(e.Location.X);
            textBox2.Text = Convert.ToString(e.Location.Y);
            textBox3.Text = Convert.ToString(50);
            textBox11.Text = Convert.ToString(100);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);

            circle(e.Location.X,  e.Location.Y, 50);
             */

            if (e.Button == MouseButtons.Right)
            {
                textBox6.Text = textBox9.Text = Convert.ToString((int)panel6.Size.Width / 2);
                textBox5.Text = textBox8.Text = Convert.ToString((int)panel6.Size.Height / 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firststep();
        }

        private void firststep()
        {

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            int a, b, w, h;
            float center_x = panel6.Width / 2;
            float center_y = panel6.Height / 2;
            
            try
            {
                a = Convert.ToInt32(textBox2.Text);
                b = Convert.ToInt32(textBox1.Text);
                w = Convert.ToInt32(textBox3.Text);
                h = Convert.ToInt32(textBox11.Text);
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                return;
            }
            /*if (Math.Abs(c) < r)
            {
                MessageBox.Show("Значение С по модулю должно первышать R");
                return;
            }*/

            datalist = new DataPack();
            
            GenerateCardioid(datalist, center_x, center_y, scale, a, b);
            GenerateRect(datalist, center_x, center_y, w, h);
            GenerateHatching(datalist, datalist.GetRectMin(), datalist.GetRectMax());

            datalist.Draw(g, myPen, filling);
            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);

        }

        private void GenerateCardioid(DataPack datalist, float centerX, float centerY, float radius, int a, int b)
        {
            int sum = a + b;
            double x, y;
            double pi4 = Math.PI * 4;

            for (double t = 0; t < pi4; t += 0.25)
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
        
        //Генерация точек для штириховки
        private void GenerateHatching(DataPack datalist, PointF min, PointF max)
        {
            float x1, y1;
            float x2, y2;
            float delta;
            for (int i = 0; i < Math.Max((max.X - min.X), (max.Y - min.Y))*2; i += 40)
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

        //поворот
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
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);


        }

        //перенос
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
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }

        //масштабирование
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
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);

        }

        //Проверка ввода
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
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            firststep();
        }

        private void panel6_Resize(object sender, EventArgs e)
        {
            g = panel6.CreateGraphics();

            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen, filling);
        }



    }
}
