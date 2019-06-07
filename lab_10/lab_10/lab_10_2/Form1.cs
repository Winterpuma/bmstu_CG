using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_10_2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Horizont horizon;

        public Form1()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
        }

        public double f(double x, double z)
        {
            return Math.Sin(x) * Math.Cos(z);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas.Refresh();
            spacing x = new spacing(-2, 2, 0.05);
            spacing z = new spacing(-2, 2, 0.05);

            horizon = new Horizont(canvas.Size, f);
            horizon.HorizonAlgo(x, z, g, 0, 0, 0);
            canvas.Update();
        }
    }
}
