using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class BazaEgzemplarzy
    {

        protected List<Egzemplarz> katalogEgzemplarzy;

        public List<Egzemplarz> PobierzKatalogEgzemplarzy()
        {
            return katalogEgzemplarzy;
        }

        public void DodajEgzemplarz(Egzemplarz egz)
        {
            katalogEgzemplarzy.Add(egz);
        }

        public void usunEgzemplarz(Egzemplarz egz)
        {
            katalogEgzemplarzy.Remove(egz);
        }

        public Egzemplarz WyszukajPoId(int id)
        {
            katalogEgzemplarzy
        }
    }
}
