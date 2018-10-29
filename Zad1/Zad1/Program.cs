using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Wypelnianie wypelnia = new WypelnianieStalymi();
            DataContext dataConstexx = new DataContext();


            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
                //DataContex = dataConstexx;
                //Wypelniacz = wypelnia
                
            };
                     
            DataService data_serwis= new DataService(repozytorium);

            // //serwis.UsunUzytkownika()
            Uzytkownik uzy1 = new Uzytkownik();
            uzy1.Adres = "Piotk";
            uzy1.Imie = "Olek";
            uzy1.Nazwisko = "maly";
            uzy1.Pesel = 12345;

            repozytorium.Wypelnij();
            //Console.WriteLine(repozytorium.pokaz_wszystkich_uzytkownikow());
            //Console.WriteLine("\ndodalem ludka \n\n");
            //repozytorium.AddUzytkownika(uzy1);
            //Console.WriteLine(repozytorium.pokaz_wszystkich_uzytkownikow());

            //Console.WriteLine("\nusunalem uzytkownika\n");
            //repozytorium.DeleteUzytkownik(uzy1);
            //Console.WriteLine(repozytorium.pokaz_wszystkich_uzytkownikow());



            data_serwis.DodajUzytkownika(uzy1);

            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            Console.WriteLine("\nusunalem uzytkownika\n");
            data_serwis.UsunUzytkownika(uzy1);
            ////data_serwis.UsunUzytkownika(uzy1);
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());
            //Console.WriteLine(serwis.WyswietlUzytkownikow());

            Console.WriteLine("Wyswietlanie powiazanych");

            Console.WriteLine(data_serwis.WyswietlanieDanychPowiazanych());
            
            Console.WriteLine("DUPA :-)");

            Console.WriteLine(data_serwis.WyswietlEgzemlarze());
            Console.ReadKey();
        }
    }
}
