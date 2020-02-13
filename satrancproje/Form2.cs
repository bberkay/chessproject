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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // Bağlantılar
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=satrancdatabase2.mdb");
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Boş Alan Kontrolü
        private bool control()
        {
            if(textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                return false;
            }
            else { return true; }
        }
        // Oyuncu Ekle
        private void button1_Click(object sender, EventArgs e)
        {
            if (control() == true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into liste(Ad_Soyad,Mac_Sayisi,Puan) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Oyuncu Eklendi");
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız.");
            }
            
        }

        // Geri Dön
        private void button2_Click(object sender, EventArgs e)
        {
            Form6 oyuncu_ayarlari = new Form6();
            oyuncu_ayarlari.Show();
            this.Hide();
        }
    }
}
