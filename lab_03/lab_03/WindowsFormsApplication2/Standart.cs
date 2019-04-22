using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class Standart:BaseDrawer
    {
        protected override void draw(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            Pen pen = new Pen(drawcolor, 1);
            var graphics = Graphics.FromImage(bitmap);
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            graphics.DrawLine(pen, pointfrom, pointto);
            graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            Answer(pointto, pointto);

        }

        protected override void draw2(ref Bitmap bitmap,  PointF pointfrom, PointF pointto)
        {
            Pen pen = new Pen(drawcolor, 1);
            var graphics = Graphics.FromImage(bitmap);
            //graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Flush);
            //graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            //graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            graphics.DrawLine(pen, pointfrom, pointto);
            //graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            //
           
        }
      
        
    }
}