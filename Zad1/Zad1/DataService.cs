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

        //TODO czy nie trzeba dodac tutaj  jeszcze wysietlania Zdarzen
        public string WyswietlanieDanychPowiazanych()
        {
            string s = " ";
            foreach (var osoba in repozytorium.GetAllUzytkownikow())
            {
                s += osoba.ToString() + " ";

                foreach (var elem in repozytorium.GetAllZdarzenia())
                {
                    if(osoba.Equals(elem.Kto))
                    {
                        s += elem.ToString();
                    }

                }
                s += "/n";
            }
            return s;
        }

        //TODO do sprawdzenia i przemyslenia co z elementami zaleznymi od obiektow kasowanych
        public void UsunUzytkownika(Uzytkownik uz)
        {
            if (repozytorium.DeleteUzytkownik(uz)) throw new ArgumentException("Nie ma w repozytorium uzytkownika" + uz.ToString());
        }

        public void DodajUzytkownika(Uzytkownik uz)
        {
            if ( (repozytorium.GetAllUzytkownikow().Contains(uz)))
            {
                repozytorium.AddUzytkownika(uz);
            }
            else throw new ArgumentException("ten uzytkonik juz jest w repozytorium" + uz.ToString());
        }




        //TODO???????? czesc 4 dalej zrobic edytuj zmień





    }
}
