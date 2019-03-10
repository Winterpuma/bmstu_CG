using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KG_LABA2
{
    class DataPack
    {
        List<PointF> circle;
        List<PointF> hiperbola;
        List<PointF> hatching; //штриховка
        Control[] ctrls;
       
        

       

        public DataPack()
        {
            circle=new List<PointF>();
            hiperbola=new List<PointF>();
            hatching=new List<PointF>();
           
           

                      
        }

        public void Draw(Graphics DrawingArea, Pen pen)
        {
            DrawCircle(DrawingArea,pen);
            DrawHiperbola(DrawingArea,pen);
            DrawHatching(DrawingArea, pen);
        }

        private void DrawCircle(Graphics DrawingArea, Pen pen)
        {
            int count=circle.Count;
            for(int i=0; i<count-1; i++)
                DrawingArea.DrawLine(pen, circle[i], circle[i+1]);
        }

        private void DrawHiperbola(Graphics DrawingArea, Pen pen)
        {
            int count = hiperbola.Count;
            for (int i = 0; i < count - 1; i++)
                DrawingArea.DrawLine(pen, hiperbola[i], hiperbola[i + 1]);
        }

        private void DrawHatching(Graphics DrawingArea, Pen pen)
        {
            int count = hatching.Count;
            for (int i = 0; i < count - 1; i+=2)
                DrawingArea.DrawLine(pen, hatching[i], hatching[i + 1]);
        }

        public void CircleAddPoint(float x, float y)
        {
            circle.Add(new PointF(x, y));
        }

        public void CircleAddPoint(PointF point)
        {
            circle.Add(point);
        }

        public void HiperbolaAddPoint(float x, float y)
        {
            hiperbola.Add(new PointF(x, y));
        }

        public void HiperbolaAddPoint(PointF point)
        {
            hiperbola.Add(point);
        }

        public void HatchingAddPoint(float x1, float y1, float x2, float y2)
        {
            hatching.Add(new PointF(x1, y1));
            hatching.Add(new PointF(x2, y2));
        }

        public void HatchingAddPoint(PointF point)
        {
            hatching.Add(point);
        }

        public void PanelAddInfo(Panel panel)
        {
                ctrls = new Control[panel.Controls.Count];
                panel.Controls.CopyTo(ctrls,0);
            
            
        }
        
        public Control[] PanelRecovery()
        {
            //panel1.Controls.AddRange(ctrls.ToArray());
            return ctrls;
        }
        

        public DataPack turning(double angle,PointF centre)
        {
            DataPack new_point_List = new DataPack();

            int count = circle.Count;
            for (int i = 0; i < count; i++)
                new_point_List.CircleAddPoint(turn(circle[i],angle,centre));

            count = hiperbola.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HiperbolaAddPoint(turn(hiperbola[i], angle, centre));

            count = hatching.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HatchingAddPoint(turn(hatching[i], angle, centre));

            return new_point_List;
        }

        private PointF turn(PointF p_old, double angle, PointF centre)
        {
            double x = centre.X + (p_old.X - centre.X) * Math.Cos(angle) + (p_old.Y - centre.Y) * Math.Sin(angle);
            double y = centre.Y - (p_old.X - centre.X) * Math.Sin(angle) + (p_old.Y - centre.Y) * Math.Cos(angle);
            return new PointF((float)x, (float)y);

        }

        public DataPack transfering(PointF delta)
        {
            DataPack new_point_List = new DataPack();

            int count = circle.Count;
            for (int i = 0; i < count; i++)
                new_point_List.CircleAddPoint(transfer(circle[i],delta));

            count = hiperbola.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HiperbolaAddPoint(transfer(hiperbola[i],delta));

            count = hatching.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HatchingAddPoint(transfer(hatching[i], delta));

            return new_point_List;
        }

        private PointF transfer(PointF p_old,PointF delta)
        {
            return new PointF(p_old.X + delta.X, p_old.Y + delta.Y);
        }

        public DataPack zooming(PointF centre, PointF zoomK)
        {
            DataPack new_point_List = new DataPack();

            int count = circle.Count;
            for (int i = 0; i < count; i++)
                new_point_List.CircleAddPoint(zoom(circle[i], centre, zoomK));

            count = hiperbola.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HiperbolaAddPoint(zoom(hiperbola[i], centre, zoomK));

            count = hatching.Count;
            for (int i = 0; i < count; i++)
                new_point_List.HatchingAddPoint(zoom(hatching[i], centre, zoomK));

            return new_point_List;
        }

        private PointF zoom(PointF p_old, PointF centre, PointF zoomk)
        {
            double x = zoomk.X * p_old.X + centre.X * (1 - zoomk.X);
            double y = zoomk.Y * p_old.Y + centre.Y * (1 - zoomk.Y);
            return new PointF((float)x, (float)y);
        }






    }
}
