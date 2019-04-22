using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class BresenhamFloat:BaseDrawer
    {
       
        protected override void draw(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            if (IsDegenerate(pointfrom, pointto))
            {
                AddPoint(ref bitmap, ref pointfrom, drawcolor);
               
                return;
            }

            float dx = Math.Abs(pointto.X - pointfrom.X);
            float dy = Math.Abs(pointto.Y - pointfrom.Y);
            float stepx = Sign(pointto.X - pointfrom.X);
            float stepy = Sign(pointto.Y - pointfrom.Y);
            float m = dy / dx;

            float flag;
            if (dy > dx)
            {
                Swap<float>(ref dx, ref dy);
                m = 1 / m;
                flag = 1;
            }
            else
                flag = 0;

            float f = m - 0.5f;
            

            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for (int i = 0; i < dx; i++)
            {
                AddPoint(ref bitmap,  ref calculated, drawcolor);
                

                if (f >= 0)
                {
                    if (flag == 1)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    f -= 1;                    
                }
                if (f < 0)
                {
                    if (flag == 1)
                        calculated.Y += stepy;
                    else
                        calculated.X += stepx;

                }                
                f += m;
            }
            AddPoint(ref bitmap, ref calculated, drawcolor);
            Answer(calculated, pointto);
        }


        protected override void draw2(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            if (IsDegenerate(pointfrom, pointto))
            {
                

                return;
            }

            float dx = Math.Abs(pointto.X - pointfrom.X);
            float dy = Math.Abs(pointto.Y - pointfrom.Y);
            float stepx = Sign(pointto.X - pointfrom.X);
            float stepy = Sign(pointto.Y - pointfrom.Y);
            float m = dy / dx;

            float flag;
            if (dy > dx)
            {
                Swap<float>(ref dx, ref dy);
                m = 1 / m;
                flag = 1;
            }
            else
                flag = 0;

            float f = m - 0.5f;


            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for (int i = 0; i < dx; i++)
            {
                if (f >= 0)
                {
                    if (flag == 1)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    f -= 1;
                }
                if (f < 0)
                {
                    if (flag == 1)
                        calculated.Y += stepy;
                    else
                        calculated.X += stepx;

                }
                f += m;
            }
           
        }
    }
}
