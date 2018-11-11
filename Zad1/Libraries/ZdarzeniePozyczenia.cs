using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class ZdarzeniePozyczenia : Zdarzenie
    {
        protected DateTime kiedyWypozyczyl;

        public DateTime KiedyWypozyczyl // musi byc tak pobieranie i zwracanie bo inaczej zle pobiera i zwraca
        {
            get { return kiedyWypozyczyl; }
            set { kiedyWypozyczyl = value; }
        }

        public override string ToString()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            //string s = Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            //return s + "\n";
            return base.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString(); ;
        }

        public override string WypiszWszystko()
        {
            //string s = "Wypożyczone przez: " + kto + // nie musze wyswietlac danych osoby
            //string s = Kto.ToString() + " Pozyczyl: " + Co.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString();
            //return s + "\n";
            return base.WypiszWszystko() + " Data wypożyczenia " + kiedyWypozyczyl.ToString(); ;
        }

        public override bool Equals(object obj)
        {
            if (obj is ZdarzeniePozyczenia)
            {
                var tmp = (ZdarzeniePozyczenia)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co) && kiedyWypozyczyl.Equals(tmp.kiedyWypozyczyl);
            }
            else
            {
                return false;
            }
        }

    }
}