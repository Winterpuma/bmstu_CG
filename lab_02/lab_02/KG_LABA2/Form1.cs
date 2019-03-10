using System;
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
        Graphics g;
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        //Задаем коэффиценты a,b,c
        //поворот=> угол+ центр
        //смешение=> на сколько
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString((int)panel6.Size.Width / 2);
            textBox2.Text = Convert.ToString((int)panel6.Size.Height / 2);

            textBox6.Text = textBox9.Text = Convert.ToString((int)panel6.Size.Width / 2);
            textBox5.Text = textBox8.Text = Convert.ToString((int)panel6.Size.Height / 2);

            textBox3.Text = Convert.ToString(50);
            textBox11.Text = Convert.ToString(100);
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
             * */

            if (e.Button == MouseButtons.Right)
            {
                textBox1.Text = Convert.ToString((int)panel6.Size.Width / 2);
                textBox2.Text = Convert.ToString((int)panel6.Size.Height / 2);

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
            int a, b, c, r;
            try
            {
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox2.Text);
                r = Convert.ToInt32(textBox3.Text);
                c = Convert.ToInt32(textBox11.Text);
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                return;
            }
            if (Math.Abs(c) < r)
            {
                MessageBox.Show("Значение С по модулю должно первышать R");
                return;
            }

            datalist = new DataPack();

            GenerateCircle(datalist, a, b, r);
            GenerateHiperbola(datalist, a, b, r, c);
            GenerateHatching(datalist, a, b, r, c);

            datalist.Draw(g, myPen);
            datalist.PanelAddInfo(panel1);
            memory.Push(datalist);

        }

        //Генерация точек окружности
        private void GenerateCircle(DataPack datalist, float centerX, float centerY, float radius)
        {
            float angle1 = (float)((0 / 180) * Math.PI);                 //
            float angle2 = (float)((360/ 180) * Math.PI);                 // переход из градусов в радианы

            float koef = (float)(Math.PI * 2 / Math.Abs(angle2 - angle1));       //определение  
            float iterations = (float)Math.Round((2 * radius + 5) / koef);       //оптимального количества 
            float delta = (angle2 - angle1) / iterations;                        //итераций
        
            for (int i = 0; i <=iterations; i++)
            {
                float x = centerX + radius * (float)Math.Cos(angle1);
                float y = centerY - radius * (float)Math.Sin(angle1);
                datalist.CircleAddPoint(x, y);
                angle1 += delta;
            }
            float x1 = centerX + radius * (float)Math.Cos(angle1);
            float y1 = centerY - radius * (float)Math.Sin(angle1);
            datalist.CircleAddPoint(x1, y1);
        }

        //Генерация точек гиперболы
        private void GenerateHiperbola(DataPack datalist, float centerX, float centerY, float radius, float c)
        {
            float x1 = 1, y1 = -c / x1;
            datalist.HiperbolaAddPoint(x1+centerX,y1+centerY);
            for (float x2 = 2; x2 < radius * 2; x2+=0.5f)
            {
                float y2 = -c / x2;
                datalist.HiperbolaAddPoint(x2+centerX,y2+centerY);
            }
        }

        //Генерация точек для штириховки
        private void GenerateHatching(DataPack datalist, float centerX, float centerY, float radius, float c)
        {
            for (float x2 = 5; x2 < radius; x2 += radius/10)
            {
                float y2 = -c / x2;
                float y3 = (float)(centerY - Math.Sqrt(radius * radius - x2 * x2));
                if (Math.Abs( y2) < radius)
                    datalist.HatchingAddPoint(x2 + centerX, y2 + centerY,x2 + centerX,y3);
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
            datalist.Draw(g, myPen);


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
            datalist.Draw(g, myPen);
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
            datalist.Draw(g, myPen);

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
            datalist.Draw(g, myPen);
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            firststep();
        }

        private void panel6_Resize(object sender, EventArgs e)
        {
            g = panel6.CreateGraphics();

            //g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel6.Width, panel6.Height);
            datalist.Draw(g, myPen);
        }



    }
}
