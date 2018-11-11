using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class ZdarzenieZwrotu : Zdarzenie
    {
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
            //string s = Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            //if(!kiedyWypozyczyl.Equals(kiedyZwrocil)) s+= " Data zwrotu " + kiedyZwrocil;
            string s = base.ToString();
            s += " Data zwrotu " + kiedyZwrocil;
            if (kara>0) s+= " kara: " + kara + "zł.";
            return s + "\n";
        }

        public string WypiszWszystko()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            //string s = Kto.ToString() + " Pozyczyl: " + Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            //if (!kiedyWypozyczyl.Equals(kiedyZwrocil)) s += " Data zwrotu " + kiedyZwrocil;
            string s = base.WypiszWszystko();
            s += " Data zwrotu " + kiedyZwrocil;
            if (kara > 0) s += " kara: " + kara + "zł.";
            return s + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is ZdarzenieZwrotu)
            {
                var tmp = (ZdarzenieZwrotu)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co)  && kiedyZwrocil.Equals(tmp.kiedyZwrocil) && kara.Equals(tmp.kara);
            }
            else
            {
                return false;
            }
        }

    }
}
