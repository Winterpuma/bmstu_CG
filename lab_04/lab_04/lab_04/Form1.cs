using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_04
{
    public partial class Form1 : Form
    {
        Bitmap result;
        Graphics g;
        Pen penDraw;

        public Form1()
        {
            InitializeComponent();
            result = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(result);
            penDraw = new Pen(Color.Black, 1);
            canvas.Image = result;

            Canonical.drawCircle(result, new Point(250, 250), 50, Color.Black);
            Canonical.DrawEllipse(result, new Point(250, 250), 100, 50, Color.Black);

            Parametric.DrawCircle(result, new Point(450, 250), 50, Color.Black);
            Parametric.DrawEllipse(result, new Point(450, 250), 100, 50, Color.Black);
            canvas.Update();
            canvas.Refresh();

        }
    }
}
