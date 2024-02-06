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
    public partial class rezervasyonduzenle : Form
    {
        public rezervasyonduzenle()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        void listele()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select yolcuadsoyad as'Ad Soyad',koltukno as 'Koltuk No ',ucusno as 'Uçuş No'  from  tblsefer", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        private void rezervasyonduzenle_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtads.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkoltukn.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtucusno.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtads.Text = "";
            txtkoltukn.Text = "";
            txtucusno.Text = "";

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("delete from tblsefer where yolcuadsoyad=@p1 ",cn);
            kmt.Parameters.AddWithValue("@p1",txtads.Text);
            kmt.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Yolcu Silindi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yetkilianaekrann y = new yetkilianaekrann();
            y.Show();
            Hide();
        }

        private void btngünclle_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("update tblsefer set yolcuadsoyad=@p1,ucusno=@p2 where koltukno=@p3",cn);
            kmt.Parameters.AddWithValue("@p1",txtads.Text);
            kmt.Parameters.AddWithValue("@p2",txtucusno.Text);
            kmt.Parameters.AddWithValue("@p3",txtkoltukn.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Yolcu bilgileri güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            cn.Close();
            listele();
        }
    }
}
