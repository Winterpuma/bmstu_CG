using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApplication2
{
    class MyPoint
    {
        private float x, y;
        Color p_color=Color.Black;

        public MyPoint()
        {
            x = 0;
            y = 0;
            p_color = Color.Black;
        }
        public MyPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.p_color = Color.Black;
        }
        public MyPoint(float x, float y,Color color)
        {
            this.x = x;
            this.y = y;
            this.p_color = color;
        }

        public float X
        {
            set { this.x = value; }
            get { return x; }
        }
        
        public float Y
        {
            set { this.y = value; }
            get { return y; }
        }
        
        public Color color
        {
            set { this.p_color = value; }
            get { return p_color; }
        }

        public PointF P_F
        {
            set
            {
                this.x = value.X;
                this.y = value.Y;
            }
            get { return new PointF(this.x, this.y); }
        }
    }
}
