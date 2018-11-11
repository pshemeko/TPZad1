
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Libraries;
using Logic;
using Fill;


namespace Zad1Tests
{
    class Program
    {
        static void Main(string[] args)
        {


            // IWypelnianie wypelnia = new WypelnianieXMLLinq();
            IWypelnianie wypelnia = new WypelnianieStalymi();
            DataContext dataConstexx = new DataContext();


            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;


            };

            DataService data_serwis = new DataService(repozytorium);

            repozytorium.Wypelnij();

            // ******************************** Do tad zostaw


            Uzytkownik uzy1 = new Uzytkownik();
            uzy1.Adres = "Piotk";
            uzy1.Imie = "Olek";
            uzy1.Nazwisko = "maly";
            uzy1.Pesel = 12345;


            data_serwis.DodajUzytkownika(uzy1);

            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            Console.WriteLine("\nusunalem uzytkownika\n");
            data_serwis.UsunUzytkownika(uzy1);
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());

            Console.WriteLine("Wyswietlanie powiazanych");

            Console.WriteLine(data_serwis.WyswietlanieDanychPowiazanych());


            Console.WriteLine("Zdarzenia Wszystkie :");

            Console.WriteLine(data_serwis.WyswietlWszystkieZdarzenia());



            //////////////// serializuje do XML ze str http://www.altcontroldelete.pl/artykuly/xml-w-c-serializacja-obiektow-do-xmla/
            ///



            List<DateTime> lisaaa = new List<DateTime>();
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Today;

            lisaaa.Add(t1);
            lisaaa.Add(t2);






            Console.WriteLine("DUPA :-)");


            //*************************************************  OD do tad




            Console.WriteLine(data_serwis.WyswietlEgzemlarze());

            Console.WriteLine("\n i jeszcze osoby:");
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());

            Console.WriteLine("\n teraz zdarzenia");
            Console.WriteLine(data_serwis.WyswietlWszystkieZdarzeniaZUzytkownikami());

            Console.WriteLine("\n teraz opisy stanow:");
            Console.WriteLine(data_serwis.WyswietlWszystkieOpisyStanowEgzemplarzy());

            Console.WriteLine("\n wszystkie powiazane:");
            Console.WriteLine(data_serwis.WyswietlanieDanychPowiazanych());

            Console.WriteLine("\n wszystkie powiazane Ksiazki:");
            Console.WriteLine(data_serwis.WyswietlanieKsiazekPowiazanePoStanach());

            Console.WriteLine("\n TESTUJE:");

            Console.WriteLine(repozytorium.pokaz_wszystkich_uzytkownikow());
            repozytorium.AddUzytkownika(uzy1);
            Console.WriteLine(repozytorium.pokaz_wszystkich_uzytkownikow());

            Console.WriteLine(repozytorium.GetUzytkownika(12345).ToString());
            Egzemplarz eg1 = new Ksiazka(9090, "I co ty tu robisz", Rodzaj.fantastyka, 120, "Ilona", "Zmeczona", "IISSBBNN");
            //eg1.Id = 9090;
            //eg1.Tytul = "I co ty tu robisz";
            repozytorium.AddEgzemplarz(eg1);
            Console.WriteLine("\n licz:");
            Console.WriteLine(repozytorium.GetEgzemplarz(9090));

            Console.WriteLine(repozytorium.pokaz_wszystkie_Egzeplarze());

            repozytorium.DeleteEgzemplarz(9090);
            Console.WriteLine("\n Testuje kasowanie Egzemplarza");

            Console.WriteLine(repozytorium.pokaz_wszystkie_Egzeplarze());
            //////////////////////
            Console.WriteLine("\n Testuje w dataService");
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            Uzytkownik uzy2 = new Uzytkownik();
            uzy2.Adres = "Wiejska";
            uzy2.Imie = "Gzresiek";
            uzy2.Nazwisko = "Halama";
            uzy2.Pesel = 22334;
            data_serwis.DodajUzytkownika(uzy2);
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            Console.WriteLine("\n teraz nowak");
            data_serwis.ZmienNazwiskoUzytkownika(uzy2, "Nowak");
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            data_serwis.UsunUzytkownika(uzy2);
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());


            Egzemplarz eg2 = new Ksiazka(2030, "Co na obiad", Rodzaj.romans, 120, "Guzik", "Pentelka", "IISS");
            data_serwis.DodajEgzemplarz(eg2);

            Console.WriteLine(data_serwis.WyswietlEgzemlarze());
            data_serwis.UsunEgzemplarz(eg2);
            Console.WriteLine(data_serwis.WyswietlEgzemlarze());

            //////////////////// czy zmienia sie licznik wypozyczen
            ///
            data_serwis.DodajEgzemplarz(eg2);
            data_serwis.DodajUzytkownika(uzy2);
            Console.WriteLine(data_serwis.WyswietlWszystkieOpisyStanowEgzemplarzy());
            //ZdarzeniePozyczenia zda1 = new ZdarzeniePozyczenia()
            //{
            //    Kto = uzy2,
            //    Co = eg2,
            //    KiedyWypozyczyl = DateTime.Now
            //};
            //ZdarzenieZwrotu zda2 = new ZdarzenieZwrotu
            //{
            //    Kto = uzy2,
            //    Co = eg2,
            //    KiedyZwrocil =  DateTime.Now,
            //    Kara =  0
            //};
            data_serwis.Wypozycz(uzy2, eg2);
            data_serwis.Zwroc(uzy2, eg2);
            data_serwis.Wypozycz(uzy2, eg2);

            Console.WriteLine(data_serwis.WyswietlWszystkieOpisyStanowEgzemplarzy());



            Console.ReadKey();


        }
    }
}
