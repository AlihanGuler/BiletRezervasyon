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
    public partial class üyeanaekran : Form
    {
        public üyeanaekran()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");

        private void üyeanaekran_Load(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select ucusno as 'Uçuş No',kalkıs as 'Kalkış',varıs as 'Varış',tarıh as 'Tarih',klksaat as 'Kalkış Saati',vrssaat as 'Varış Saati' from ucus",cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
            cn.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select Duyuru  from tblDuyuru",cn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            cn.Close();
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "3";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "2";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "8";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("insert into tblsefer (yolcuadsoyad,koltukno,ucusno) values (@p1,@p2,@p3)",cn);
            kmt.Parameters.AddWithValue("@p1",txtads.Text);
            kmt.Parameters.AddWithValue("@p2",txtkoltukno.Text);
            kmt.Parameters.AddWithValue("@p3",txtucusno.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Rezervasyonunuz Oluşturulmuştur.");
            cn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtucusno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }
    }
}
