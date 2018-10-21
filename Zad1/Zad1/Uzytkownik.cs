using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Uzytkownik         //TODO zrobic jako klasa abstrakcyjna
    {
        private string imie;
        private string nazwisko;
        private int pesel;
        private string adres;

        
        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public int Pesel
        {
            get { return pesel; }
            set { pesel = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public override string ToString()
        {
            string ret = "Czytelnik: " + imie + " " + nazwisko + " Adress: " + adres + " Pesel: " + pesel;
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Uzytkownik)
            {
                var tempReader = (Uzytkownik)obj;
                return imie.Equals(tempReader.imie) && nazwisko.Equals(tempReader.nazwisko) && pesel.Equals(tempReader.pesel) && adres.Equals(tempReader.adres);
            }
            else
            {
                return false;
            }
            
        }

    }
}
