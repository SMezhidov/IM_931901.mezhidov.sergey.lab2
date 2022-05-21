using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.05;
        double rateE, rateD;
        int day = 0;

        Random random = new Random();

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            rateE = (double)edEuro.Value;
            rateD = (double)edDol.Value;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, rateE);

            chart1.Series[1].Points.Clear();
            chart1.Series[1].Points.AddXY(0, rateD);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            rateE = rateE * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(day++, rateE);

            rateD = rateE * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[1].Points.AddXY(day, rateD);
        }
    }
}
