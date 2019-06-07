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
        Bitmap result;
        Graphics g;
        Horizont horizon;
        Pen penDraw;

        int step = 5;

        public Form1()
        {
            InitializeComponent();
            result = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(result);
            penDraw = new Pen(Color.Black, 1);
            canvas.Image = result;
        }
        
        private spacing GetXSpacing()
        {
            spacing x = new spacing();
            x.B = Convert.ToDouble(textBoxXSt.Text);
            x.E = Convert.ToDouble(textBoxXEnd.Text);
            x.D = Convert.ToDouble(textBoxXDelta.Text);
            return x;
        }
        private spacing GetZSpacing()
        {
            spacing z = new spacing();
            z.B = Convert.ToDouble(textBoxYStart.Text);
            z.E = Convert.ToDouble(textBoxYEnd.Text);
            z.D = Convert.ToDouble(textBoxYDelta.Text);
            return z;
        }

        private Func<double, double, double> GetFunction()
        {
            if (radioButton1.Checked)
                return f1;
            else if (radioButton2.Checked)
                return f2;
            else if (radioButton3.Checked)
                return f3;
            else if (radioButton4.Checked)
                return f4;
            else
                return f5;
        }

        private double f1(double x, double z) => (x + z)/2;
        public double f2(double x, double z) => Math.Sin(x) * Math.Cos(z);
        public double f3(double x, double z) => Math.Sin(x) + Math.Cos(z);
        public double f4(double x, double z) => Math.Sqrt(x*x + z*z) - 3;
        public double f5(double x, double z)
        {
            double sX = Math.Sin(x);
            double cZ = Math.Cos(z);
            return sX * sX - cZ * cZ;
        }

        public void Go()
        {
            canvas.Refresh();
            g.Clear(Color.White);
            spacing x = GetXSpacing();
            spacing z = GetZSpacing();

            double ox = Convert.ToDouble(numericUpDownX.Value);
            double oy = Convert.ToDouble(numericUpDownY.Value);
            double oz = Convert.ToDouble(numericUpDownZ.Value);
            var f = GetFunction();

            horizon = new Horizont(penDraw, canvas.Size, f);
            horizon.HorizonAlgo(x, z, g, ox, oy, oz);
            canvas.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDownX.Value = 0;
            numericUpDownY.Value = 0;
            numericUpDownZ.Value = 0;
            Go();
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            Go();
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            Go();
        }

        private void numericUpDownZ_ValueChanged(object sender, EventArgs e)
        {
            Go();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDownX.Value = (numericUpDownX.Value + step) % 360;
            Go();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDownX.Value = (numericUpDownX.Value - step + 360) % 360;
            Go();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDownY.Value = (numericUpDownY.Value + step) % 360;
            Go();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDownY.Value = (numericUpDownY.Value - step + 360) % 360;
            Go();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDownZ.Value = (numericUpDownZ.Value + step) % 360;
            Go();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDownZ.Value = (numericUpDownZ.Value - step + 360) % 360;
            Go();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            step = Convert.ToInt32(numericUpDown1.Value);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog1.Color;
                penDraw.Color = colorDialog1.Color;
            }
        }
    }
}
