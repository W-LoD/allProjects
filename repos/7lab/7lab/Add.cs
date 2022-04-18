using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7lab
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            
        }

        private void Add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet._000". При необходимости она может быть перемещена или удалена.
            this._000TableAdapter.Fill(this.stDataSet._000);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Stud". При необходимости она может быть перемещена или удалена.
            this.studTableAdapter.Fill(this.stDataSet.Stud);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Marks". При необходимости она может быть перемещена или удалена.
            this.marksTableAdapter.Fill(this.stDataSet.Marks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Marks". При необходимости она может быть перемещена или удалена.
            this.marksTableAdapter.Fill(this.stDataSet.Marks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.View_1". При необходимости она может быть перемещена или удалена.
            this.view_1TableAdapter.Fill(this.stDataSet.View_1);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            view_1BindingNavigatorSaveItem.Enabled = true;
            view_1BindingSource.AllowNew = true;
            richTextBox1.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
        }

        private void view_1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            view_1BindingSource.AllowNew = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            studBindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            studBindingSource.EndEdit();
            studTableAdapter.Adapter.Update(stDataSet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            marksBindingSource.AddNew();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            marksBindingSource.EndEdit();
            marksTableAdapter.Adapter.Update(stDataSet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            studBindingSource.RemoveCurrent();
            studBindingSource.EndEdit();
            studTableAdapter.Update(stDataSet);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            marksBindingSource.RemoveCurrent();
            marksBindingSource.EndEdit();
            marksTableAdapter.Update(stDataSet);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Stud". При необходимости она может быть перемещена или удалена.
            this.studTableAdapter.Fill(this.stDataSet.Stud);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Marks". При необходимости она может быть перемещена или удалена.
            this.marksTableAdapter.Fill(this.stDataSet.Marks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.Marks". При необходимости она может быть перемещена или удалена.
            this.marksTableAdapter.Fill(this.stDataSet.Marks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stDataSet.View_1". При необходимости она может быть перемещена или удалена.
            this.view_1TableAdapter.Fill(this.stDataSet.View_1);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            view_1BindingNavigatorSaveItem.Enabled = true;
            view_1BindingSource.AllowNew = true;
        }
       
    }
}
