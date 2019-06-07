using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_10
{
    class Transformator
    {
        spacing x, y, z;
        Size size;
        int border = 50;

        double scale;//scale_x, scale_y, scale_z;
        
        public Transformator(Size size, spacing x, spacing y, spacing z)
        {
            scale = Math.Min(size.Height, size.Width) / (2 * (x.max - x.min));
        }

        public void Transform(ref double x, ref double y)// ref double z)
        {
            x = (x - this.x.min) * scale + border;
            y = (this.y.max - y) * scale + border;
            //z = (z - this.z.min) * scale + border;
        }
    }
}
