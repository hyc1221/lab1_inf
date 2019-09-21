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

        static int N = 30;
        static double[] px;
        static Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        public void Count()
        {
            N = Convert.ToInt32(numericUpDown1.Value);
            px = new double[N];
            double b = 0;
            double s = 0;
            int offset = 0;
            int count = 0;
            if (N % 10 > 0)
            {
                b = 1 / (Convert.ToDouble(N) / 2);
                offset = N / (N / 2);
            }
            else
            {
                b = 1.0 / 10;
                offset = N / 10;
            }
            while (s != 1 && count < N)
            {
                double bv = b;
                double sv = 0;
                for (int i = count; i < count + offset - 1; i++)
                {
                    px[i] = bv * rand.NextDouble();
                    bv -= px[i];
                    sv += px[i];
                    
                }
                px[count + offset - 1] = b - sv;
                sv += px[count + offset - 1];
                s += sv;
                count += offset;
            }
            double Ix = 0;
            for (int i = 0; i < N; i++)
            {
                richTextBox1.AppendText((i + 1).ToString() + ": " + px[i].ToString() + "\n");
                Ix += px[i] * Math.Log(px[i], 2);
            }
            richTextBox1.AppendText("\n");
            label1.Text = "I(x) = " + (-Ix).ToString();
            label2.Text = "H(x)max = " + Math.Log(N, 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Count();
        }
    }
}
