using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Zdarzenie
    {
        protected Uzytkownik kto;
        protected Egzemplarz co;
        protected DateTime kiedyWypozyczyl;
        protected DateTime kiedyZwrocil;
        protected int kara;

        //public Zdarzenie (Uzytkownik uzytkownik, Egzemplarz egzemplarz, DateTime dataWypozyczenia, DateTime dataZwrotu, int kara)
        //{
        //    this.kto = uzytkownik;
        //    this.co = egzemplarz;
        //    this.kiedyWypozyczyl = dataWypozyczenia;
        //    this.kiedyZwrocil = dataZwrotu;
        //    this.kara = kara;                 
        //}

        public Uzytkownik Kto { get; set; }
        public Egzemplarz Co { get; set;}
        public DateTime KiedyWypozyczyl { get; set; }
        public DateTime KiedyZwrocil { get; set; }
        public int Kara { get; set; }

        public override string ToString()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            string s = " Pozyczyl " + co + "Data wypożyczenia " + kiedyWypozyczyl;
            if(kiedyWypozyczyl != kiedyZwrocil) s+= " Data zwrotu " + kiedyZwrocil;
            if (kara>0) s+= " kara: " + kara + "zl.";
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj is Zdarzenie)
            {
                var tmp = (Zdarzenie)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co) && kiedyWypozyczyl.Equals(tmp.kiedyWypozyczyl) && kiedyZwrocil.Equals(tmp.kiedyZwrocil) && kara.Equals(tmp.kara);
            }
            else
            {
                return false;
            }
        }

    }
}
