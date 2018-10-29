using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private Wypelnianie wypelniacz;

        public DataRepository(Wypelnianie wyp)
        {
            this.wypelniacz = wyp;
        }

        public DataContext DataContex
        {
            set => dataContext = value;
        }

        //public Wypelnianie Wypelniacz
        //{
        //    set => wypelniacz = value;
        //}

        public void Wypelnij()
        {
            wypelniacz.Wypelnij(ref dataContext);
        }

        ////TODO dodaj inne metody by dodawac elementy jak dodaj/usun/zmien Egzemplarz, Uzytkownika - uwaga rozne klasy bo dziedziczenie
        
        // ******************** Add
        public void AddUzytkownika(Uzytkownik uz)
        {
            dataContext.listaUzytkownikow.Add(uz);
        }

        public void AddEgzemplarz(Egzemplarz eg)
        {
            dataContext.egzemplarze.Add(eg.Id, eg);
        }

        public void AddZdarzenie(Zdarzenie zd)
        {
            dataContext.zdarzenia.Add(zd);
        }

        public void AddZdarzenieWypozyczenie(Uzytkownik uz, Egzemplarz eg, DateTime dataWypoz)
        {
            Zdarzenie zd1 = new Zdarzenie();
            zd1.Kto = uz;
            zd1.Co = eg;
            zd1.KiedyWypozyczyl = dataWypoz;
            zd1.KiedyZwrocil = dataWypoz;
            dataContext.zdarzenia.Add(zd1);
        }

        public void AddZdarzenieZwrot(Uzytkownik uz, Egzemplarz eg, DateTime dataWypoz, DateTime dataZwrotu) // TODO moze wywal
        {
            Zdarzenie zd1 = new Zdarzenie();
            zd1.Kto = uz;
            zd1.Co = eg;
            zd1.KiedyWypozyczyl = dataWypoz;
            zd1.KiedyWypozyczyl = dataZwrotu;
            zd1.Kara = (dataZwrotu - dataWypoz).Days;
            //TimeSpan wynik = dataZwrotu - dataWypoz;
            //zd1.Kara = wynik.Days;
            dataContext.zdarzenia.Add(zd1);
        }

        public void AddOpisStanuEgzemplarza(DateTime dataZakupu, Boolean dostepna, string opisStanu, Egzemplarz ktoryEgzemplarz)
        {
            OpisStanuEgzemplarza ose = new OpisStanuEgzemplarza();
            ose.DataZakupu = dataZakupu;
            ose.Dostepna = dostepna;
            ose.OpisStanu = opisStanu;
            ose.KtoryEgzemplarz = ktoryEgzemplarz;
            dataContext.opisStanow.Add(ose);
        }

        /// ******************** Get

        public Uzytkownik GetUzytkownika(int pesel) //// TODO sprawdz czy dziala  - zmieni ja zeb inaczej dzialala
        {
            Predicate<Uzytkownik> predykat = FindPoints;

            bool FindPoints(Uzytkownik uzyt)
            {
                return uzyt.Pesel == pesel;
            }

            return dataContext.listaUzytkownikow.Find(predykat);
        }

        public Egzemplarz GetEgzemplarz(int id) //// TODO sprawdz czy dziala czy pobiera klucz czy numer elem w kolejnosci
        {

            return dataContext.egzemplarze[id];
        }

        public Zdarzenie GetZdarzenie(int nr)
        {
            return dataContext.zdarzenia[nr];
        }

        public OpisStanuEgzemplarza GetOpisStanuEgzemplarza(int nr)
        {
            return dataContext.opisStanow[nr];
        }


        // ******************** GET ALL

        public List<Uzytkownik> GetAllUzytkownikow()
        {
            return dataContext.listaUzytkownikow;
        }

        public IEnumerable<Egzemplarz> GetAllEgzemplarze()
        {
            //return dataContext.egzemplarze.Values;

            var lista = from Egzemplarz e in dataContext.egzemplarze.Values
                        select e;
            return lista;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenia()
        {
            return from Zdarzenie e in dataContext.zdarzenia
                   select e;
        }


        public List<OpisStanuEgzemplarza> GetAllOpisStanuEgzemplarzas()
        {
            return dataContext.opisStanow;
        }


        // ******************** Update
        public void UpdateUzytkownik(Uzytkownik stary, Uzytkownik nowy)
        {
            stary.Adres = nowy.Adres;
            stary.Imie = nowy.Imie;
            stary.Nazwisko = nowy.Nazwisko;
            stary.Pesel = nowy.Pesel;
        }

        public void UpdateEgzemplarz(Egzemplarz stary, Egzemplarz nowy)
        {
            stary.Id = nowy.Id;
            stary.LicznikWypozyczen = nowy.LicznikWypozyczen;
            stary.Tytul = nowy.Tytul;
            stary.RodzajEgz = nowy.RodzajEgz;
        }

        public void UpdateZdarzenie(Zdarzenie stary, Zdarzenie nowy)
        {
            stary.Co = nowy.Co;
            stary.Kara = nowy.Kara;
            stary.KiedyWypozyczyl = nowy.KiedyWypozyczyl;
            stary.KiedyZwrocil = nowy.KiedyZwrocil;
            stary.Kto = nowy.Kto;
        }

        public void UpdateOpisStanowEgzemplarza(OpisStanuEgzemplarza stary, OpisStanuEgzemplarza nowy)
        {
            stary.DataZakupu = nowy.DataZakupu;
            stary.KtoryEgzemplarz = nowy.KtoryEgzemplarz;
            stary.OpisStanu = nowy.OpisStanu;
            stary.Dostepna = nowy.Dostepna;
        }

        ////// 
        // ******************** Delete

        public Boolean DeleteUzytkownik(Uzytkownik uz)
        {
            return dataContext.listaUzytkownikow.Remove(uz);
        }

        public Boolean DeleteEgzemplarz(int klucz)
        {
            return dataContext.egzemplarze.Remove(klucz);
        }

        public Boolean DeleteZdarzenie(Zdarzenie zd)
        {
            return dataContext.zdarzenia.Remove(zd);
        }

        public Boolean DeleteOpisStanuEgzemplarza(OpisStanuEgzemplarza ose)
        {
            return dataContext.opisStanow.Remove(ose);
        }

        //// ******************** wyswietlanie

        public string pokaz_wszystkich_uzytkownikow()
        {
            string s = "";
            foreach (var item in dataContext.listaUzytkownikow)
            {
               s+= item.ToString();
            }
            //return dataContext.listaUzytkownikow.ToString();
            return s;
        }

        
    }
}
