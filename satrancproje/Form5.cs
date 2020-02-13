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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        
        // Maçları Güncelle
        private void button2_Click(object sender, EventArgs e)
        {
            Form9 mac_guncelle = new Form9();
            mac_guncelle.Show();
            this.Hide();
        }

        // Maç Ekle
        private void button5_Click(object sender, EventArgs e)
        {
            Form7 mac_ekle = new Form7();
            mac_ekle.Show();
            this.Hide();
        }

        // Maç Sil
        private void button1_Click(object sender, EventArgs e)
        {
            Form8 mac_sil = new Form8();
            mac_sil.Show();
            this.Hide();
        }

        // Geri Dön
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
