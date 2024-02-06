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
    public partial class yetkılıgırıs : Form
    {
        public yetkılıgırıs()
        {
            InitializeComponent();
        }
        

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        private void button1_Click_1(object sender, EventArgs e)
        {
                cn.Open();
                SqlCommand kmt = new SqlCommand("select * from yetkılıgırıs where tc=@p1 and sıfre=@p2", cn);
                kmt.Parameters.AddWithValue("@p1", msktc.Text);
                kmt.Parameters.AddWithValue("@p2", txtsifre.Text);
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("WELCOME !");
                yetkilianaekrann y = new yetkilianaekrann();
                y.tc = msktc.Text;
                y.Show();
                Hide();
                }
                else
                {
                    MessageBox.Show("Yanlış TC veya ŞİFRE! ","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                cn.Close();
            }

        private void yetkılıgırıs_Load(object sender, EventArgs e)
        {
            
    }
    }
    }

