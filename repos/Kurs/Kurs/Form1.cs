using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Fill();
        }
        public void Fill()
        {
            dataGridView1.DataSource = DBObjects.Entities.Pokup.ToList();
        }
    }
    
}
