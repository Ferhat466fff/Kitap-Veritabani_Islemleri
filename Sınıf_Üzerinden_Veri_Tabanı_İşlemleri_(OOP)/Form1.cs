using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sınıf_Üzerinden_Veri_Tabanı_İşlemleri__OOP_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Kitapveritabani vtsinif = new Kitapveritabani();//Kitapveritabani vtsinif adında değişken açtık
        private void btn_Listele_Click(object sender, EventArgs e)
        {   //listeleme
            dataGridView1.DataSource = vtsinif.liste();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {//kaydetme
            Kitap m = new Kitap();//kitap sınıfından m adında değişken verdik
            m.KITAPAD= txt_Kitap_Adi.Text ;//ve adi-yazarı aldık  değişken yardımıyla
            m.YAZAR=txt_Yazari.Text;
            vtsinif.kitapekle(m);//Kitapveritabanı.kitapekle(-->Kitapveritabanı kitap ekle methodu(m-->kitap sınıfı))
            MessageBox.Show("Kitap Başarıtla eklebdi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {   //Güncelleme
            Kitap w = new Kitap();
            w.KITAPAD = txt_Kitap_Adi.Text;
            w.YAZAR = txt_Yazari.Text;
            w.ID =short.Parse(txt_ID.Text);//ıd int oldugundan short.parse kullandık
            vtsinif.guncelle(w);//Kitapveritabanı.güncelle(-->Kitapveritabanı güncelle methodu(m-->kitap sınıfı))
            MessageBox.Show("Kitabınız Başaryla Güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Kitap_Adi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Yazari.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {  //Silme
            Kitap l = new Kitap();
            l.ID = int.Parse(txt_ID.Text);//ıdye göre silecek
            vtsinif.sil(l);
            MessageBox.Show("Kitabınız Sistemden Silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
