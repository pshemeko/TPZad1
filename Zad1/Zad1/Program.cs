using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Zad1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //Wypelnianie wypelnia = new WypelnianieStalymi();
            Wypelnianie wypelnia = new WypelnianieXMLLinq();
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

            //data_serwis.
            Console.WriteLine("Zdarzenia Wszystkie :");
            ////TODO zle wyswietla daty a raczej źle przekazuje daty w Wypelnianie Stalymi - poprawic moze
            Console.WriteLine(data_serwis.WyswietlWszystkieZdarzenia());



            //////////////// serializuje do XML ze str http://www.altcontroldelete.pl/artykuly/xml-w-c-serializacja-obiektow-do-xmla/
            ///
            //List<Uzytkownik> oPersonsList = new List<Uzytkownik>(); // zamianst tego nasza liste dac
            //int nCounter = 0;
            //oPersonsList.Add(new Uzytkownik(++nCounter, "Jan", "Kowalski", 23));
            //oPersonsList.Add(new Uzytkownik(++nCounter, "Agnieszka", "Nowak", 22));
            //oPersonsList.Add(uzy1);


            List<DateTime> lisaaa = new List<DateTime>();
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Today;

            lisaaa.Add(t1);
            lisaaa.Add(t2);


            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Uzytownik";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<DateTime>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter("dupaaaa.xml");    // w tym pliku zapisuje wszystkich uzytkownikow
                //oSerializer.Serialize(oStreamWriter, data_serwis.ZwrocWszystkichUzytkownikow());   // oPersonsList);
                oSerializer.Serialize(oStreamWriter, lisaaa);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }

            ////////// do tad

            

            Console.WriteLine("DUPA :-)");

            Console.WriteLine(data_serwis.WyswietlEgzemlarze());

            Console.WriteLine("\n i jeszcze osoby:");
            Console.WriteLine(data_serwis.WyswietlWszystkichUzyt());

            Console.WriteLine("\n teraz zdarzenia");
            Console.WriteLine(data_serwis.WyswietlWszystkieZdarzeniaZUzytkownikami());

            Console.WriteLine("\n teraz opisy stanow:");
            Console.WriteLine(data_serwis.WyswietlWszystkieOpisyStanowEgzemplarzy());
            Console.ReadKey();

        }
    }
}
