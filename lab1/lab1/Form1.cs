using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {

        static int N = 42;
        static double[] px = new double[N];
        static Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        public void Count()
        {
            double b = 0;
            double s = 0;
            int offset = 0;
            int count = 0;
            if (N % 10 > 0)
            {
                b = 1 / (N / 2);
                offset = N / (N / 2);
            }
            else
            {
                b = 1 / 10;
                offset = N / 10;
            }
            while (s != 1)
            {
                double bv = b;
                for (int i = count; i < count + offset - 1; i++)
                {
                    px[i] = bv * rand.NextDouble();
                    bv -= px[i];
                    s += px[i];
                }
                px[count + offset] = 1 - s;
                count += offset;
            }
        }
    }
}
