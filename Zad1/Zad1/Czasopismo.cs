using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Czasopismo :Egzemplarz
    {
        protected string wydanie;
        protected string isbn;

        public string Wydanie { get; set; }
        public string Isbn { get; set; }


        public Czasopismo(int id, string tytul, Rodzaj rodzajEgz,  string wydanie,  string isbn)
            : base(id, tytul, rodzajEgz)
        {
            this.wydanie = wydanie;
            this.isbn = isbn;
        }

        public override string ToString()
        {
            string ret = base.ToString();
            ret += " Wydanie: " + wydanie + " ISBN: " + isbn;
            return ret;
        }

    }
}
