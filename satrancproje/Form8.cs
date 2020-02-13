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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");
        int sayac = 0;

        // Boş Alan Kontrolü
        private bool control()
        {
            if (comboBox1.Text == "")
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

        // Maçı Sil
        private void button1_Click(object sender, EventArgs e)
        {
            if (control() == true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "delete from maclar where Mac_Adi = '" + comboBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Maç Silindi.");
            }
            else { MessageBox.Show("Lütfen Boş Alan Bırakmayınız."); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Combobax a Oyuncuları Yazdırma
        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
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
    }
}
