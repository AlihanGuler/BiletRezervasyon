using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biletrez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            yetkılıgırıs gr = new yetkılıgırıs();
            gr.Show();
            
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            uyegırıs gr = new uyegırıs();
            gr.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu uygulama ALİHAN GÜLER tarafından 8.10.23 tarihinde oluşturulmuştur.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucuslar uc = new ucuslar();
            uc.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
