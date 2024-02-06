using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace biletrez
{
    public partial class üye_ol : Form
    {
        public üye_ol()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uyegırıs gr = new uyegırıs();
            gr.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("insert into yolcugiris (ad,soyad,maıl,sıfre) values (@p1,@p2,@p3,@p4)",cn);
            kmt.Parameters.AddWithValue("@p1",txtad.Text);
            kmt.Parameters.AddWithValue("@p2",txtsoyd.Text);
            kmt.Parameters.AddWithValue("@p3",txtmail.Text);
            kmt.Parameters.AddWithValue("@p4",txtsifre.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Kayıt İşleminiz Başarılı.");
        }
    }
}
