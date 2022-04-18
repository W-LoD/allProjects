using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class L2 : Form
    {
        public L2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label16.Text = "Заполните нужные поля поля!";
            }
            else
            {
                label16.Visible = false;
                int N = int.Parse(textBox1.Text);
                double s = 0;
                int iter = 0;
                double[] Z = new double[N];
                for (int i = 0; i < N; i++)
                {
                    Z[i] = Math.Abs(Math.Cos(Math.Pow(i, 2) - 3.8)) / 4.5 - 9.7 * Math.Sin(i - 3.1);
                }
                for (int i = 0; i < N; i++)
                {
                    if (Z[i] > 0)
                    {
                        iter++;
                    }
                    if (iter == 2)
                    {
                        s = Z[i] + Z[2];
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    textBox3.Text += Math.Round(Z[i], 3).ToString() + "  ";
                }
                label5.Text = "Сумма второго положительного и третьего элемента:" + Math.Round(s, 3).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                label15.Text = "Заполните нужные поля поля!";
            }
            else
            {
                label15.Visible = false;
                byte N2 = byte.Parse(textBox5.Text);
                byte M2 = byte.Parse(textBox6.Text);
                dataGridView1.RowCount = N2;
                dataGridView1.ColumnCount = M2;
                double[,] Z2 = new double[N2, M2];
                for (int i = 0; i < N2; i++)
                {
                    for (int j = 0; j < M2; j++)
                    {
                        Z2[i, j] = (i * Math.Abs(Math.Cos(Math.Pow(j, 2) - 3.8)) / 4.5 - 9.7 * Math.Sin(j - 3.1)) + (Math.Sin(j) * Math.Abs(Math.Cos(Math.Pow(i, 2) - 3.8)) / 4.5 - 9.7 * Math.Sin(i - 3.1));
                    }
                }
                for (int i = 0; i < N2; i++)
                    for (int j = 0; j < M2; j++)
                        dataGridView1.Rows[i].Cells[j].Value = Z2[i, j];
                double max = 0;
                double min = 0;
                for (int i = 0; i < Z2.GetLength(0); i++)
                {
                    for (int j = 1; j < Z2.GetLength(1); j++)
                    {
                        min = max = Z2[i, 0];
                        if (max < Z2[i, j]) max = Z2[i, j];
                        if (min > Z2[i, j]) min = Z2[i, j];
                    }
                }
                for (int i = 0; i < Z2.GetLength(0); i++)
                {
                    for (int j = 0; j < Z2.GetLength(1); j++)
                    {
                        if (max == Z2[i, j])
                        {
                            label9.Text = "Максимальный элемент = " + Math.Round(max, 3).ToString();
                            label10.Text = "Индекс максимального элемента = [ " + i + ", "+j+" ]";
                        }
                        if (min == Z2[i, j])
                        {
                            label11.Text = "Vbybvfkmysq элемент = " + Math.Round(max, 3).ToString();
                            label12.Text = "Индекс минимального элемента = [ " + i + ", " + j + " ]";
                        }
                    }
                }
                label13.Text = "Произведение максимального и минимального = " + (max * min);
            }
        }
    }
}
