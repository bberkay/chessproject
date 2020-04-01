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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");
        OleDbCommand komut = new OleDbCommand();
        int sayac = 0;
        
        // Boş Alan Kontrolü
        private bool control()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || textBox1.Text == "" || textBox7.Text == "")
            {
                return false;
            }
            else { return true; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Geri Dön Tuşu 
            Form5 mac_ayarlari = new Form5();
            mac_ayarlari.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(control() == true) {
            // Kazananı Güncelleme 
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update maclar set Rakip_1 = '" + comboBox2.Text + "',Rakip_2= '" + comboBox3.Text + "',Kazanan= '" + comboBox4.Text + "',Kaybeden= '" + comboBox5.Text + "',Tarih= '" + textBox7.Text + "',Mac_Adi= '" + textBox1.Text +  "' where Mac_Adi ='" + comboBox1.Text + "'";
            komut.ExecuteNonQuery();
            OleDbCommand komut3 = new OleDbCommand();
            OleDbCommand isim = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik",baglanti);
            isim.Parameters.AddWithValue("@kimlik",comboBox4.Text);
            OleDbDataReader oku = isim.ExecuteReader();
            while (oku.Read())
            {
                // Oyuncuya Puan Ekle
                komut3.Connection = baglanti;
                int eksi_puan2 = Convert.ToInt16(oku["Puan"]);
                komut3.CommandText = "update liste set Mac_Sayisi= '" + oku["Mac_Sayisi"] + "',Puan= '" + Convert.ToInt16(eksi_puan2 + 3) + "' where Ad_Soyad ='" + comboBox4.Text + "'";
                komut3.ExecuteNonQuery();
            }

            // Kaybedeni Güncelleme
            OleDbCommand komut4 = new OleDbCommand();
            OleDbCommand isim2 = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik2",baglanti);
            isim2.Parameters.AddWithValue("@kimlik2",comboBox5.Text);
            OleDbDataReader oku2 = isim2.ExecuteReader();
            while (oku2.Read())
            {
                // Oyuncudan Puan Sil
                komut4.Connection = baglanti;
                int eksi_puan = Convert.ToInt16(oku2["Puan"]);
                int eksi_puan_kontrol = Convert.ToInt16(oku2["Puan"])-3;
                if(eksi_puan_kontrol < 0)
                {
                   eksi_puan = 0;
                   komut4.CommandText = "update liste set Mac_Sayisi= '" + oku2["Mac_Sayisi"] + "',Puan= '" + Convert.ToInt16(eksi_puan) + "' where Ad_Soyad ='" + comboBox5.Text + "'";
                }
                else
                {
                   komut4.CommandText = "update liste set Mac_Sayisi= '" + oku2["Mac_Sayisi"] + "',Puan= '" + Convert.ToInt16(eksi_puan-3) + "' where Ad_Soyad ='" + comboBox5.Text + "'";
                }
                komut4.ExecuteNonQuery();
            }
            baglanti.Close();
                MessageBox.Show("Maç Güncellendi.");
            }
            else { MessageBox.Show("Lütfen Boş Alan Bırakmayınız"); }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // ComboBox 'a Maçları Sıralama
            if (sayac < 1)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select Mac_Adi From maclar");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add(oku["Mac_Adi"].ToString());
                }
                baglanti.Close();
                sayac++;
            }
            else
            {
                sayac = 0;
                comboBox1.Items.Clear();
            }
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            // ComboBox 'a İsimleri Yazdırma
            if (sayac < 1)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select Ad_Soyad From liste");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["Ad_Soyad"].ToString());
                }
                baglanti.Close();
                sayac++;
            }
            else
            {
                sayac = 0;
                comboBox2.Items.Clear();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            // ComboBox 'a İsimleri Yazdırma
            if (sayac < 1)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select Ad_Soyad From liste");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["Ad_Soyad"].ToString());
                }
                baglanti.Close();
                sayac++;
            }
            else
            {
                sayac = 0;
                comboBox3.Items.Clear();
            }
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            // ComboBox 'a İsimleri Yazdırma
            if (sayac < 1)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select Ad_Soyad From liste");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku["Ad_Soyad"].ToString());
                }
                baglanti.Close();
                sayac++;
            }
            else
            {
                sayac = 0;
                comboBox4.Items.Clear();
            }
        }

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            // ComboBox 'a İsimleri Yazdırma
            if (sayac < 1)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = ("Select Ad_Soyad From liste");
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox5.Items.Add(oku["Ad_Soyad"].ToString());
                }
                baglanti.Close();
                sayac++;
            }
            else
            {
                sayac = 0;
                comboBox5.Items.Clear();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
