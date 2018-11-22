using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class OpisStanuEgzemplarza
    {


        public Egzemplarz KtoryEgzemplarz { get; set; }
        public DateTime DataZakupu { get; set; }
        public Boolean Dostepna { get; set; }
        public string OpisStanu { get; set; }
        public int LicznikWypozyczen { get; set; }

        public override string ToString()
        {
            if (KtoryEgzemplarz != null)
            {
                string s = KtoryEgzemplarz.ToString() + " Data zakupu " + DataZakupu + " Stan:" + OpisStanu + " Wypozyczono " + LicznikWypozyczen;
                if (1 == LicznikWypozyczen)
                 { s += " raz.\n"; }
                else s += " razy.\n";
                return s;
            }
            else return "Puste";
        }

        public string ToStringPowiazane()
        {
            if (KtoryEgzemplarz != null)
            {
                string s = " Data zakupu " + DataZakupu + " Stan:" + OpisStanu + " Wypozyczono " + LicznikWypozyczen;
                if (1 == LicznikWypozyczen)
                { s += " raz.\n"; }
                else s += " razy.\n";
                return s;
            }
            else return "Puste";
        }

        public override bool Equals(object obj)
        {
            if (obj is OpisStanuEgzemplarza)
            {
                OpisStanuEgzemplarza tmp = (OpisStanuEgzemplarza)obj;
                return DataZakupu.Equals(tmp.DataZakupu) && KtoryEgzemplarz.Equals(tmp.KtoryEgzemplarz) && Dostepna.Equals(tmp.Dostepna) && OpisStanu.Equals(tmp.OpisStanu);
            }
            else
            {
                return true;
            }
        }
    }
}
