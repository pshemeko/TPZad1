using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Logic
{
    public class DataRepository
    {
        private DataContext dataContext;
        private IWypelnianie wypelniacz;

        public DataRepository(IWypelnianie wyp)
        {
            this.wypelniacz = wyp;
        }

        public DataContext DataContex
        {
            set => dataContext = value;
        }
        
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
        
        public void AddOpisStanuEgzemplarza(OpisStanuEgzemplarza opisStanu)
        {
            dataContext.opisStanow.Add(opisStanu);
        }


        /// ******************************** Get

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

        public OpisStanuEgzemplarza GetOpisStanuEgzemplarzaNr(int nr)
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

        public List<OpisStanuEgzemplarza> GetAllOpisStanuEgzemplarza()
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
            stary.Tytul = nowy.Tytul;
        }

        public void UpdateZdarzeniePozyczenie(ZdarzeniePozyczenia stary, ZdarzeniePozyczenia nowy)
        {
            stary.Kto = nowy.Kto;
            stary.Co = nowy.Co;
            stary.KiedyWypozyczyl = nowy.KiedyWypozyczyl;
            
            
        }
        public void UpdateZdarzenieZwrotu(ZdarzenieZwrotu stary, ZdarzenieZwrotu nowy)
        {
            stary.Co = nowy.Co;
            stary.Kara = nowy.Kara;
            stary.KiedyZwrocil = nowy.KiedyZwrocil;
            stary.Kto = nowy.Kto;
        }

        public void UpdateZdarzenie(Zdarzenie stary, Zdarzenie nowy)
            {
            stary = nowy;
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

        //// ******************** rozmiar

        public int SizeOfUzytkownicy()
        {
            return dataContext.listaUzytkownikow.Count;
        }

        public int SizeOfEgzemplarze()
        {
            return dataContext.egzemplarze.Count;
        }

        public int SizeOfZdarzenia()
        {
            return dataContext.zdarzenia.Count;
        }

        public int SizeOfOpisStanow()
        {
            return dataContext.opisStanow.Count;
        }
        
        //// ******************** wyswietlanie

        public string pokaz_wszystkich_uzytkownikow()
        {
            string s = "";
            foreach (var item in dataContext.listaUzytkownikow)
            {
               s+= item.ToString() + "\n";
            }
            return s;
        }

        
    }
}
