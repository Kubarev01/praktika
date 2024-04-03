using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sadasda
{
    public partial class Form3 : Form
    {
        TimeSpan ts = new TimeSpan(0, 0, 30);
        TimeSpan block = new TimeSpan(0, 1, 0);
        string ts_stop = "continue";
        public Form3()
        {
            InitializeComponent();

            StartTimer();
            label3.Text = Class1.fio;
            label4.Text = Class1.position;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ts_stop = "stop";
            this.Hide();
            Form1 старт = new Form1();
            старт.Show();

        }
        public async void StartTimer()
        {

            while (ts > TimeSpan.Zero)
            {
                if (ts_stop == "continue")
                {
                    label1.Text = ts.ToString();
                    await Task.Delay(1000);
                    ts -= TimeSpan.FromSeconds(1);
                    Console.WriteLine(ts);
                    if (ts.ToString() == "00:00:15")
                    {

                        MessageBox.Show("Осталось 15 секунд");
                    }
                }
                else
                {
                    return;
                }

            }
            this.Hide();
            Form1 старт = new Form1();
            старт.Show();
            Class1.access = 0;
            while (block > TimeSpan.Zero)
            {
                await Task.Delay(1000);
                block -= TimeSpan.FromSeconds(1);
                Console.WriteLine(ts);
            }
            Class1.access = 1;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
