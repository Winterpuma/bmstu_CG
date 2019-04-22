using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WindowsFormsApplication2
{
    class Tester
    {
        private PointF centre;
        private double radius;
        private double angle;
        
        private int N;

        public Tester()
        {
            this.centre = new PointF(100,100);
            this.angle = 1;
            this.radius = 100;            
            this.N =100;
        }

        public Tester(Point centre, double radius, double angle,int N)
        {
            this.centre = centre;
            this.angle = angle;
            this.radius = radius;           
            this.N=N;
        }

        public Bitmap Start(int p_wigth, int p_height)
        {
            Bitmap pic_bitmap = new Bitmap(p_wigth, p_height);

            int[] time_array=new int[6];

            Standart alg0 = new Standart();
            CDA alg1 = new CDA();
            BresenhamInt alg2 = new BresenhamInt();
            BresenhamFloat alg3 = new BresenhamFloat();
            BresenhamGradation alg4 = new BresenhamGradation();
            WuAlgo alg5 = new WuAlgo();

            
            time_array[0] = alg0.TestTime(centre, angle, radius, N);
            time_array[1] = alg1.TestTime(centre, angle, radius, N);
            time_array[2] = alg2.TestTime(centre, angle, radius, N);
            time_array[3] = alg3.TestTime(centre, angle, radius, N);
            time_array[4] = alg4.TestTime(centre, angle, radius, N);
            time_array[5] = alg5.TestTime(centre, angle, radius, N);

            int max=(int)(time_array.Max()*1.3);

            PointF[] RecCorner = new PointF[6];
            Size[] SizeCorner = new Size[6];
            int wigth=(int)((p_wigth -8*20)/6);
            int pos = 0;

            for (int i = 0; i < 6; i++)
            {
                SizeCorner[i].Height = time_array[i] *  p_height/max;
                SizeCorner[i].Width = wigth;
                RecCorner[i].X = pos;
                pos += wigth + 20;
                RecCorner[i].Y = p_height - SizeCorner[i].Height;
            }

            var graphics = Graphics.FromImage(pic_bitmap);
            
            Color[] colors = new Color[6];
            colors[0] = Color.Yellow;
            colors[1] = Color.Silver;
            colors[2] = Color.Green;
            colors[3] = Color.Pink;
            colors[4] = Color.Blue;
            colors[5] = Color.Red;
            
            for (int i = 0; i < 6; i++)
            {
                SolidBrush brush = new SolidBrush(colors[i]);       
                graphics.FillRectangle(brush, RecCorner[i].X, RecCorner[i].Y, SizeCorner[i].Width, SizeCorner[i].Height);

            }
            Pen myPen = new Pen(Color.Red, 3);
            Font drawFont = new Font("Times New Roman", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            

            graphics.DrawString("Стандартный \n c установкой точек"+"\n ("+Convert.ToString(time_array[0])+")", drawFont, drawBrush, RecCorner[0].X,RecCorner[0].Y-50);
            graphics.DrawString("ЦДА" + "\n (" + Convert.ToString(time_array[1]) + ")", drawFont, drawBrush, RecCorner[1].X, RecCorner[1].Y - 50);
            graphics.DrawString("Брезенхэм INT" + "\n (" + Convert.ToString(time_array[2]) + ")", drawFont, drawBrush, RecCorner[2].X, RecCorner[2].Y - 50);
            graphics.DrawString("Брезенхэм FLOAT" + "\n (" + Convert.ToString(time_array[3]) + ")", drawFont, drawBrush, RecCorner[3].X,RecCorner[3].Y-50);
            graphics.DrawString(" Брезенхэм c \n устранением \n ступенчатости" + "\n (" + Convert.ToString(time_array[4]) + ")", drawFont, drawBrush, RecCorner[4].X, RecCorner[4].Y - 70);
            graphics.DrawString("Bу" + "\n (" + Convert.ToString(time_array[5]) + ")", drawFont, drawBrush, RecCorner[5].X, RecCorner[5].Y - 50);
            
            return pic_bitmap;
        }

    }
}
