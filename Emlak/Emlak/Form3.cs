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


namespace Emlak
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-8S744SR;Initial Catalog=Emlak;Integrated Security=True");

        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From KonutKayit", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["KayıtTarihi"].ToString());
                ekle.SubItems.Add(oku["Turu"].ToString());
                ekle.SubItems.Add(oku["BinaYasi"].ToString());
                ekle.SubItems.Add(oku["IsinmaSekli"].ToString());
                ekle.SubItems.Add(oku["KatSayisi"].ToString());
                ekle.SubItems.Add(oku["KonutDurumu"].ToString());
                ekle.SubItems.Add(oku["Cephe"].ToString());
                ekle.SubItems.Add(oku["Buyuklugu"].ToString());
                ekle.SubItems.Add(oku["OdaSayisi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["KiralikSatilik"].ToString());
                ekle.SubItems.Add(oku["DigerOzellikler"].ToString());
                ekle.SubItems.Add(oku["AptAdı"].ToString());
                ekle.SubItems.Add(oku["Cadde"].ToString());
                ekle.SubItems.Add(oku["BinaNo"].ToString());
                ekle.SubItems.Add(oku["Aciklama"].ToString());
                ekle.SubItems.Add(oku["Semt"].ToString());
                ekle.SubItems.Add(oku["Mahalle"].ToString());
                ekle.SubItems.Add(oku["Il"].ToString());
                ekle.SubItems.Add(oku["Ilce"].ToString());
                ekle.SubItems.Add(oku["Resim"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }
        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into KonutKayit (Id,KayıtTarihi,Turu,BinaYasi,IsinmaSekli,KatSayisi,KonutDurumu,Cephe,Buyuklugu,OdaSayisi,Fiyat,KiralikSatilik,DigerOzellikler,AptAdı,Cadde,BinaNo,Aciklama,Semt,Mahalle,Il,Ilce,Resim) values ('" + textBox1.Text.ToString() + "','" + textBox14.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox7.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox8.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox13.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }

        int Id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from KonutKayit where Id =(" + Id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox14.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[8].Text;
            comboBox7.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[10].Text;
            comboBox8.Text = listView1.SelectedItems[0].SubItems[11].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[12].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[13].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[14].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[15].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[16].Text;
            textBox12.Text = listView1.SelectedItems[0].SubItems[17].Text;
            textBox11.Text = listView1.SelectedItems[0].SubItems[18].Text;
            textBox10.Text = listView1.SelectedItems[0].SubItems[19].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[20].Text;
            textBox13.Text = listView1.SelectedItems[0].SubItems[21].Text;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update KonutKayit set Id= '" + textBox1.Text.ToString() +
                "',KayıtTarihi= '" + textBox14.Text.ToString() + "',Turu='" + comboBox1.Text.ToString() +
                "',BinaYasi='" + comboBox2.Text.ToString() + "',IsinmaSekli='" + comboBox3.Text.ToString() +
                "',KatSayisi='" + comboBox4.Text.ToString() + "',KonutDurumu='" + comboBox5.Text.ToString() +
                "',Cephe='" + comboBox6.Text.ToString() + "',Buyuklugu='" + textBox2.Text.ToString() +
                "',OdaSayisi='" + comboBox7.Text.ToString() + "',Fiyat='" + textBox3.Text.ToString() + "',KiralikSatilik='" + comboBox8.Text.ToString() +
                "',DigerOzellikler='" + textBox4.Text.ToString() + "',AptAdı='" + textBox5.Text.ToString() +
                "',Cadde='" + textBox6.Text.ToString() + "',BinaNo='" + textBox7.Text.ToString() + 
                "',Aciklama='" + textBox8.Text.ToString() + "',Semt='" + textBox12.Text.ToString() + 
                "', Mahalle='" + textBox11.Text.ToString() + "',Il='" + textBox10.Text.ToString() + 
                "',Ilce='" + textBox9.Text.ToString() + "',Resim='" + textBox13.Text.ToString()+"'where Id=" + Id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }
    }
}
