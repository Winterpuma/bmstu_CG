using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class BresenhamInt:BaseDrawer
    {
       

        protected override void draw(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            if (IsDegenerate(pointfrom, pointto))
            {
                AddPoint(ref bitmap,  ref pointfrom, drawcolor);               
                return;
            }

            int dx =(int)( Math.Abs(pointto.X - pointfrom.X));
            int dy = (int)(Math.Abs(pointto.Y - pointfrom.Y));
            int stepx = Sign(pointto.X - pointfrom.X);
            int stepy = Sign(pointto.Y - pointfrom.Y);
            //double m = dy / dx;

            int flag;
            if (dy > dx)
            {
                Swap<int>(ref dx, ref dy);
                //m = 1 / m;
                flag = 1;
            }
            else
                flag = 0;
            //double f = m - 0.5;
            int f1 = 2 * dy - dx;
            
            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for (int i = 0; i < dx; i++)
            {
                AddPoint(ref bitmap,  ref calculated, drawcolor);               

                if (f1 >= 0)
                {
                    if (flag == 1)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    //f -= 1;
                    f1 -= 2 * dx;
                }
                if (f1 < 0)
                {
                    if (flag == 1)
                        calculated.Y += stepy;
                    else
                        calculated.X += stepx;

                }
                f1 += 2 * dy;
                //f += m;
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

            int dx = (int)(Math.Abs(pointto.X - pointfrom.X));
            int dy = (int)(Math.Abs(pointto.Y - pointfrom.Y));
            int stepx = Sign(pointto.X - pointfrom.X);
            int stepy = Sign(pointto.Y - pointfrom.Y);
            //double m = dy / dx;

            int flag;
            if (dy > dx)
            {
                Swap<int>(ref dx, ref dy);
                //m = 1 / m;
                flag = 1;
            }
            else
                flag = 0;
            //double f = m - 0.5;
            int f1 = 2 * dy - dx;

            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for (int i = 0; i < dx; i++)
            {
                //AddPoint(ref bitmap, ref list, ref calculated, drawcolor);

                if (f1 >= 0)
                {
                    if (flag == 1)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    //f -= 1;
                    f1 -= 2 * dx;
                }
                if (f1 < 0)
                {
                    if (flag == 1)
                        calculated.Y += stepy;
                    else
                        calculated.X += stepx;

                }
                f1 += 2 * dy;
                //f += m;
            }
           
        }
    }
}
