using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class WuAlgo:BaseDrawer
    {
            private Color CountColor(float c)
            {
                if (c > 1)
                {
                    return Color.Red;
                }
                return  Color.FromArgb((int)(c * 255), drawcolor.R, drawcolor.G, drawcolor.B);
            }
           //function plot(x, y, c) is
            //    plot the pixel at (x, y) with brightness c (where 0 ≤ c ≤ 1)

            // integer part of x
            private int  ipart(float x)
            {
                return (int)(x);
            }

            private int  round(float x)
            {
                return ipart(x);
            }
            
            private float fpart(float z)
            {
                double x=(float)(z);

                  if (x < 0)
                  {
                    return (float)(1 - (x - Math.Floor(x)));   
                  }
                return (float)(x - Math.Floor(x));
            }
            
            private float  rfpart(float x)
            {
                return 1 - fpart(x);
            }

             protected override void draw(ref Bitmap bitmap, PointF pointfrom, PointF pointto)
             {
                 if (IsDegenerate(pointfrom, pointto))
                 {
                     AddPoint(ref bitmap, ref pointfrom, drawcolor);
                     return;
                 }
                 bool steep=Math.Abs(pointto.Y-pointfrom.Y)>Math.Abs(pointto.X-pointfrom.X);

                 float x0=pointfrom.X;
                 float y0=pointfrom.Y;

                 float x1=pointto.X;
                 float y1=pointto.Y;
                 if(steep)
                 {   
                     Swap<float>(ref x0,ref y0);
                     Swap<float>(ref x1,ref y1);  
                 }

                 if (x0 > x1)
                 {                    
                    Swap<float>(ref x0, ref x1);
                    Swap<float>(ref y0,ref  y1);
                 }

                  float dx = x1 - x0;
                  float dy = y1 - y0;
                  float gradient = dy / dx;

                 if(dx==0.0f)
                 {
                     gradient=1.0f;
                 }
                 // handle first endpoint
                int xend = round(x0);
                float yend = y0 + gradient * (xend - x0);
                float xgap = rfpart(x0 + 0.5f);
                int xpxl1 = xend; // this will be used in the main loop
                int ypxl1 = ipart(yend);

                 if(steep)
                 {
                    
                     AddPoint(ref bitmap,  ypxl1, xpxl1, CountColor(rfpart(yend) * xgap));
                     AddPoint(ref bitmap,  ypxl1 + 1, xpxl1, CountColor(fpart(yend) * xgap));
                 }
                 else
                 {
                     AddPoint(ref bitmap,  xpxl1, ypxl1, CountColor(rfpart(yend) * xgap));
                     AddPoint(ref bitmap,  xpxl1, ypxl1 + 1, CountColor(fpart(yend) * xgap));
                 }

                float intery = yend + gradient; // first y-intersection for the main loop
                // handle second endpoint
                xend = round(x1);
                yend = y1 + gradient * (xend - x1);
                xgap = fpart(x1 + 0.5f);
                float xpxl2 = xend; //this will be used in the main loop
                float ypxl2 = ipart(yend);

                 if(steep)
                 {
                      AddPoint(ref bitmap, ypxl2, xpxl2, CountColor(rfpart(yend) * xgap));
                      AddPoint(ref bitmap, ypxl2+1 , xpxl2, CountColor(fpart(yend) * xgap));
                 }
                 else
                 {
                     AddPoint(ref bitmap,  xpxl2, ypxl2, CountColor(rfpart(yend) * xgap));
                     AddPoint(ref bitmap,  xpxl2, ypxl2 + 1, CountColor(fpart(yend) * xgap));
                 }
                 float f_temp = 0f;
                 int x;
                  if(steep)
                  {
                      for ( x = xpxl1 + 1; x < xpxl2; x++)
                      {
                          f_temp = rfpart(intery);
                          AddPoint(ref bitmap,  ipart(intery), x, CountColor(f_temp));
                          AddPoint(ref bitmap,  ipart(intery) + 1, x, CountColor(1-f_temp));

                           intery = intery + gradient;
                      }
                  }
                  else
                  {
                       for( x=xpxl1+1; x< xpxl2; x++)
                        {
                            f_temp = rfpart(intery);
                            AddPoint(ref bitmap,  x, ipart(intery), CountColor(f_temp));
                            AddPoint(ref bitmap,  x, ipart(intery) + 1, CountColor(1-f_temp));
                           intery = intery + gradient;
                           }
                  }
                  AddPoint(ref bitmap, x, ipart(intery), CountColor(f_temp));
                  Answer(new PointF((float)(x), intery ), pointto);

             }

             protected override void draw2(ref Bitmap bitmap, PointF pointfrom, PointF pointto)
             {
                 if (IsDegenerate(pointfrom, pointto))
                 {
                     ///AddPoint(ref bitmap, ref pointfrom, drawcolor);
                     return;
                 }
                 bool steep = Math.Abs(pointto.Y - pointfrom.Y) > Math.Abs(pointto.X - pointfrom.X);

                 float x0 = pointfrom.X;
                 float y0 = pointfrom.Y;

                 float x1 = pointto.X;
                 float y1 = pointto.Y;
                 if (steep)
                 {
                     Swap<float>(ref x0, ref y0);
                     Swap<float>(ref x1, ref y1);
                 }

                 if (x0 > x1)
                 {
                     Swap<float>(ref x0, ref x1);
                     Swap<float>(ref y0, ref  y1);
                 }

                 float dx = x1 - x0;
                 float dy = y1 - y0;
                 float gradient = dy / dx;

                 if (dx == 0.0f)
                 {
                     gradient = 1.0f;
                 }
                 // handle first endpoint
                 int xend = round(x0);
                 float yend = y0 + gradient * (xend - x0);
                 float xgap = rfpart(x0 + 0.5f);
                 int xpxl1 = xend; // this will be used in the main loop
                 int ypxl1 = ipart(yend);

                 if (steep)
                 {

                     //AddPoint(ref bitmap, ypxl1, xpxl1, CountColor(rfpart(yend) * xgap));
                     //AddPoint(ref bitmap, ypxl1 + 1, xpxl1, CountColor(fpart(yend) * xgap));
                 }
                 else
                 {
                     //AddPoint(ref bitmap, xpxl1, ypxl1, CountColor(rfpart(yend) * xgap));
                     //AddPoint(ref bitmap, xpxl1, ypxl1 + 1, CountColor(fpart(yend) * xgap));
                 }

                 float intery = yend + gradient; // first y-intersection for the main loop
                 // handle second endpoint
                 xend = round(x1);
                 yend = y1 + gradient * (xend - x1);
                 xgap = fpart(x1 + 0.5f);
                 float xpxl2 = xend; //this will be used in the main loop
                 float ypxl2 = ipart(yend);

                 if (steep)
                 {
                     //AddPoint(ref bitmap, ypxl2, xpxl2, CountColor(rfpart(yend) * xgap));
                     //AddPoint(ref bitmap, ypxl2 + 1, xpxl2, CountColor(fpart(yend) * xgap));
                 }
                 else
                 {
                     //AddPoint(ref bitmap, xpxl2, ypxl2, CountColor(rfpart(yend) * xgap));
                     //AddPoint(ref bitmap, xpxl2, ypxl2 + 1, CountColor(fpart(yend) * xgap));
                 }
                 float f_temp = 0f;
                 int x;
                 if (steep)
                 {
                     for (x = xpxl1 + 1; x < xpxl2; x++)
                     {
                         f_temp = rfpart(intery);
                         //AddPoint(ref bitmap, ipart(intery), x, CountColor(f_temp));
                         //AddPoint(ref bitmap, ipart(intery) + 1, x, CountColor(1 - f_temp));

                         intery = intery + gradient;
                     }
                 }
                 else
                 {
                     for (x = xpxl1 + 1; x < xpxl2; x++)
                     {
                         f_temp = rfpart(intery);
                         //AddPoint(ref bitmap, x, ipart(intery), CountColor(f_temp));
                         //AddPoint(ref bitmap, x, ipart(intery) + 1, CountColor(1 - f_temp));
                         intery = intery + gradient;
                     }
                 }
                
                 
             }
        
             
    }
}
