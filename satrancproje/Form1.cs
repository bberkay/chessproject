using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Ekstra Kütüphane

namespace satrancproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");

        // Sıralama Görüntüle
        private void siralamaGoruntule()
        {
            
            listView3.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText=("Select * From liste");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Ad_Soyad"].ToString());
                ekle.SubItems.Add(oku["Mac_Sayisi"].ToString());
                ekle.SubItems.Add(oku["Puan"].ToString());
                listView3.Items.Add(ekle);
            }
            baglanti.Close();
        }
        // Maçları Görüntüle
        private void maclariGoruntule()
        {
            listView4.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From maclar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Rakip_1"].ToString());
                ekle.SubItems.Add(oku["Rakip_2"].ToString());
                ekle.SubItems.Add(oku["Kazanan"].ToString());
                ekle.SubItems.Add(oku["Kaybeden"].ToString());
                ekle.SubItems.Add(oku["Beraberlik"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Mac_Adi"].ToString());
                listView4.Items.Add(ekle);
            }
            baglanti.Close();
        }

        // Sıralamayı Listeye Yazdır
        private void button7_Click(object sender, EventArgs e)
        {
            siralamaGoruntule();
            listView4.Hide();
            if (listView3.Visible == false)
            {
                listView3.Visible = true;
            }
        }

        // Maçları Listeye Yazdır
        private void button8_Click(object sender, EventArgs e)
        {
            maclariGoruntule();
            listView3.Hide();
            if (listView4.Visible == false)
            {
                listView4.Visible = true;
            }
        }

        // Oyuncu Ayarlarını Aç
        private void button5_Click(object sender, EventArgs e)
        {
            Form6 oyuncu_ayarlari = new Form6();
            oyuncu_ayarlari.Show();
            this.Hide();
        }

        // Maç Ayarlarını Aç
        private void button6_Click(object sender, EventArgs e)
        {
            Form5 mac_ayarlari = new Form5();
            mac_ayarlari.Show();
            this.Hide();
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
