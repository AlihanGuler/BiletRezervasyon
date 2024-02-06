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
    public partial class duyuruform : Form
    {
        public duyuruform()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            yetkilianaekrann y = new yetkilianaekrann();
            y.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("insert into tblDuyuru (duyuru) values (@p1)",cn);
            kmt.Parameters.AddWithValue("@p1",richTextBox1.Text);
            kmt.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Duyuru Eklendi");
            listele();
        }

        private void duyuruform_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select duyuru as 'DUYURU' from tblduyuru", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
    }
}
