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
    public partial class uyegırıs : Form
    {
        public uyegırıs()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("select * from yolcugiris where maıl =@p1 and sıfre=@p2 ",cn);
            kmt.Parameters.AddWithValue("@p1",txtmail.Text);
            kmt.Parameters.AddWithValue("@p2",txtsifre.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("WELCOME");
                üyeanaekran u = new üyeanaekran();
                u.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Mail Veya Şifre!!");
            }
            cn.Close();
        }

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            üye_ol u = new üye_ol();
            u.Show();
            this.Hide();
        }

        private void uyegırıs_Load(object sender, EventArgs e)
        {

        }
    }
}
