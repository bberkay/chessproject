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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");
        int sayac = 0;

        // Boş Alan Kontrolü
        private bool control()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                return false;
            }
            else { return true; }
        }

        // Geri Dön
        private void button2_Click(object sender, EventArgs e)
        {
            Form5 mac_ayarlari = new Form5();
            mac_ayarlari.Show();
            this.Hide();
        }

        // Maç Ekle
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand();
                OleDbCommand komut = new OleDbCommand("insert into maclar(Rakip_1,Rakip_2,Kazanan,Kaybeden,Beraberlik,Tarih,Mac_Adi) values ('" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + null + "','" + null + "','" + label8.Text + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();

                // Taraf 1
                OleDbCommand isim = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik", baglanti);
                isim.Parameters.AddWithValue("@kimlik", comboBox1.Text);
                OleDbDataReader oku = isim.ExecuteReader();
                while (oku.Read())
                {
                    // Oyuncuya Puan Ekle
                    komut3.Connection = baglanti;
                    int ekstra_puan = Convert.ToInt16(oku["Puan"]);
                    int ekstra_mac = Convert.ToInt16(oku["Mac_Sayisi"]);
                    komut3.CommandText = "update liste set Mac_Sayisi= '" + Convert.ToInt16(ekstra_mac + 1) + "',Puan= '" + Convert.ToInt16(ekstra_puan + 1) + "' where Ad_Soyad ='" + comboBox1.Text + "'";
                    komut3.ExecuteNonQuery();
                }

                // Taraf 2
                OleDbCommand isim2 = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik2", baglanti);
                isim2.Parameters.AddWithValue("@kimlik2", comboBox2.Text);
                OleDbDataReader oku2 = isim2.ExecuteReader();
                while (oku2.Read())
                {
                    // Oyuncuya Puan Ekle
                    komut3.Connection = baglanti;
                    int ekstra_puan = Convert.ToInt16(oku2["Puan"]);
                    int ekstra_mac = Convert.ToInt16(oku2["Mac_Sayisi"]);
                    komut3.CommandText = "update liste set Mac_Sayisi= '" + Convert.ToInt16(ekstra_mac + 1) + "',Puan= '" + Convert.ToInt16(ekstra_puan + 1) + "' where Ad_Soyad ='" + comboBox2.Text + "'";
                    komut3.ExecuteNonQuery();
                }
                MessageBox.Show("Maç Eklendi.");
            }
            else
            {
                if (control() == true)
                {
                    baglanti.Open();
                    OleDbCommand komut3 = new OleDbCommand();
                    OleDbCommand komut = new OleDbCommand("insert into maclar(Rakip_1,Rakip_2,Kazanan,Kaybeden,Beraberlik,Tarih,Mac_Adi) values ('" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + null + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();

                    // Kazanan Taraf
                    OleDbCommand isim = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik", baglanti);
                    isim.Parameters.AddWithValue("@kimlik", comboBox3.Text);
                    OleDbDataReader oku = isim.ExecuteReader();
                    while (oku.Read())
                    {
                        // Oyuncuya Puan Ekle
                        komut3.Connection = baglanti;
                        int ekstra_puan = Convert.ToInt16(oku["Puan"]);
                        int ekstra_mac = Convert.ToInt16(oku["Mac_Sayisi"]);
                        komut3.CommandText = "update liste set Mac_Sayisi= '" + Convert.ToInt16(ekstra_mac + 1) + "',Puan= '" + Convert.ToInt16(ekstra_puan + 3) + "' where Ad_Soyad ='" + comboBox3.Text + "'";
                        komut3.ExecuteNonQuery();
                    }

                    // Kaybeden Taraf
                    OleDbCommand isim2 = new OleDbCommand("Select Puan,Mac_Sayisi from liste where Ad_Soyad= @kimlik", baglanti);
                    isim2.Parameters.AddWithValue("@kimlik", comboBox4.Text);
                    OleDbDataReader oku2 = isim2.ExecuteReader();
                    while (oku2.Read())
                    {
                        // Oyuncuya Puan Ekle
                        komut3.Connection = baglanti;
                        int ekstra_puan = Convert.ToInt16(oku2["Puan"]);
                        int ekstra_mac = Convert.ToInt16(oku2["Mac_Sayisi"]);
                        komut3.CommandText = "update liste set Mac_Sayisi= '" + Convert.ToInt16(ekstra_mac + 1) + "',Puan= '" + Convert.ToInt16(ekstra_puan) + "' where Ad_Soyad ='" + comboBox4.Text + "'";
                        komut3.ExecuteNonQuery();
                    }

                    baglanti.Close();
                    MessageBox.Show("Maç Eklendi.");
                }
                else { MessageBox.Show("Lütfen Boş Alan Bırakmayınız."); }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        // Combobax a Oyuncuları Yazdırma
        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(sayac < 1) { 
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select Ad_Soyad From liste");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["Ad_Soyad"].ToString());
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

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Combobax a Oyuncuları Yazdırma
        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
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

        // Combobax a Oyuncuları Yazdırma
        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
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

        // Combobax a Oyuncuları Yazdırma
        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_MouseClick_1(object sender, MouseEventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
