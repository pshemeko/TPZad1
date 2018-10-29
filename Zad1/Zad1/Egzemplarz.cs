using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{

    abstract public class Egzemplarz
    {
        protected int id; //klucz
        protected string tytul;
        //protected Boolean stan;
        //protected Boolean zarezerwowany;
        protected Rodzaj rodzajEgz; 
        protected int licznikWypozyczen;

        //public int Id //{ get; set; }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tytul { get; set; }
        //public Boolean Stan { get; set; }
        //public Boolean Zarezerwowany { get; set; }
        public Rodzaj RodzajEgz {get; set;}
        public int LicznikWypozyczen { get; set; }

        public Egzemplarz(int id, string tytul,Rodzaj rodzajEgz)
        {
            this.id = id;
            this.tytul = tytul;
            this.rodzajEgz = rodzajEgz;
            this.licznikWypozyczen = 0;
        }

        public override string ToString()
        {
            string ret = "Identyfikator: " + id + " Rodzaj: " + rodzajEgz;
            //if (stan)
            //{
            //    ret += " Egzmplarz dostepny";
            //}
            //else {
            //    ret += " Egzemplarz Niedostepny";
            //}

            //if (zarezerwowany) ret += " Egzemplarz ZAREZERWOWANY!";

            ret += " Tytul: " + tytul;
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Egzemplarz)
            {
                var tempBook = (Egzemplarz)obj;
                return id.Equals(tempBook.id) && tytul.Equals(tempBook.tytul) && licznikWypozyczen.Equals(tempBook.licznikWypozyczen) 
                    && rodzajEgz.Equals(tempBook.rodzajEgz);
            }
            else
            {
                return false;
            }
        }
    }

}
