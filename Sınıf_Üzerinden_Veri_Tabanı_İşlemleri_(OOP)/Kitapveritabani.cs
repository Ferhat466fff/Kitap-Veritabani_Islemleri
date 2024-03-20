using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Sınıf_Üzerinden_Veri_Tabanı_İşlemleri__OOP_
{
    //2.sınıfımız  Kitapveritabani
    internal class Kitapveritabani
    {
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Ferhat\\Documents\\Kitaplık.accdb");


        //LİSTELEME
        public List<Kitap> liste()
        {
            List<Kitap> ktp = new List<Kitap>();//kitap sınıfından ktp adında list oluşturduk
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from Kitaplar", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                Kitap k = new Kitap();//kitap sınıfından k adında değişken oluşturduk
                k.ID =Convert.ToInt16(dr[0].ToString());//ıd-ad-yazar kitap sınıfındaydı k değişkeniyle çektik
                k.KITAPAD = dr[1].ToString();
                k.YAZAR = dr[2].ToString();

                ktp.Add(k);//ktp(kitap sınıfından list) ekle
            }
            baglanti.Close();
            return ktp;//ktp dönder
        }

        //KİTAP EKLEME
        public void kitapekle(Kitap kt)//kt adındaki değişken yardımıyla 1.sınıfımızın(kitap)verilerini aldık
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO Kitaplar (kitapad,Yazar) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", kt.KITAPAD);
            komut.Parameters.AddWithValue("@p2", kt.YAZAR);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        //GÜNCELLEME
        public void guncelle(Kitap fe)//fe adındaki değişken yardımıyla 1.sınıfımızın(kitap)verilerini aldık
        { 
             baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Update Kitaplar set kitapad=@p1,Yazar=@p2 where id=@p3 ", baglanti);
            komut.Parameters.AddWithValue("@p1", fe.KITAPAD);
            komut.Parameters.AddWithValue("@p2", fe.YAZAR);
            komut.Parameters.AddWithValue("@p3", fe.ID);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        //SİLME
        public void sil(Kitap ef)//ef adındaki değişken yardımıyla 1.sınıfımızın(kitap)verilerini aldık
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from Kitaplar where id=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", ef.ID);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


    }
}
