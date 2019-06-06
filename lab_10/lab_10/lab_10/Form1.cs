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
        Graphics g;
        Horizon horizon;
        Pen penDraw;

        public Form1()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
            penDraw = new Pen(Color.Red, 1);
        }

        private double F(double x, double z) => x * x + z * z * z;
        private double FPeaks(double x, double z) => Math.Sin(x) * Math.Cos(z);
        private double FPlane(double x, double z) => x + z;

        private void buttonGo_Click(object sender, EventArgs e)
        {
            canvas.Refresh();
            spacing x = new spacing(10, 100, 10);
            spacing z = new spacing(10, 100, 10);

            horizon = new Horizon(FPeaks, x, z);
            horizon.Draw(g, penDraw, canvas.Size);
            canvas.Update();
        }
    }
}
