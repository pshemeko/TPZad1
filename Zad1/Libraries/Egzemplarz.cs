using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{

    abstract public class Egzemplarz
    {
        protected int id; //klucz
        protected string tytul;
        //protected Boolean stan;
        //protected Boolean zarezerwowany;
        //protected Rodzaj rodzajEgz; 
        

        //public int Id //{ get; set; }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tytul { get; set; }
        //public Boolean Stan { get; set; }
        //public Boolean Zarezerwowany { get; set; }
        //public Rodzaj RodzajEgz {get; set;}
       

        //public Egzemplarz(int id, string tytul,Rodzaj rodzajEgz)
        //{
        //    this.id = id;
        //    this.tytul = tytul;
        //    this.rodzajEgz = rodzajEgz;
        //   // this.licznikWypozyczen = 0;
        //}

        // ajo ctor na potrzemy XMLa bez rodzaju
        public Egzemplarz(int id, string tytul)
        {
            this.id = id;
            this.tytul = tytul;

        }



        public override string ToString()
        {
            string ret = "Id: " + id.ToString() ;
            //if (stan)
            //{
            //    ret += " Egzmplarz dostepny";
            //}
            //else {
            //    ret += " Egzemplarz Niedostepny";
            //}

            //if (zarezerwowany) ret += " Egzemplarz ZAREZERWOWANY!";

            ret += " Tytul: " + tytul.ToString();
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Egzemplarz)
            {
                var tempBook = (Egzemplarz)obj;
                return id.Equals(tempBook.id) && tytul.Equals(tempBook.tytul); //&& rodzajEgz.Equals(tempBook.rodzajEgz);//&& licznikWypozyczen.Equals(tempBook.licznikWypozyczen) 
            }
            else
            {
                return false;
            }
        }
    }

}
