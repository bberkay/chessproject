using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satrancproje
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        // Oyuncu Ekle
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 oyuncu_ekle = new Form2();
            oyuncu_ekle.Show();
            this.Hide();
        }

        // Geri Dön
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        // Oyuncu Sil
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 oyuncu_sil = new Form3();
            oyuncu_sil.Show();
            this.Hide();
        }

        // Oyuncu Güncelle
        private void button6_Click(object sender, EventArgs e)
        {
            Form4 oyuncu_guncelle = new Form4();
            oyuncu_guncelle.Show();
            this.Hide();
        }
    }
}
