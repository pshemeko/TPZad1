
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
            ////TODO zle wyswietla daty a raczej źle przekazuje daty w Wypelnianie Stalymi - poprawic moze
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

            Console.ReadKey();

        }
    }
}