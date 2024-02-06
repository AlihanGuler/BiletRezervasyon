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
    public partial class yetkılıucuslar : Form
    {
        public yetkılıucuslar()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        void listele()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ucus", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        private void yetkılıucuslar_Load(object sender, EventArgs e)
        {
            listele(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yetkilianaekrann ff = new yetkilianaekrann();
            ff.Show();
            Hide();
        }
      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkalkıs.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtvarıs.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txttarih.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskkalkıs.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskvarıs.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtkalkıs.Text = "";
            txtvarıs.Text = "";
            txttarih.Text = "";
            mskkalkıs.Text = "";
            mskvarıs.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("delete from ucus where ucusID=@p1",cn);
            kmt.Parameters.AddWithValue("@p1",txtid.Text);
            kmt.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Uçuş İptal Edildi.");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("update ucus set kalkıs=@p1,varıs=@p2,tarıh=@p3,klksaat=@p4,vrssaat=@p5 where ucusıd=@p6",cn);
            kmt.Parameters.AddWithValue("@p1",txtkalkıs.Text);
            kmt.Parameters.AddWithValue("@p2",txtvarıs.Text);
            kmt.Parameters.AddWithValue("@p3",txttarih.Text);
            kmt.Parameters.AddWithValue("@p4",mskkalkıs.Text);
            kmt.Parameters.AddWithValue("@p5",mskvarıs.Text);
            kmt.Parameters.AddWithValue("@p6",txtid.Text);
            kmt.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Uçuş Güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }
    }
    }

