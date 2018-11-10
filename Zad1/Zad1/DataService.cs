﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Logic
{
    public class DataService
    {
        private DataRepository repozytorium;


        public DataService(DataRepository repo)
        {
            
            repozytorium = repo;
        }


        // ********************** Wyswietlanie **********************
        
        public string WyswietlEgzemlarze()
        {
            string s = "";
            foreach (var item in repozytorium.GetAllEgzemplarze())
            {
                s += item.ToString() + " \n";
            }
            return s;
        }
       
        public string WyswietlWszystkichUzyt()
        {
            return repozytorium.pokaz_wszystkich_uzytkownikow();
        }

        public string WyswietlWszystkieZdarzenia()
        {
            string s = "";
            foreach (var item in repozytorium.GetAllZdarzenia())
            {
                s += item.ToString() + "\n";
            }
            return s;
        }

        public string WyswietlWszystkieZdarzeniaZUzytkownikami()
        {
            string s = "";
            foreach (var item in repozytorium.GetAllZdarzenia())
            {
                s += item.WypiszWszystko() + "\n";
            }
            return s;
        }

        public string WyswietlWszystkieOpisyStanowEgzemplarzy()
        {
            string s = "";
            foreach (var item in repozytorium.GetAllOpisStanuEgzemplarza())
            {
                s += item.ToString() + "\n";
            }
            return s;
        }

        public string WyswietlanieDanychPowiazanych()
        {
            string s = " ";
            foreach (var osoba in repozytorium.GetAllUzytkownikow())
            {
                s += osoba.ToString() + " \n";

                foreach (var elem in repozytorium.GetAllZdarzenia())
                {
                    if (osoba.Equals(elem.Kto))
                    {
                        s += elem.ToString();
                    }

                }
                s += "\n";
            }
            return s;
        }

        public string WyswietlanieKsiazekPowiazanePoStanach()
        {

            string s = "";
            foreach (var egz in repozytorium.GetAllEgzemplarze())
            {
                s += egz.ToString() + " \n";

                foreach (var opis in repozytorium.GetAllOpisStanuEgzemplarza())
                {
                    if (egz.Equals(opis.KtoryEgzemplarz))
                    {
                        s +="\t\t" + opis.ToStringPowiazane();
                    }

                }
                s += "\n";
            }
            return s;

        }


        // ********************** Uzytkownicy **********************

        //TODO do sprawdzenia i przemyslenia co z elementami zaleznymi od obiektow kasowanych bo chyba sie posypie baza jak wyswietlisz zdarzenia pousunieciu uzytkownika
        public void UsunUzytkownika(Uzytkownik uz)
        {
            if (!repozytorium.DeleteUzytkownik(uz)) throw new ArgumentException("Nie ma w repozytorium uzytkownika" + uz.ToString());
        }

        public void DodajUzytkownika(Uzytkownik uz)
        {
            if (! (repozytorium.GetAllUzytkownikow().Contains(uz)))
            {
                repozytorium.AddUzytkownika(uz);
            }
            else throw new ArgumentException("ten uzytkonik juz jest w repozytorium" + uz.ToString());
        }

        public void ZmienNazwiskoUzytkownika(Uzytkownik uz, string nazw)    // TODO Przetestowac czy bedzie ten sam uzytkownik z nowym nazwiskiem czy stworzy totalnie nowego uzytkownika
        {
            if (!(repozytorium.GetAllUzytkownikow().Contains(uz)))
            {
                Uzytkownik tmp = uz;
                tmp.Nazwisko = nazw;
                repozytorium.UpdateUzytkownik(uz, tmp);
            }
            else throw new ArgumentException("tego uzytkownika nie ma w repozytorium" + uz.ToString());
        }

        public List<Uzytkownik> ZwrocWszystkichUzytkownikow()
        {
            return repozytorium.GetAllUzytkownikow();
        }

        public Uzytkownik znajdzUzytkownika(int pesel)
        {
            return repozytorium.GetUzytkownika(pesel);
        }

        // ********************** Egzemplarze **********************

        public void DodajEgzemplarz(Egzemplarz e)
        {
            repozytorium.AddEgzemplarz(e);
        }

        public void UsunEgzemplarz(Egzemplarz e)    // TODO sprawdz czy dziala
        {
            repozytorium.DeleteEgzemplarz(e.Id);
        }

        public void ZmienEgzemplarz(Egzemplarz stary, Egzemplarz nowy)
        {
            repozytorium.UpdateEgzemplarz(stary, nowy);
        }

        public Egzemplarz znajdzEgzemplarz(int id)
        {
            return repozytorium.GetEgzemplarz(id);
        }

        // ********************** Zdarzenia **********************


        public Boolean Wypozycz(Uzytkownik uz, Egzemplarz eg) 
        {
            Boolean czyWypozyczy = false;

            if (repozytorium.GetAllUzytkownikow().Contains(uz))
            {

                Predicate<OpisStanuEgzemplarza> predykat = CzyEgzemplarz;

                bool CzyEgzemplarz(OpisStanuEgzemplarza opis)
                {
                    return opis.Equals(eg);
                }

                OpisStanuEgzemplarza znalezionyOpis = repozytorium.GetAllOpisStanuEgzemplarza().Find(predykat);
                            
                if (znalezionyOpis.Dostepna)
                {
                    Zdarzenie zd = new Zdarzenie();
                    zd.Co = eg;
                    zd.Kto = uz;
                    zd.KiedyWypozyczyl = DateTime.Now;
                    zd.KiedyZwrocil = zd.KiedyWypozyczyl;

                    repozytorium.AddZdarzenie(zd);

                    znalezionyOpis.Dostepna = false;
                    czyWypozyczy = true;
                    znalezionyOpis.LicznikWypozyczen = znalezionyOpis.LicznikWypozyczen + 1;    // zwiekrzam licznik wyypozyczen

                }

            }

            return czyWypozyczy;

        }

        public void Zwroc(Uzytkownik uz, Egzemplarz eg) // TODO Sprawdz czy zmienia w oryginalnej bazie czy dziala na kopii
        {
            IEnumerable<Zdarzenie> zdarzylySie = this.repozytorium.GetAllZdarzenia();
            foreach (var item in zdarzylySie)
            {
                if (item.Co == eg && item.Kto == uz)    // gdy znajde tego uzytkownika i ten egzemplarz
                {
                    if(item.KiedyWypozyczyl == item.KiedyZwrocil) // i gdy to zdarzenie jest ostatnio dodane tj nie jest wczesniejszy wypozyczeniem ksiazki
                                                                    // bo cyba przy utworzeniu nowego data zwrtu est ta sama co wypozyczenia
                    {
                        item.KiedyZwrocil = DateTime.Now;
                        var roznica = (item.KiedyZwrocil - item.KiedyWypozyczyl).TotalDays;
                        if ( roznica > Constans.LIMIT_DNI_WYPOZYCZENIA)
                        {
                            item.Kara = (int)roznica * Constans.KWOTA_KARY_ZA_DZIEN;
                        }
                    }
                }
            }

        }
        
        public void ZmienZdarzenie(Zdarzenie stare, Zdarzenie nowe)
        {
            repozytorium.UpdateZdarzenie(stare, nowe);
        }

        public List<Zdarzenie> ZwrocWszystkieZdarzenia()
        {
            List<Zdarzenie> lis = new List<Zdarzenie>();
            foreach (var item in repozytorium.GetAllZdarzenia())
            {
                lis.Add(item);
            }
            return lis;
        }

        // TODO zrobic rezerwowanie ksiazki oraz wypozyczanie

        // wyswietlic wszystkie wypozyczenia (zdarzenia) uzytkownika



    }
}
