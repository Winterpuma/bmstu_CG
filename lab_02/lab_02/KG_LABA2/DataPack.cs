using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab_02
{
    class DataPack
    {
        Control[] ctrls;

        List<PointF> cardioid;
        List<PointF> rectangle;
        List<PointF> hatching; //штриховка
        

        public DataPack()
        {
            cardioid = new List<PointF>();
            rectangle = new List<PointF>();
            hatching = new List<PointF>();
        }

        public void Draw(Graphics DrawingArea, Pen pen, Brush brush)
        {
            DrawHatching(DrawingArea, pen);
            DrawingArea.FillPolygon(brush, cardioid.ToArray(), System.Drawing.Drawing2D.FillMode.Winding);
            DrawCardioid(DrawingArea, pen);
            DrawingArea.DrawPolygon(pen, rectangle.ToArray());
        }

        private void DrawCardioid(Graphics DrawingArea, Pen pen)
        {
            for (int i = 0; i < cardioid.Count - 1; i++)
                DrawingArea.DrawLine(pen, cardioid[i], cardioid[i + 1]);
        }
        
        private void DrawHatching(Graphics DrawingArea, Pen pen)
        {
            int count = hatching.Count;
            for (int i = 0; i < count - 1; i += 2)
                DrawingArea.DrawLine(pen, hatching[i], hatching[i + 1]);
        }

        public void CardioidAddPoint(float x, float y)
        {
            cardioid.Add(new PointF(x, y));
        }

        public void CardioidAddPoint(PointF point)
        {
            cardioid.Add(point);
        }

        public void RectangleAddPoint(float x, float y)
        {
            rectangle.Add(new PointF(x, y));
        }
        
        public void HatchingAddPoint(float x1, float y1, float x2, float y2)
        {
            hatching.Add(new PointF(x1, y1));
            hatching.Add(new PointF(x2, y2));
        }
        public void HatchingAddPoint(float x1, float y1)
        {
            hatching.Add(new PointF(x1, y1));
        }

        public void HatchingAddPoint(PointF point)
        {
            hatching.Add(point);
        }

        public PointF GetRectMin()
        {
            return rectangle[0];
        }

        public PointF GetRectMax()
        {
            return rectangle[2];
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
        
        public DataPack turning(double angle,PointF center)
        {
            DataPack new_point_List = new DataPack();
            new_point_List.cardioid = TurnListOfPoints(cardioid, angle, center);
            new_point_List.rectangle = TurnListOfPoints(rectangle, angle, center);
            new_point_List.hatching = TurnListOfPoints(hatching, angle, center);
            return new_point_List;
        }

        public List<PointF> TurnListOfPoints(List<PointF> list, double angle, PointF center)
        {
            List<PointF> new_list = new List<PointF>();
            for (int i = 0; i < list.Count; i++)
                new_list.Add(Turn(list[i], angle, center));
            return new_list;
        }

        private PointF Turn(PointF p_old, double angle, PointF centre)
        {
            double x = centre.X + (p_old.X - centre.X) * Math.Cos(angle) + (p_old.Y - centre.Y) * Math.Sin(angle);
            double y = centre.Y - (p_old.X - centre.X) * Math.Sin(angle) + (p_old.Y - centre.Y) * Math.Cos(angle);
            return new PointF((float)x, (float)y);
        }

        public DataPack transfering(PointF delta)
        {
            DataPack new_point_List = new DataPack();
            new_point_List.cardioid = TransferListOfPoints(cardioid, delta);
            new_point_List.rectangle = TransferListOfPoints(rectangle, delta);
            new_point_List.hatching = TransferListOfPoints(hatching, delta);
            return new_point_List;
        }

        public List<PointF> TransferListOfPoints(List<PointF> list, PointF delta)
        {
            List<PointF> new_list = new List<PointF>();
            for (int i = 0; i < list.Count; i++)
                new_list.Add(Transfer(list[i], delta));
            return new_list;
        }

        private PointF Transfer(PointF p_old,PointF delta)
        {
            return new PointF(p_old.X + delta.X, p_old.Y + delta.Y);
        }

        public DataPack zooming(PointF center, PointF zoomK)
        {
            DataPack new_point_List = new DataPack();
            new_point_List.cardioid = ZoomListOfPoints(cardioid, center, zoomK);
            new_point_List.rectangle = ZoomListOfPoints(rectangle, center, zoomK);
            new_point_List.hatching = ZoomListOfPoints(hatching, center, zoomK);
            return new_point_List;
        }
        public List<PointF> ZoomListOfPoints(List<PointF> list, PointF center, PointF zoomk)
        {
            List<PointF> new_list = new List<PointF>();
            for (int i = 0; i < list.Count; i++)
                new_list.Add(Zoom(list[i], center, zoomk));
            return new_list;
        }

        private PointF Zoom(PointF p_old, PointF center, PointF zoomk)
        {
            double x = zoomk.X * p_old.X + center.X * (1 - zoomk.X);
            double y = zoomk.Y * p_old.Y + center.Y * (1 - zoomk.Y);
            return new PointF((float)x, (float)y);
        }
    }
}
