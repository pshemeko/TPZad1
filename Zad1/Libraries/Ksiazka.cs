using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class Ksiazka : Egzemplarz
    {
        protected int iloscStron;
        protected string imieAutora;
        protected string nazwiskoAutora;
        protected string isbn;
        protected Rodzaj rodzajEgz;

        public static int kara_Za_Dzien = 3;

        public int IloscStron {get; set;}
        public string ImieAutora { get; set; }
        public string NazwiskoAutora { get; set; }
        public string Isbn { get; set; }
        public Rodzaj RodzajEgz
        {
            get { return rodzajEgz; }
            set { rodzajEgz = value; }
        }

        public Ksiazka(int id, string tytul, Rodzaj rodzajEgz, int iloscStron, string imieAutora, string nazwiskoAutora, string isbn)
            :base(id,tytul)//,rodzajEgz)
        {
            this.iloscStron = iloscStron;
            this.imieAutora = imieAutora;
            this.nazwiskoAutora = nazwiskoAutora;
            this.isbn = isbn;
            this.RodzajEgz = rodzajEgz;
        }

        // ajo ctor na potrzeby XML bez rodzaju
        public Ksiazka(int id, string tytul, int iloscStron, string imieAutora, string nazwiskoAutora, string isbn)
    : base(id, tytul)
        {
            this.iloscStron = iloscStron;
            this.imieAutora = imieAutora;
            this.nazwiskoAutora = nazwiskoAutora;
            this.isbn = isbn;
        }



        public override string ToString()
        {
            string ret = base.ToString();
            ret += " Autor: " + nazwiskoAutora + " " + imieAutora + " ISBN: " + isbn + " Stron:" + iloscStron + " Rodzaj egzemplarza:" + rodzajEgz.ToString("g");        
            return ret;
        }
    }
}
