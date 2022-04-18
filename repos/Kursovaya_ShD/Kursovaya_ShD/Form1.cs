using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kursovaya_ShD
{
    public partial class Form1 : Form
    {
        int count_records = 1;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            connection.Open();
            string query_M = "SELECT * FROM new_pokupka";
            SqlCommand command = new SqlCommand(query_M, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][0] = comboBox1.Items[(int)reader[0] - 2].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = comboBox3.Items[(int)reader[2] - 2].ToString();
                data[data.Count - 1][3] = comboBox2.Items[(int)reader[3] - 2].ToString();
                count_records = (int)reader[4];
                data[data.Count - 1][4] = count_records.ToString();
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            try
            {
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
                    data[data.Count - 1][3] = comboBox2.Items[current_id-2].ToString();
                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
                    string query = "set identity_insert Pokupka on;" +
                        "INSERT INTO Pokupka (Pokupka_ID, ID_M, ID_S, ID_P, ID_T, Kolvo, ID_Pok)" +
                        " VALUES (@Pokupka_ID, @ID_M, @ID_S, @ID_P, @ID_T, @Kolvo, @ID_Pok)" +
                        "set identity_insert Pokupka off;";
                    SqlCommand command = new SqlCommand(query, connection);
                    count_records++;
                    command.Parameters.AddWithValue("Pokupka_ID", count_records);
                    command.Parameters.AddWithValue("ID_M", current_id);
                    command.Parameters.AddWithValue("ID_S", current_id);
                    command.Parameters.AddWithValue("ID_P", current_id);
                    command.Parameters.AddWithValue("ID_T", current_id);
                    command.Parameters.AddWithValue("Kolvo", current_kolvo);
                    command.Parameters.AddWithValue("ID_Pok", pokupatel_id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    dataGridView1.Rows.Clear();
                    LoadData();
                    MessageBox.Show("Заказ добавлен", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else MessageBox.Show("Введите данные");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            try
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr != DialogResult.Cancel)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows) 
                    {
                    string query = " delete Pokupka where Pokupka_ID = " + row.Cells[4].Value;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    dataGridView1.Rows.Remove(row); 
                    }    
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 form4 = new Form4();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    form4.comboBox1.Text = row.Cells[0].Value.ToString();
                    form4.numericUpDown1.Value = Decimal.Parse(row.Cells[1].Value.ToString());
                    form4.comboBox3.Text = row.Cells[2].Value.ToString();
                    form4.comboBox2.Text = row.Cells[3].Value.ToString();
                    form4.label4.Text = row.Cells[4].Value.ToString();
                }
                Hide();
                form4.Show();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            try
            {
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
                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
                    string query = "set identity_insert Pokupka on;" +
                        "INSERT INTO Pokupka (Pokupka_ID, ID_M, ID_S, ID_P, ID_T, Kolvo, ID_Pok)" +
                        " VALUES (@Pokupka_ID, @ID_M, @ID_S, @ID_P, @ID_T, @Kolvo, @ID_Pok)" +
                        "set identity_insert Pokupka off;";
                    SqlCommand command = new SqlCommand(query, connection);
                    count_records++;
                    command.Parameters.AddWithValue("Pokupka_ID", count_records);
                    command.Parameters.AddWithValue("ID_M", current_id);
                    command.Parameters.AddWithValue("ID_S", current_id);
                    command.Parameters.AddWithValue("ID_P", current_id);
                    command.Parameters.AddWithValue("ID_T", current_id);
                    command.Parameters.AddWithValue("Kolvo", current_kolvo);
                    command.Parameters.AddWithValue("ID_Pok", pokupatel_id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    dataGridView1.Rows.Clear();
                    LoadData();
                    MessageBox.Show("Заказ добавлен", "Все прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else MessageBox.Show("Введите данные");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 form4 = new Form4();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    form4.comboBox1.Text = row.Cells[0].Value.ToString();
                    form4.numericUpDown1.Value = Decimal.Parse(row.Cells[1].Value.ToString());
                    form4.comboBox3.Text = row.Cells[2].Value.ToString();
                    form4.comboBox2.Text = row.Cells[3].Value.ToString();
                    form4.label4.Text = row.Cells[4].Value.ToString();
                }
                Hide();
                form4.Show();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            try
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr != DialogResult.Cancel)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string query = " delete Pokupka where Pokupka_ID = " + row.Cells[4].Value;
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if(toolStripButton8.Text != "") 
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                                if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(toolStripButton8.Text))
                                {
                                    dataGridView1.Rows[i].Selected = true;
                                    break;
                                }
                                else dataGridView1.Rows[i].Visible = false;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            toolStripButton8.Text = "";
            dataGridView1.Rows.Clear();
            LoadData();
        }
    }
}
