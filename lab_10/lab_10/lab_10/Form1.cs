using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_10
{
    public partial class Form1 : Form
    {
        
        Bitmap img;
        Horizon horizon;
        Pen penCutter;

        public Form1()
        {
            InitializeComponent();
            img = new Bitmap(canvas.Width, canvas.Height);
        }

        private double F(double x, double z) => x * x + z * z * z;
        private double FPeaks(double x, double z) => Math.Sin(x) * Math.Cos(z);
        private double FPlane(double x, double z) => x + z;

        private void buttonGo_Click(object sender, EventArgs e)
        {
            spacing x = new spacing(-1, 1, 0.02);
            spacing z = new spacing(-1, 1, 0.02);

            horizon = new Horizon(FPlane, x, z);
        }
    }
}
