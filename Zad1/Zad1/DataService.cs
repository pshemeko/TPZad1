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


        public DataService( DataRepository repo)
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

        
        public Boolean UsunUzytkownika(Uzytkownik uz)
        {
            Boolean usunieto = false;
            if (!repozytorium.DeleteUzytkownik(uz))
            {
                usunieto = true;
            }
            return usunieto;
        }

        public Boolean DodajUzytkownika(Uzytkownik uz) 
        {
            Boolean dodano = false;
            if (! (repozytorium.GetAllUzytkownikow().Contains(uz)))
            {
                repozytorium.AddUzytkownika(uz);
                dodano = true;
            }
            return dodano;

        }

        public Boolean ZmienNazwiskoUzytkownika(Uzytkownik uz, string nazw)   
        {
            Boolean zmieniono = false;
            if ((repozytorium.GetAllUzytkownikow().Contains(uz)))
            {
                Uzytkownik tmp = uz;
                tmp.Nazwisko = nazw;
                repozytorium.UpdateUzytkownik(uz, tmp);
                zmieniono = true;
            }
            return zmieniono;

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

        public void UsunEgzemplarz(Egzemplarz e)
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
                    ZdarzeniePozyczenia zd = new ZdarzeniePozyczenia();
                    zd.Co = eg;
                    zd.Kto = uz;
                    zd.KiedyWypozyczyl = DateTime.Now;

                    repozytorium.AddZdarzenie(zd);

                    znalezionyOpis.Dostepna = false;
                    czyWypozyczy = true;
                    znalezionyOpis.LicznikWypozyczen = znalezionyOpis.LicznikWypozyczen + 1;    // zwiekrzam licznik wyypozyczen
                }
            }
            return czyWypozyczy;
        }




        public bool Zwroc(Uzytkownik uz, Egzemplarz eg) 
        {
            
            Boolean CzyZwrocil = false;

            if (repozytorium.GetAllUzytkownikow().Contains(uz))
            {

                Predicate<OpisStanuEgzemplarza> predykat = CzyEgzemplarz;

                bool CzyEgzemplarz(OpisStanuEgzemplarza opis)
                {
                    return opis.Equals(eg);
                }

                OpisStanuEgzemplarza znalezionyOpis = repozytorium.GetAllOpisStanuEgzemplarza().Find(predykat);

                if (!znalezionyOpis.Dostepna)
                {
                    ZdarzenieZwrotu zd = new ZdarzenieZwrotu();
                    zd.Co = eg;
                    zd.Kto = uz;
                    zd.KiedyZwrocil = DateTime.Now;

                    repozytorium.AddZdarzenie(zd);

                    znalezionyOpis.Dostepna = true;
                    CzyZwrocil = true;
                }
            }
            return CzyZwrocil;


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


        
    }
}
