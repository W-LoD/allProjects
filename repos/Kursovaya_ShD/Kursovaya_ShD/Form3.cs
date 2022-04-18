using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kursovaya_ShD
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-88P1P3S;Initial Catalog=Kursovaya_ShD;" + "Integrated Security=True;");
            connection.Open();
            string query_M = "SELECT * FROM Tovar_spisok";
            SqlCommand command = new SqlCommand(query_M, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripButton8.Text != "")
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
