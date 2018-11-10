using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
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
        public DateTime KiedyWypozyczyl // musi byc tak pobieranie i zwracanie bo inaczej zle pobiera i zwraca
            {
                get { return kiedyWypozyczyl; }
                set { kiedyWypozyczyl = value; }
            }
        public DateTime KiedyZwrocil    // musi byc tak pobieranie i zwracanie bo inaczej zle pobiera i zwraca
            {
                get { return kiedyZwrocil; }
                set { kiedyZwrocil = value; }
            }
        public int Kara                 // musi byc tak pobieranie i zwracanie bo inaczej zle pobiera i zwraca
            {
                get { return kara; }
                set { kara = value; }
            }

        public override string ToString()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            string s = Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            if(!kiedyWypozyczyl.Equals(kiedyZwrocil)) s+= " Data zwrotu " + kiedyZwrocil;
            if (kara>0) s+= " kara: " + kara + "zł.";
            return s + "\n";
        }

        public string WypiszWszystko()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            string s = Kto.ToString() + " Pozyczyl: " + Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            if (!kiedyWypozyczyl.Equals(kiedyZwrocil)) s += " Data zwrotu " + kiedyZwrocil;
            if (kara > 0) s += " kara: " + kara + "zł.";
            return s + "\n";
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
