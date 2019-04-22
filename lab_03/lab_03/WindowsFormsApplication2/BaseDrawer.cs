using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using System.Diagnostics;

namespace WindowsFormsApplication2
{
    class BaseDrawer
    {
        protected Color drawcolor = Color.Black;
        protected string answer="";

        //0-bitmap and list
        //1-list
        //2-bitmap
        protected int drawflag = 0;

        protected bool IsDegenerate(PointF start, PointF end)
        {
            if (start.X == end.X && start.Y == end.Y)
                return true;
            return false;
        }

       
        protected int AddPoint(ref Bitmap bitmap, float X, float Y, Color color)
        {
            if ((X >= 0) && (X < bitmap.Width) && (Y >= 0) && (Y < bitmap.Height))
            {
                bitmap.SetPixel((int)(X), (int)(Y), color);
            }    
            return 0;
        }

        protected int AddPoint(ref Bitmap bitmap, int X, int Y, Color color)
        {
            if ((X >= 0) && (X < bitmap.Width) && (Y >= 0) && (Y < bitmap.Height))
            {
                bitmap.SetPixel(X, Y, color);
            }
            return 0;
        }

        protected int AddPoint(ref Bitmap bitmap, ref PointF p, Color color)
        {
            if ((p.X >= 0) && (p.X < bitmap.Width) && (p.Y >= 0) && (p.Y < bitmap.Height))
            {
                bitmap.SetPixel((int)(p.X), (int)(p.Y), color);
            }
            return 0;
        }

      
        public Color SetColor
        {
            set { drawcolor = value; }
        }
        public string GetAnswer
        {
            get { return answer; }
        }

        protected void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        protected void Answer(PointF pointended, PointF must_be_finish)
        {
            answer = "Алгоритм пришел в точку ("+pointended.X.ToString() + ";" + pointended.Y.ToString()+")";
            if (Math.Abs(pointended.X - must_be_finish.X)<1 && (Math.Abs(pointended.Y - must_be_finish.Y)<1))
                answer += " \nАлгоритм попал в конечную точку";
            else
                answer += " \nАлгоритм не попал в конечную точку :(";
        }
       
        public string LastPoint
        { 
            get { return answer; }
        }

        protected int Sign(double x)
        {
            if (x == 0)
                return 0;
            else 
                return (int)(x/Math.Abs(x));
        }

        protected virtual void draw(ref Bitmap bitmap, PointF pointfrom, PointF pointto) { }

        protected virtual void draw2(ref Bitmap bitmap, PointF pointfrom, PointF pointto) { }
        
        public void Draw(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            draw(ref bitmap, pointfrom, pointto);
        }


        public void DrawSun(ref Bitmap bitmap, PointF centre, double R, double a)
        {
            float angle = (float)(a / 180 * Math.PI);
            int N = (int)(2 * Math.PI / angle);
            for (float i = 0; i <= 2 * Math.PI - angle; i += angle)
            {
                Draw(ref bitmap, centre, new PointF((float)(centre.X + Math.Cos(i) * R), (float)(centre.Y + Math.Sin(i) * R)));
            }
        }

        public void DrawSun2(ref Bitmap bitmap, PointF centre, double R, double a)
        {
            float angle = (float)(a / 180 * Math.PI);
            int N = (int)(2 * Math.PI / angle);
            for (float i = 0; i <= 2 * Math.PI - angle; i += angle)
            {
                draw2(ref bitmap, centre, new PointF((float)(centre.X + Math.Cos(i) * R), (float)(centre.Y + Math.Sin(i) * R)));
            }
        }

        public int TestTime(PointF centre, double angle, double radius, int N)
        {
            Bitmap bmt2 = new Bitmap((int)(centre.X + 2 * radius), (int)(centre.Y + 2 * radius));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                DrawSun2(ref bmt2, centre, radius, angle);
            }
            sw.Stop();
            return Convert.ToInt32(sw.ElapsedMilliseconds);
        }
    }
}
