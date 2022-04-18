using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakt
{
    public partial class Choise : Form
    {
        int choise;
        public Choise(int choice)
        {
            InitializeComponent();
            choise = choice;
        }
        public void Fill()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choise = 1;
            Main_form main_Form = new Main_form(choise);
            Hide();
            main_Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choise = 0;
            Main_form main_Form = new Main_form(choise);
            Hide();
            main_Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choise = -1;
            Main_form main_Form = new Main_form(choise);
            Hide();
            main_Form.Show();
        }
    }
}
