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

        Color cBackground;
        Color cDraw;

        void h(Point center, int r1, int r2, Color c1, Color c2)
        {
            Parametric.DrawCircle(result, center, r1, c1);
            Parametric.DrawEllipse(result, center, r1, r2, c1);

            Canonical.DrawCircle(result, center, r1, c2);
            Canonical.DrawEllipse(result, center, r1, r2, c2);
        }

        void h2(Point center, int r1, int r2, Color c1, Color c2)
        {
            Canonical.DrawCircle(result, center, r1, c2);
            Canonical.DrawEllipse(result, center, r1, r2, c2);
            Parametric.DrawCircle(result, center, r1, c1);
            Parametric.DrawEllipse(result, center, r1, r2, c1);

        }

        public Form1()
        {
            InitializeComponent();
            result = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(result);
            penDraw = new Pen(Color.Black, 1);
            canvas.Image = result;
            cBackground = Color.White;
            cDraw = Color.Black;
            buttonChooseColor.BackColor = cDraw;

            textBoxX.Text = (canvas.Width / 2).ToString();
            textBoxY.Text = (canvas.Height / 2).ToString();
            
            /*h(new Point(250, 250), 100, 70, Color.Black, Color.White);
            h(new Point(500, 250), 70, 100, Color.Black, Color.White);
            h2(new Point(250, 500), 100, 70, Color.White, Color.Black);
            h2(new Point(500, 500), 70, 100, Color.White, Color.Black);

            //canvas.Update();
            //canvas.Refresh();*/
        }

        private void Draw(Point drawCenter, int Rx, int Ry = 1, int dRx = 0, int n = 1)
        {
            int dRy = Ry * dRx / Rx;
            for (int i = 0; i < n; i++)
            {
                Rx += dRx;
                Ry += dRy;
                if (radioButtonStandard.Checked)
                {
                    if (radioButtonCircle.Checked)
                        g.DrawEllipse(penDraw, drawCenter.X - Rx / 2, drawCenter.Y - Rx / 2, Rx, Rx);
                    else if (radioButtonEllipse.Checked)
                        g.DrawEllipse(penDraw, drawCenter.X - Rx / 2, drawCenter.Y - Ry / 2, Rx, Ry);
                }
                else if (radioButtonCanonic.Checked)
                {
                    if (radioButtonCircle.Checked)
                        Canonical.DrawCircle(result, drawCenter, Rx, cDraw);
                    else if (radioButtonEllipse.Checked)
                        Canonical.DrawEllipse(result, drawCenter, Rx, Ry, cDraw);
                }
                else if (radioButtonParametric.Checked)
                {
                    if (radioButtonCircle.Checked)
                        Parametric.DrawCircle(result, drawCenter, Rx, cDraw);
                    else if (radioButtonEllipse.Checked)
                        Parametric.DrawEllipse(result, drawCenter, Rx, Ry, cDraw);
                }
                else if (radioButtonMiddle.Checked)
                {
                    if (radioButtonCircle.Checked)
                        MiddleDot.DrawCircle(result, drawCenter, Rx, cDraw);
                    else if (radioButtonEllipse.Checked)
                        MiddleDot.DrawEllipse(result, drawCenter, Rx, Ry, cDraw);
                }
                else if (radioButtonBresenham.Checked)
                {
                    if (radioButtonCircle.Checked)
                        Bresenham.DrawCircle(result, drawCenter, Rx, cDraw);
                    else if (radioButtonEllipse.Checked)
                        Bresenham.DrawEllipse(result, drawCenter, Rx, Ry, cDraw);
                }
            }
            canvas.Refresh();
            checkBox1.Checked = false;
            checkBox1_CheckedChanged(null, null);
        }

        private int GetInt(TextBox tb)
        {
            return Convert.ToInt32(tb.Text);
        }

        private void buttonDrawOne_Click(object sender, EventArgs e)
        {
            Draw(new Point (GetInt(textBoxX), GetInt(textBoxY)), GetInt(textBoxRX1), GetInt(textBoxRY1));
        }

        private void buttonDrawMany_Click(object sender, EventArgs e)
        {
            Draw(new Point(canvas.Width / 2, canvas.Height / 2), GetInt(textBoxRX2), GetInt(textBoxRY2), GetInt(textBoxDRX), GetInt(textBoxN));
        }

        // Очиска холста
        private void buttonClear_Click(object sender, EventArgs e)
        {
            g.Clear(cBackground);
            canvas.Refresh();
        }

        // Рисовать цветом фона или нет
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                cDraw = cBackground;
            else
                cDraw = Color.Black;

            buttonChooseColor.BackColor = cDraw;
        }
    }
}
