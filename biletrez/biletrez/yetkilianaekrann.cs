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
    public partial class yetkilianaekrann : Form
    {
        public yetkilianaekrann()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-SD5188N;Initial Catalog=biletrez;Integrated Security=True");
        public string tc;
        
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("insert into yetkılıgırıs (ad,soyad,tc,sıfre) values (@p1,@p2,@p3,@p4)",cn);
            kmt.Parameters.AddWithValue("@p1",TXTAD.Text);
            kmt.Parameters.AddWithValue("@p2",txtsoyd.Text);
            kmt.Parameters.AddWithValue("@p3",msktc.Text);
            kmt.Parameters.AddWithValue("@p4",txtsifre.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Görevli Eklendi.");
            cn.Close();
            listeleyetkili();
           
        }
        void listeleyolcu()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from yolcugiris", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void listeleyetkili()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select * from yetkılıgırıs", cn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

        }
        void tcyazdir()
        {
            cn.Open();
            lbltc.Text = tc;
            SqlCommand kmt2 = new SqlCommand("select  ad,soyad from yetkılıgırıs where tc= @p1", cn);
            kmt2.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = kmt2.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            cn.Close();
        }
        private void yetkilianaekrann_Load(object sender, EventArgs e)
            
        {
            listeleyolcu();
            listeleyetkili();
            tcyazdir();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand kmt = new SqlCommand("insert into ucus (kalkıs,varıs,tarıh,klksaat,vrssaat,ucusno) values (@p1,@p2,@p3,@p4,@p5,@p6)",cn);
            kmt.Parameters.AddWithValue("@p1",txtkalkıs.Text);
            kmt.Parameters.AddWithValue("@p2",txtvarıs.Text);
            kmt.Parameters.AddWithValue("@p3",txttarih.Text);
            kmt.Parameters.AddWithValue("@p4",msksaat.Text);
            kmt.Parameters.AddWithValue("@p5",mskvarıs.Text);
            kmt.Parameters.AddWithValue("@p6",txtrandom.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Uçuş Eklendi.");
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yetkılıucuslar yt = new yetkılıucuslar();
            yt.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            duyuruform dr = new duyuruform();
            dr.Show();
            Hide();
        }

        private void btnrez_Click(object sender, EventArgs e)
        {
            rezervasyonduzenle r = new rezervasyonduzenle();
            r.Show();
            Hide();
        }

        private void btnrandom_Click(object sender, EventArgs e)
        {
            Random rst = new Random();
            int sayi = rst.Next(1000, 2000);
            txtrandom.Text = sayi.ToString();
        }
    }
}
