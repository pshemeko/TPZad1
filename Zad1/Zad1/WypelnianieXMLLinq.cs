using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;

namespace Zad1
{
    class WypelnianieXMLLinq : Wypelnianie
    {



        override public void Wypelnij(ref DataContext contex)
        {

            //dodajemy osoby
            XDocument xml = XDocument.Load("..//..//Dane.xml");

            List<Uzytkownik> listaU = (
                from osoba in xml.Root.Elements("osoba")
                select new Uzytkownik
                    (
                    osoba.Element("imie").Value,
                    osoba.Element("nazwisko").Value,
                    int.Parse(osoba.Element("pesel").Value),
                    osoba.Element("adres").Value
                    )
            ).ToList<Uzytkownik>();


            for (int i = 0; i < listaU.Count; i++)
            {
                contex.listaUzytkownikow.Add(listaU.ElementAt(i));
            }

            ////////////////////////////////////////////////////////////////////////////
            //dodajemy ksiazki

            //XDocument xmlKsiazki = XDocument.Load("..//..//DaneKsiazek.xml");

            List<Egzemplarz> lista = (
            from ksiazka in xml.Root.Elements("ksiazka")
            select new Ksiazka
        (
        int.Parse(ksiazka.Element("id").Value),
        ksiazka.Element("tytul").Value,
        // ksiazka.
        int.Parse(ksiazka.Element("iloscStron").Value),
        ksiazka.Element("imieAutora").Value,
        ksiazka.Element("nazwiskoAutora").Value,
        ksiazka.Element("isbn").Value
        )
    ).ToList<Egzemplarz>();

            //contex.egzemplarze.Add(e1.Id, e1);
            //contex.egzemplarze.Add(lista.ElementAt(1).Id, lista.ElementAt(1));


            for (int i = 0; i < lista.Count; i++)
            {

                contex.egzemplarze.Add(lista.ElementAt(i).Id, lista.ElementAt(i));

            }

            ////////////////////////////////////////////////////////////////////////////
            //dodajemy wypozyczenia

            var zd = new Zdarzenie[10];



            for (int i = 0; i < 10; i++)
            {

                zd[i] = new Zdarzenie

                {
                    Kto = listaU.ElementAt(i),
                    Co = lista.ElementAt(i),
                    KiedyWypozyczyl = new DateTime(2018, 7, 9, 13, 10, 0), // tu randoma mozna dac
                    Kara = 0,
                };

                contex.zdarzenia.Add(zd[i]);
            }

        }
    }
}
