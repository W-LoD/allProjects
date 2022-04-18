using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class L1 : Form
    {
        public L1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                label7.Text = "Заполните поля!";
            }
            else
            {
                label7.Visible = false;
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);

                double D = Math.Pow(b, 2) - 4 * a * c;
                if (D < 0) // нет решений
                {
                    textBox4.Text = D.ToString();
                    label4.Text = "Корней нет!";
                }
                else if (D == 0) // одно решение
                {
                    textBox4.Text = D.ToString();
                    Double x = -b / (2 * a);
                    label4.Text = "Корень = " + x.ToString();
                }
                else // два решения
                {
                    textBox4.Text = D.ToString();
                    label4.Text = "Корни: (" + Math.Round(((-b - (Math.Sqrt(D))) / (2 * a)), 3) + ") и (" + Math.Round(((-b + (Math.Sqrt(D))) / (2 * a)), 3) + ")";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

    }
}
