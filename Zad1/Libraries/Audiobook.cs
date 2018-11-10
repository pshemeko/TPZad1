using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    class Audiobook : Egzemplarz
    {
        protected int ilossMinut;
        protected string ktoCzyta;

        public int IloscMinut { get; set; }
        public string KtoCzyta { get; set; }

        public Audiobook(int id, string tytul, Rodzaj rodzajEgz, int iloscMinut, string ktoCzyta)
    : base(id, tytul) //, rodzajEgz)
        {
            this.ilossMinut = iloscMinut;
            this.ktoCzyta = ktoCzyta;
        }

        public override string ToString()
        {
            string ret = base.ToString();
            ret += " Ilosc minut: " + ilossMinut + " Czyta: " + ktoCzyta;
            return ret;
        }

    }
}
