using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlData = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;
        private SqlCommandBuilder sqlBuilder2 = null;
        private SqlDataAdapter sqlData2 = null;
        private DataSet dataSet2 = null;
        private bool newRowAdding2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        //private void Add_Click(object sender, EventArgs e){}
        private void LoadData()
        {
            try
            {
                sqlData = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM Credit", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlData);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "Credit");
                dataGridView1.DataSource = dataSet.Tables["Credit"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReLoadData()
        {
            try
            {
                dataSet.Tables["Credit"].Clear();
                sqlData.Fill(dataSet, "Credit");
                dataGridView1.DataSource = dataSet.Tables["Credit"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData2()
        {
            try
            {
                sqlData2 = new SqlDataAdapter("SELECT *, 'Delete' AS [Comand] FROM Deposit", sqlConnection);
                sqlBuilder2 = new SqlCommandBuilder(sqlData2);
                sqlBuilder2.GetInsertCommand();
                sqlBuilder2.GetUpdateCommand();
                sqlBuilder2.GetDeleteCommand();
                dataSet2 = new DataSet();
                sqlData2.Fill(dataSet2, "Deposit");
                dataGridView2.DataSource = dataSet2.Tables["Deposit"];
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[8, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReLoadData2()
        {
            try
            {
                dataSet2.Tables["Deposit"].Clear();
                sqlData2.Fill(dataSet2, "Deposit");
                dataGridView2.DataSource = dataSet2.Tables["Deposit"];
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[8, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\dinas\source\repos\Курсовая\Курсовая\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            await sqlConnection.OpenAsync();
            LoadData();
            LoadData2();
        }
        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Close();
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ReLoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Credit"].Rows[rowIndex].Delete();
                            sqlData.Update(dataSet, "Credit");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Credit"].NewRow();
                        row["Name"] = dataGridView1.Rows[rowIndex].Cells["Name"].Value;
                        row["Term"] = dataGridView1.Rows[rowIndex].Cells["Term"].Value;
                        row["Bet"] = dataGridView1.Rows[rowIndex].Cells["Bet"].Value;
                        row["Pasport"] = dataGridView1.Rows[rowIndex].Cells["Pasport"].Value;
                        row["Z/P"] = dataGridView1.Rows[rowIndex].Cells["Z/P"].Value;
                        row["Summa"] = dataGridView1.Rows[rowIndex].Cells["Summa"].Value;
                        row["Data"] = DateTime.Now;
                        double stavka = (int)dataGridView1.Rows[rowIndex].Cells["Bet"].Value / 10.0 / 12.0;
                        int v = (int)dataGridView1.Rows[rowIndex].Cells["Term"].Value * 12;
                        int mes = v;
                        int sum = (int)dataGridView1.Rows[rowIndex].Cells["Summa"].Value;
                        double step = Math.Pow(1 + stavka, mes);
                        double aplat = ((stavka * step) / (step - 1));
                        row["Сontribution"] = sum * aplat;
                        dataSet.Tables["Credit"].Rows.Add(row);
                        dataSet.Tables["Credit"].Rows.RemoveAt(dataSet.Tables["Credit"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                        sqlData.Update(dataSet, "Credit");
                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["Credit"].Rows[r]["Name"] = dataGridView1.Rows[r].Cells["Name"].Value;
                        dataSet.Tables["Credit"].Rows[r]["Term"] = dataGridView1.Rows[r].Cells["Term"].Value;
                        dataSet.Tables["Credit"].Rows[r]["Bet"] = dataGridView1.Rows[r].Cells["Bet"].Value;
                        dataSet.Tables["Credit"].Rows[r]["Pasport"] = dataGridView1.Rows[r].Cells["Pasport"].Value;
                        dataSet.Tables["Credit"].Rows[r]["Z/P"] = dataGridView1.Rows[r].Cells["Z/P"].Value;
                        dataSet.Tables["Credit"].Rows[r]["Summa"] = dataGridView1.Rows[r].Cells["Summa"].Value;
                        double stavka = (int)dataGridView1.Rows[r].Cells["Bet"].Value / 10.0 / 12.0;
                        int v = (int)dataGridView1.Rows[r].Cells["Term"].Value * 12;
                        int mes = v;
                        int sum = (int)dataGridView1.Rows[r].Cells["Summa"].Value;
                        double step = Math.Pow(1 + stavka, mes);
                        double aplat = ((stavka * step) / (step - 1));
                        dataSet.Tables["Credit"].Rows[r]["Сontribution"] = sum * aplat;
                        sqlData.Update(dataSet, "Credit");
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                    }
                    ReLoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, lastRow] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void Recalculation_Click(object sender, EventArgs e){}

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    string task = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView2.Rows.RemoveAt(rowIndex);
                            dataSet2.Tables["Deposit"].Rows[rowIndex].Delete();
                            sqlData2.Update(dataSet2, "Deposit");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView2.Rows.Count - 2;
                        DataRow row = dataSet2.Tables["Deposit"].NewRow();
                        row["Name"] = dataGridView2.Rows[rowIndex].Cells["Name"].Value;
                        row["Term"] = dataGridView2.Rows[rowIndex].Cells["Term"].Value;
                        row["Bet"] = dataGridView2.Rows[rowIndex].Cells["Bet"].Value;
                        row["Pasport"] = dataGridView2.Rows[rowIndex].Cells["Pasport"].Value;
                        row["Summa"] = dataGridView2.Rows[rowIndex].Cells["Summa"].Value;
                        row["Data"] = DateTime.Now;
                        int sum = (int)dataGridView2.Rows[rowIndex].Cells["Summa"].Value;
                        int bet = (int)dataGridView2.Rows[rowIndex].Cells["Bet"].Value;
                        int srok = (int)dataGridView2.Rows[rowIndex].Cells["Term"].Value;
                        row["Pay"] = Math.Pow(sum * bet / 12.0, 12.0 * srok);
                        dataSet2.Tables["Deposit"].Rows.Add(row);
                        dataSet2.Tables["Deposit"].Rows.RemoveAt(dataSet2.Tables["Deposit"].Rows.Count - 1);
                        dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                        dataGridView2.Rows[e.RowIndex].Cells[8].Value = "Delete";
                        sqlData2.Update(dataSet2, "Deposit");
                        newRowAdding2 = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet2.Tables["Deposit"].Rows[r]["Name"] = dataGridView2.Rows[r].Cells["Name"].Value;
                        dataSet2.Tables["Deposit"].Rows[r]["Term"] = dataGridView2.Rows[r].Cells["Term"].Value;
                        dataSet2.Tables["Deposit"].Rows[r]["Bet"] = dataGridView2.Rows[r].Cells["Bet"].Value;
                        dataSet2.Tables["Deposit"].Rows[r]["Pasport"] = dataGridView2.Rows[r].Cells["Pasport"].Value;
                        dataSet2.Tables["Deposit"].Rows[r]["Summa"] = dataGridView2.Rows[r].Cells["Summa"].Value;
                        int sum = (int)dataGridView2.Rows[r].Cells["Summa"].Value;
                        int bet = (int)dataGridView2.Rows[r].Cells["Bet"].Value;
                        int srok = (int)dataGridView2.Rows[r].Cells["Term"].Value;
                        dataSet2.Tables["Deposit"].Rows[r]["Pay"] = Math.Pow(sum * bet / 12.0, 12.0 * srok);
                        sqlData2.Update(dataSet2, "Deposit");
                        dataGridView2.Rows[e.RowIndex].Cells[8].Value = "Delete";
                    }
                    ReLoadData2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding2 == false)
                {
                    newRowAdding2 = true;
                    int lastRow = dataGridView2.Rows.Count - 2;
                    DataGridViewRow row = dataGridView2.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[8, lastRow] = linkCell;
                    row.Cells["Comand"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView2.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[8, rowIndex] = linkCell;
                    editingRow.Cells["Comand"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dataGridView2.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView2.CurrentCell.ColumnIndex == 3)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView2.CurrentCell.ColumnIndex == 4)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView2.CurrentCell.ColumnIndex == 5)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void menuStrip1_DoubleClick(object sender, EventArgs e) => Close();
    }
}
