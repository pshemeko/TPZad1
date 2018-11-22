using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;
using Logic;

namespace Zad1.Tests
{
    public class WypelnianieStalymi : IWypelnianie
    {

        public void Wypelnij(ref DataContext contex)
        {
            // ********************wypelniam uzytkownikow********************
            Uzytkownik u1 = new Uzytkownik
            {
                Imie = "Jan",
                Nazwisko = "Niezbedny",
                Pesel = 6389,
                Adres = "Gdanska 3m.22",
            };
            Uzytkownik u2 = new Uzytkownik
            {
                Imie = "Grzegorz",
                Nazwisko = "Brzeczyszczykiewicz",
                Pesel = 111111,
                Adres = "Chrzeszczygrzegoszyce powiad Łękołody"
            };

            contex.listaUzytkownikow.Add(u1);
            contex.listaUzytkownikow.Add(u2);

            //******************** wypelniam ksiazki********************
            Egzemplarz e1 = new Ksiazka(1, "c# lekykon kieszonkowy", Rodzaj.popularno_naukowy, 199, "Joseph", "Albahari", "978-83-283-2446-6");
            Egzemplarz e2 = new Ksiazka(2, "Rzeżnik drzew", Rodzaj.fantastyka, 479, "Andrzej", "Pilipiuk", "978-83-7574-937-3");

            contex.egzemplarze.Add(e1.Id, e1);
            contex.egzemplarze.Add(e2.Id, e2);

            // ********************wypelniam zdarzenia********************


            string dateString = "5/1/2008 8:30:52 AM";

            Zdarzenie z1 = new ZdarzenieZwrotu()
            {
                Kto = u1,
                Co = e1,
                KiedyZwrocil = DateTime.Now,
                Kara = 22,
            };
            Zdarzenie zp1 = new ZdarzeniePozyczenia()
            {
                Kto = u1,
                Co = e1,
                KiedyWypozyczyl = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture),

            };

            Zdarzenie z2 = new ZdarzenieZwrotu
            {
                Kto = u1,
                Co = e2,
                KiedyZwrocil = DateTime.Today, //new DateTime(2018, 6, 15, 13, 0, 0),
                Kara = 33,
            };
            Zdarzenie zp2 = new ZdarzeniePozyczenia
            {
                Kto = u1,
                Co = e2,
                KiedyWypozyczyl = Convert.ToDateTime(dateString),// new DateTime(2018, 6, 8, 16, 0, 0), //01/03/2008 07:00:00

            };

            Zdarzenie z3 = new ZdarzenieZwrotu
            {
                Kto = u2,
                Co = e1,
                KiedyZwrocil = new DateTime(2018, 7, 9, 13, 10, 0), //01/03/2008 07:00:00
                Kara = 0,
            };

            Zdarzenie zp3 = new ZdarzeniePozyczenia
            {
                Kto = u2,
                Co = e1,
                KiedyWypozyczyl = new DateTime(2018, 7, 9, 13, 10, 0), //01/03/2008 07:00:00

            };

            Zdarzenie z4 = new ZdarzeniePozyczenia
            {
                Kto = u2,
                Co = e1,
                KiedyWypozyczyl = new DateTime(2018, 9, 11, 19, 20, 0), //01/03/2008 07:00:00
                
            };

            contex.zdarzenia.Add(z1);
            contex.zdarzenia.Add(zp1);
            contex.zdarzenia.Add(z2);
            contex.zdarzenia.Add(zp2);
            contex.zdarzenia.Add(z3);
            contex.zdarzenia.Add(zp3);
            contex.zdarzenia.Add(z4);

            //******************** opis stanow egzemplarzy********************
            OpisStanuEgzemplarza oe1 = new OpisStanuEgzemplarza
            {
                DataZakupu = new DateTime(2017, 1, 2, 13, 10, 0),
                KtoryEgzemplarz = e1,
                OpisStanu = "Nowa bez uszkodzen",
                Dostepna = true
            };

            OpisStanuEgzemplarza oe2 = new OpisStanuEgzemplarza
            {
                DataZakupu = new DateTime(2017, 1, 2, 13, 10, 0),
                KtoryEgzemplarz = e2,
                OpisStanu = "uszkodzony róg na 4 stronie",
                Dostepna = true
            };

            contex.opisStanow.Add(oe1);
            contex.opisStanow.Add(oe2);

        }
    }
}
