using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Edge>[] y_group = new List<Edge>[pictureBox1.Height];
            ListOfActiveEdges ActiveEdges = new ListOfActiveEdges(pictureBox1.Width);
        }

    }
}
