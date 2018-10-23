using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class DataService
    {
        private DataRepository repozytorium;


        public DataService(DataRepository repo)
        {
            repozytorium = new DataRepository();
            repozytorium = repo;
        }

        //
        public string WyswietlUzytkownikow(IEnumerable<Uzytkownik> obj)
        {
            string st = "";
            foreach(Uzytkownik uz in obj)
            {
                st += uz + "\n";
            }
            return st;
        }

        public string WyswietlEgzemlarz(IEnumerable<Egzemplarz> obj)
        {
            string st = "";
            foreach (Egzemplarz uz in obj)
            {
                st += uz + "\n";
            }
            return st;
        }

        public string WyswietlZdarzenie(IEnumerable<Zdarzenie> obj)
        {
            string st = "";
            foreach (Zdarzenie uz in obj)
            {
                st += uz + "\n";
            }
            return st;
        }

        public string WyswietlOpisStanuEgzemplarza(IEnumerable<OpisStanuEgzemplarza> obj)
        {
            string st = "";
            foreach (OpisStanuEgzemplarza uz in obj)
            {
                st += uz + "\n";
            }
            return st;
        }


        //TODO jak zrobic te funkcje bo nie mam fukcji w DataRepository
        //public string WyswietlCalaZawartosc()
        //{
        //    string st = "";
        //    foreach (Egzemplarz eg in repozytorium.)

        //}


    }
}
