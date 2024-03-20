using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sınıf_Üzerinden_Veri_Tabanı_İşlemleri__OOP_
{
    internal class Kitap
    {    //2.sınıfımız  Kitap
        int id;
        string kitapad;
        string yazar;//id-kitap-yazar olusturduk cunku acsess tablomuzda 3 stun var

        public int ID
        {
            get { return id; }//geriye dönecek değer id
            set { id = value; }
        }

        public string KITAPAD
        {
            get { return kitapad; }
            set { kitapad = value; }
        }

        public string YAZAR
        {
            get { return yazar; }
            set { yazar = value; }
        }
    }

}
