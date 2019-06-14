﻿using System;
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

        void h(Point center, int r1, int r2, Color c1, Color c2)
        {
            Parametric.DrawCircle(result, center, r1, c1);
            Parametric.DrawEllipse(result, center, r1, r2, c1);

            Canonical.drawCircle(result, center, r1, c2);
            Canonical.DrawEllipse(result, center, r1, r2, c2);
        }

        void h2(Point center, int r1, int r2, Color c1, Color c2)
        {
            Canonical.drawCircle(result, center, r1, c2);
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


            h(new Point(250, 250), 100, 50, Color.Black, Color.White);
            h(new Point(500, 250), 50, 100, Color.Black, Color.White);
            h2(new Point(250, 500), 100, 50, Color.White, Color.Black);
            h2(new Point(500, 500), 50, 100, Color.White, Color.Black);

            canvas.Update();
            canvas.Refresh();

        }
    }
}
