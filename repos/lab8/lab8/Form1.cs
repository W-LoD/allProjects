using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }
        public void Mass()
        {
            int n, m;
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            int[,] nums = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    nums[i, j] = rnd.Next(i, 10);
            Out(nums, n, m);
            Sort(nums, n, m);
            Out2(nums, n, m);
            Sort2(nums, n, m);
            
        }
        public void Out(int[,] nums, int n, int m)
        {

            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = nums[i, j];
        }
        public void Out2(int[,] nums, int n, int m)
        {

            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = m;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    dataGridView2.Rows[i].Cells[j].Value = nums[i, j];
        }
        public void Out3(int[,] nums, int n, int m)
        {

            dataGridView3.RowCount = n;
            dataGridView3.ColumnCount = m;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    dataGridView3.Rows[i].Cells[j].Value = nums[i,j];
        }
        public void Sort(int[,] nums, int n, int m)
        {
            
            for (int i = 0; i < nums.GetLength(0); i++) // numsay Sorting
            {
                for (int j = nums.GetLength(1) - 1; j > 0; j--)
                {
                    for (int k = 0; k < j; k++)
                    {
                        if (nums[i, k] > nums[i, k + 1])
                        {
                            int temp = nums[i, k];
                            nums[i, k] = nums[i, k + 1];
                            nums[i, k + 1] = temp;
                        }
                    }
                }
            }         
        }
        public void Sort2(int[,] nums, int n, int m)
        {
            int[] counts = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = m; j > 0; j--)
                {
                    for (int k = 0; k < j; k++)
                    {
                        sum += nums[i, k];
                    }
                    counts[i] = sum/m;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int k;
                int p = i;
                sum = counts[i];

                for (int j = i + 1; j < n; j++)
                {
                    if (counts[j] < sum)
                    {
                        p = j;
                        sum = counts[j];
                    }
                }

                counts[p] = counts[i];
                counts[i] = sum;
                for (k = 0; k < m; k++)
                {
                    int temp = nums[i, k];
                    nums[i, k] = nums[p, k];
                    nums[p, k] = temp;
                }
                Out3(nums, n, m);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Mass();
        }
    }
}
