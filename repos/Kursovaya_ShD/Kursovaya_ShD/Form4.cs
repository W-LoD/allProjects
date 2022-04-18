using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kursovaya_ShD
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
                List<string[]> data = new List<string[]>();
                data.Add(new string[4]);
                data[data.Count - 1][0] = comboBox1.Text;
                data[data.Count - 1][1] = numericUpDown1.Text;
                data[data.Count - 1][2] = comboBox3.Text;
                if (data[data.Count - 1][0] != "" && data[data.Count - 1][1] != "0" && data[data.Count - 1][2] != "")
                {
                    int current_id = comboBox1.SelectedIndex + 2;
                    int current_kolvo = (int)numericUpDown1.Value;
                    int pokupatel_id = comboBox3.SelectedIndex + 2;
                    data[data.Count - 1][3] = comboBox2.Items[current_id - 2].ToString();
                    int id = int.Parse(label4.Text);
                    string query =
                        "update Pokupka set ID_M = " + current_id +
                        ", ID_S = " + current_id +
                        ", ID_P = " + current_id +
                        ", ID_T = " + current_id +
                        ", Kolvo = " + current_kolvo +
                        ", ID_Pok = " + pokupatel_id + "where Pokupka_ID = " + id;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    MessageBox.Show("Заказ изменён", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else MessageBox.Show("Введите данные");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
                List<string[]> data = new List<string[]>();
                data.Add(new string[4]);
                data[data.Count - 1][0] = comboBox1.Text;
                data[data.Count - 1][1] = numericUpDown1.Text;
                data[data.Count - 1][2] = comboBox3.Text;
                if (data[data.Count - 1][0] != "" && data[data.Count - 1][1] != "0" && data[data.Count - 1][2] != "")
                {
                    int current_id = comboBox1.SelectedIndex + 2;
                    int current_kolvo = (int)numericUpDown1.Value;
                    int pokupatel_id = comboBox3.SelectedIndex + 2;
                    data[data.Count - 1][3] = comboBox2.Items[current_id - 2].ToString();
                    int id = int.Parse(label4.Text);
                    string query =
                        "update Pokupka set ID_M = " + current_id +
                        ", ID_S = " + current_id +
                        ", ID_P = " + current_id +
                        ", ID_T = " + current_id +
                        ", Kolvo = " + current_kolvo +
                        ", ID_Pok = " + pokupatel_id + "where Pokupka_ID = " + id;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    MessageBox.Show("Заказ изменён", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else MessageBox.Show("Введите данные");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
