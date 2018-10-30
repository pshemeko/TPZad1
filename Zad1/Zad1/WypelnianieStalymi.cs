using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class WypelnianieStalymi : Wypelnianie
    {

        override public void Wypelnij(ref DataContext contex)
        {
            // wypelniam uzytkownikow
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

            //// wypelniam ksiazki
            Egzemplarz e1 = new Ksiazka(1, "c# lekykon kieszonkowy", Rodzaj.popularno_naukowy, 199, "Joseph", "Albahari", "978-83-283-2446-6");
            Egzemplarz e2 = new Ksiazka(2, "Rzeżnik drzew", Rodzaj.fantastyka, 479, "Andrzej", "Pilipiuk", "978-83-7574-937-3");

            contex.egzemplarze.Add(e1.Id, e1);
            contex.egzemplarze.Add(e2.Id, e2);
            //contex.egzemplarze.Add(e1.Id, e1);

            //// wypelniam zdarzenia


            string dateString = "5/1/2008 8:30:52 AM";

            Zdarzenie z1 = new Zdarzenie()
            {
                Kto = u1,
                Co = e1,
                KiedyWypozyczyl = DateTime.Parse(dateString,
                                  System.Globalization.CultureInfo.InvariantCulture),
                KiedyZwrocil = DateTime.Now,
                Kara = 22,
            };

            Zdarzenie z2 = new Zdarzenie
            {
                Kto = u1,
                Co = e2,
                KiedyWypozyczyl = Convert.ToDateTime(dateString),// new DateTime(2018, 6, 8, 16, 0, 0), //01/03/2008 07:00:00
                KiedyZwrocil = DateTime.Today, //new DateTime(2018, 6, 15, 13, 0, 0),
                Kara = 33,
            };

            Zdarzenie z3 = new Zdarzenie
            {
                Kto = u2,
                Co = e1,
                KiedyWypozyczyl = new DateTime(2018, 7, 9, 13, 10, 0), //01/03/2008 07:00:00
                KiedyZwrocil = new DateTime(2018, 7, 9, 13, 10, 0), //01/03/2008 07:00:00
                Kara = 0,
            };

            contex.zdarzenia.Add(z1);
            contex.zdarzenia.Add(z2);
            contex.zdarzenia.Add(z3);

            //// opis stanow egzemplarzy
            OpisStanuEgzemplarza oe1= new OpisStanuEgzemplarza
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
