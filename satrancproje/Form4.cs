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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Boş Alan Kontrolü
        private bool control()
        {
            if (comboBox1.Text == "" || textBox1.Text == "")
            {
                return false;
            }
            else { return true; }
        }

        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");
        OleDbCommand komut = new OleDbCommand();
        int sayac = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            Form6 oyuncu_ayarlari = new Form6();
            oyuncu_ayarlari.Show();
            this.Hide();
        }

        // Oyuncu Güncelle
        private void button1_Click(object sender, EventArgs e)
        {
            if (control() == true)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "update liste set Ad_Soyad = '" + textBox1.Text + "' where Ad_Soyad ='" + comboBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Oyuncu Güncellendi.");
            }
            else { MessageBox.Show("Lütfen Boş Alan Bırakmayınız."); }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
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
    }
}
