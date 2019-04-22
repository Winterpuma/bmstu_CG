using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class BresenhamGradation:BaseDrawer
    {
        private int I = 255;

        protected override void draw(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            double f = I;
            if (IsDegenerate(pointfrom, pointto))
            {
                AddPoint(ref bitmap, ref pointfrom, drawcolor);
               
                return;
            }

            float dx = Math.Abs(pointto.X - pointfrom.X);
            float dy = Math.Abs(pointto.Y - pointfrom.Y);
            float stepx = Sign(pointto.X - pointfrom.X);
            float stepy = Sign(pointto.Y - pointfrom.Y);
            double m = dy / dx;
            int flag;
            if (m > 1)
            {
                Swap<float>(ref dx, ref dy);               
                m = 1 / m;
                flag = 1;
            }
            else
            {
                flag = 0;    
            }
            
            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            f = I / 2;           
            m *= I;
            double W = I - m;

            Color color=Color.FromArgb((int)(f / I * 255),  drawcolor.R,  drawcolor.G,  drawcolor.B);
            AddPoint(ref bitmap, ref pointfrom, color);
            

            for (int i = 0; i < dx; i++)
            {
                if (f <= W)
                {
                    if (flag == 0)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    f += m;
                }
                else
                {
                    calculated.X += stepx;
                    calculated.Y += stepy;
                    f -= W;
                }

                double C = 1- f / I;              
                color=Color.FromArgb((int)(C * 255),  drawcolor.R,  drawcolor.G,  drawcolor.B);
                AddPoint(ref bitmap,ref calculated, color);               
            }
           
            Answer(calculated, pointto);
        }


        protected override void draw2(ref Bitmap bitmap, PointF pointfrom, PointF pointto)
        {
            double f = I;
            if (IsDegenerate(pointfrom, pointto))
            {
                return;
            }

            float dx = Math.Abs(pointto.X - pointfrom.X);
            float dy = Math.Abs(pointto.Y - pointfrom.Y);
            float stepx = Sign(pointto.X - pointfrom.X);
            float stepy = Sign(pointto.Y - pointfrom.Y);
            double m = dy / dx;
            int flag;
            if (m > 1)
            {
                Swap<float>(ref dx, ref dy);
                m = 1 / m;
                flag = 1;
            }
            else
            {
                flag = 0;
            }

            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            f = I / 2;
            m *= I;
            double W = I - m;

            Color color = Color.FromArgb((int)(f / I * 255), drawcolor.R, drawcolor.G, drawcolor.B);
           

            for (int i = 0; i < dx; i++)
            {
                if (f <= W)
                {
                    if (flag == 0)
                        calculated.X += stepx;
                    else
                        calculated.Y += stepy;
                    f += m;
                }
                else
                {
                    calculated.X += stepx;
                    calculated.Y += stepy;
                    f -= W;
                }

                double C = 1 - f / I;
                color = Color.FromArgb((int)(C * 255), drawcolor.R, drawcolor.G, drawcolor.B);
               
            }

            
        }
    }
}
