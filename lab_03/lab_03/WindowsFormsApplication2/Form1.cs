using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
        }
        
        //Цвет фона линий
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorDialog1.AllowFullOpen = true;
            button6.BackColor = colorDialog1.Color;
            button3.BackColor = colorDialog1.Color;
            ClearBitmap(button6.BackColor);  
        }
        
        //Цвет линий
        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorDialog1.AllowFullOpen = true;
            button4.BackColor = colorDialog1.Color;
        }
        
        //Фон солнца
        private void button6_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorDialog1.AllowFullOpen = true;
            button6.BackColor = colorDialog1.Color;
            button3.BackColor = colorDialog1.Color;
            ClearBitmap(button6.BackColor);            
        }
       
        //Цвет солнца
        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorDialog1.AllowFullOpen = true;
            button5.BackColor = colorDialog1.Color;
        }

        private void ClearBitmap(Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            var graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            pictureBox1.Image = bitmap;

        }

        private int GetLineType(int tab_id)
        {
            if (tab_id == 0)
            {
                //Standart
                if (radioButton1.Checked )
                {
                    return 0;
                }
                //CDA
                if (radioButton2.Checked )
                {
                    return 1;
                }
                //INT
                if (radioButton3.Checked )
                {
                    return 2;
                }
                //FLOAT
                if (radioButton4.Checked )
                {
                    return 3;
                }
                //GRAD
                if (radioButton5.Checked )
                {
                    return 4;
                }
                //WU
                if (radioButton6.Checked )
                {
                    return 5;
                }
                return 0;
            }
            if (tab_id == 1)
            {
                //Standart
                if (radioButton12.Checked)
                {
                    return 0;
                }
                //CDA
                if (radioButton11.Checked)
                {
                    return 1;
                }
                //INT
                if ((radioButton10.Checked))
                {
                    return 2;
                }
                //FLOAT
                if ( (radioButton9.Checked))
                {
                    return 3;
                }
                //GRAD
                if ((radioButton8.Checked))
                {
                    return 4;
                }
                //WU
                if ((radioButton7.Checked))
                {
                    return 5;
                }
                return 0;
            }

            
            return 0;

        }

        private BaseDrawer GetLineObj(int tab_id)
        {
            BaseDrawer obj;
            switch (GetLineType(tab_id))
            {
                case 0: obj = new Standart();
                    break;
                case 1: obj = new CDA();
                    break;
                case 2: obj = new BresenhamInt();
                    break;
                case 3: obj = new BresenhamFloat();
                    break;
                case 4: obj = new BresenhamGradation();
                    break;
                case 5: obj = new WuAlgo();
                    break;
                default:
                    obj=new Standart();
                    break;
            }
            return obj;
        }

        private void GetColor(int tab_id,out Color line, out Color backColor)
        {
            if (tab_id == 0)
            {
                backColor = button3.BackColor;
                line = button4.BackColor;
                return;
            }
            if (tab_id == 1)
            {
                backColor = button6.BackColor;
                line = button5.BackColor;
                return; 
            }
            line = Color.Black;
            backColor = Color.White;
            
        }

        private int GetDataLine(out PointF start, out PointF end)
        {
            float X1, Y1, X2, Y2;
            start = new PointF(0, 0);
            end = new PointF(0, 0);
            try
            {
                X1 = (float)(Convert.ToDouble(textBox1.Text));
                Y1 = (float)(Convert.ToDouble(textBox2.Text));
                X2 = (float)(Convert.ToDouble(textBox3.Text));
                Y2 = (float)(Convert.ToDouble(textBox4.Text));
            }
            catch
            {
                MessageBox.Show("Ошибка в воде точки");
                return 1;
            }
            start = new PointF(X1, Y1);
            end = new PointF(X2, Y2);
            return 0;
        }

        private int GetDataSun(out PointF centre, out double R, out double A)
        {
            float X1, Y1;
            double r, a;
            centre = new PointF(0, 0);
            R = 0;
            A = 0;
            try
            {
                X1 = (float)(Convert.ToDouble(textBox8.Text));
                Y1 = (float)(Convert.ToDouble(textBox7.Text));
                r = Convert.ToDouble(textBox6.Text);
                a = Convert.ToDouble(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в воде точки");
                return 1;
            }
            centre = new PointF(X1, Y1);
            R = r;
            A = a;

            return 0;
        }

        private int GetTestData(out Point centre, out double R, out double A, out int N)
        {
            int X1, Y1;
            double r, a;
            int n;
            centre = new Point(0, 0);
            R = 0;
            A = 0;
            N = 0;
            try
            {
                X1 = (int)(Convert.ToDouble(textBox12.Text));
                Y1 = (int)(Convert.ToDouble(textBox11.Text));
                r = Convert.ToDouble(textBox10.Text);
                a = Convert.ToDouble(textBox9.Text);
                n = Convert.ToInt32(textBox14.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка в воде ");
                return 1;
            }
            centre = new Point(X1, Y1);
            R = r;
            A = a;
            N = n;
            return 0;
        }

        //Нарисовать Солнце
        private void button7_Click(object sender, EventArgs e)
        {
            Color lineColor, backColor;
            GetColor(1, out lineColor, out backColor);

            PointF centre;
            double radius, angle;
            if (GetDataSun(out centre, out radius,out  angle) != 0)
                return;

            BaseDrawer obj= GetLineObj(1);
            obj.SetColor = lineColor;
            obj.DrawSun(ref bitmap, centre, radius, angle);
            pictureBox1.Image = bitmap;
            zoom();
        }

        //Нарисовать линии
        private void button2_Click(object sender, EventArgs e)
        {
            Color lineColor, backColor;
            GetColor(0, out lineColor, out backColor);
            PointF start, end;

            if (GetDataLine(out start, out end) != 0)
                return;

            BaseDrawer obj = GetLineObj(0);
            obj.SetColor = lineColor;
            obj.Draw(ref bitmap, start, end);
            pictureBox1.Image = bitmap;
            zoom();
            //label26.Text = obj.GetAnswer;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button4.BackColor = Color.Black;
            button5.BackColor = Color.Black;

            textBox1.Text = "10";
            textBox2.Text = "10";
            textBox3.Text = "100";
            textBox4.Text = "100";
            textBox5.Text = "2";
            textBox6.Text = "50";
            textBox7.Text = "100";
            textBox8.Text = "100";


            textBox12.Text = "200";
            textBox11.Text = "200";
            textBox10.Text = "100";
            textBox9.Text = "5";
            textBox14.Text = "50";

            prev.Size = pictureBox1.Size;
            prev.Location = new Point(0, 0);
           

            ClearBitmap(Color.White);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button5.BackColor = button6.BackColor;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button4.BackColor = button3.BackColor;
        }


        private Point zoomcentre;
        private float zoomscale;


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int h=pictureBox1.Size.Height;
            int w = pictureBox1.Size.Width;
            if (e.Delta > 1)
            {
                zoomscale += 0.2f * e.Delta;
                Size newSize = new Size((int)(bitmap.Width * zoomscale), (int)(bitmap.Height * zoomscale));
                Bitmap bmp = new Bitmap(bitmap, newSize);

                var graphics = Graphics.FromImage(bmp);

                
            }
            
            if (MouseButtons.Left == e.Button)
            {

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            

        }

        //ZOOM
        /*private void textBox13_TextChanged(object sender, EventArgs e)
        {
            zoom();
        }*/

        private void zoom()
        {
            float zoomFactor = 1f;/*
            if (textBox13.Text == "")
                zoomFactor = 1f;
            else
            {
                zoomFactor = 1f * Convert.ToInt32(textBox13.Text);
            }*/
            try
            {
                if (zoomFactor == 1f)
                {
                    prev.Location = new Point(0, 0);
                }
                Size newSize = new Size((int)(bitmap.Width * zoomFactor), (int)(bitmap.Height * zoomFactor));
                Bitmap bmp = new Bitmap(bitmap, newSize);
                Bitmap bmp2 = bmp.Clone(prev, bmp.PixelFormat);
                bmp.Dispose();                
                pictureBox1.Image = bmp2;
                //bmp2.Dispose();

            }
            catch { };           
        }

        private Rectangle prev;

        private void button8_Click(object sender, EventArgs e)
        {
            if(prev.Location.X>100)
                prev.Location = new Point(prev.Location.X - 100, prev.Location.Y);
            else
                prev.Location = new Point(0, prev.Location.Y);

            zoom();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            prev.Location = new Point(prev.Location.X + 100, prev.Location.Y);
            zoom();
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (prev.Location.Y > 100)
                prev.Location = new Point(prev.Location.X, prev.Location.Y - 100);
            else
                prev.Location = new Point(prev.Location.X, 0);
            zoom();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            prev.Location = new Point(prev.Location.X , prev.Location.Y+100);
            zoom();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Point centre;
            double R, A;
            int N;
            GetTestData(out centre, out R, out  A, out N);
            Tester test = new Tester(centre,R,A,N);
            pictureBox1.Image = test.Start(pictureBox1.Width, pictureBox1.Height);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
