using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

            public void Shutdown()
            {
                Process.Start("shutdown", "/s /t" + 0);
            }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();

           // Process.Start("shutdown", "-a");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sec = (dateTimePicker1.Value.Hour * 3600) + (dateTimePicker1.Value.Minute * 60) + dateTimePicker1.Value.Second;
            long time = dateTimePicker1.Value.TimeOfDay;
            MessageBox.Show(time.ToLongTimeString());
            label2.Text = "Время до выключения: " + time;
            if (sec > 0)
            {
                sec--;
            }
        }
    }
}
