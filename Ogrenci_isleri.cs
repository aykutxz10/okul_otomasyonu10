using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _12_aralıködev
{
    public partial class Ogrenci_isleri : Form
    {
        public Ogrenci_isleri()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            string ogrenciAd = textBox1.Text;
            string ogrenciSoyad = textBox2.Text;
            string ogrenciNo = textBox3.Text;

            bool sonuc = Ogrenci_isleri.(ogrenciAd, ogrenciSoyad, ogrenciNo);

            if (sonuc)
            {
                MessageBox.Show("Öğrenci eklendi!");
            }
            else
            {
                MessageBox.Show("Öğrenci eklenirken bir hata oluştu.");
            }

            // Formu temizle
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string ogrenciNo = textBox3.Text;
            string ogrenciAd = textBox1.Text;
            string ogrenciSoyad = textBox2.Text;

            bool sonuc = Ogrenci_isleri.OgrenciGuncelle(ogrenciNo, ogrenciAd, ogrenciSoyad);

            if (sonuc)
            {
                MessageBox.Show("Öğrenci bilgileri güncellendi!");
            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı!");
            }

            // Formu temizle
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ogrenciNo = textBox3.Text;

            bool sonuc = Ogrenci_isleri.b(ogrenciNo);

            if (sonuc)
            {
                MessageBox.Show("Öğrenci silindi!");
            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı!");
            }

            // Formu temizle
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ogrenci_isleri_ders Ogrenci_isleri = new Ogrenci_isleri_ders();
            Ogrenci_isleri.Show();
            this.Hide();
        }
    }

}
        
    

    

