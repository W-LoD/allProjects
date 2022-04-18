using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakt
{
    public partial class Main_form : Form
    {
        public Main_form(int choise)
        {
            InitializeComponent();
            fonts();
        }
        PrivateFontCollection font;

        private void fonts()
        {
            this.font = new PrivateFontCollection();
            this.font.AddFontFile("C:\\Users\\dinas\\source\\repos\\prakt\\prakt\\font\\Anime2.ttf");
            richTextBox1.Enabled = false;
            richTextBox1.Font = new Font(font.Families[0], 10);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Choise choise = new Choise(0);
            choise.ShowDialog();
            
        }
    }
}
