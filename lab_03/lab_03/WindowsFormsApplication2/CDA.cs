using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApplication2
{
    class CDA:BaseDrawer
    {
        
        protected override void draw(ref Bitmap bitmap, PointF pointfrom, PointF pointto)
        {
            if (IsDegenerate(pointfrom, pointto))
            {
                AddPoint(ref bitmap,  ref pointfrom, drawcolor);
               
                return;
            }

            float dx = pointto.X - pointfrom.X;
            float dy = pointto.Y - pointfrom.Y;
            float lx = Math.Abs(dx);
            float ly = Math.Abs(dy);

            float l;
            if(lx > ly)
                l = lx;
            else
                l = ly;

            dx /= l;
            dy /= l;

            float x = pointfrom.X;
            float y = pointfrom.Y;
            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for(int i = 1; i < l + 1; i++) {
                //AddPoint(ref bitmap,  ref calculated, drawcolor);  
                AddPoint(ref bitmap, Convert.ToInt32(x), Convert.ToInt32(y), drawcolor);
                x += dx;
                y += dy;
            }
            AddPoint(ref bitmap, Convert.ToInt32(x), Convert.ToInt32(y), drawcolor);
            //Answer(calculated, pointto);
            return;
        }

        protected override void draw2(ref Bitmap bitmap, PointF pointfrom, PointF pointto)
        {   
            if (IsDegenerate(pointfrom, pointto))
            {
                return;
            }

            float dx = pointto.X - pointfrom.X;
            float dy = pointto.Y - pointfrom.Y;
            float lx = Math.Abs(dx);
            float ly = Math.Abs(dy);

            float l;
            if (lx > ly)
                l = lx;
            else
                l = ly;

            dx /= l;
            dy /= l;

            PointF calculated = new PointF(pointfrom.X, pointfrom.Y);
            for (int i = 1; i < l + 1; i++)
            {
                calculated.X += dx;
                calculated.Y += dy;
            }
            
            return;
        }
    }
}
