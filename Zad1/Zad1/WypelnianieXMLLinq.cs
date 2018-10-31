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

        public class PotrzebnaDoSynchronizacjiZdarzen
        {
            public int Osoba { get; set; }
            public int Ksiazka { get; set; }
            //public string Wypoz { get; set; }
            //public string Zwrot { get; set; }
            public DateTime Wypoz { get; set; }
            public DateTime Zwrot { get; set; }
            public int Kar { get; set; }

            //public Blabla(int os, int ks, string dw, string dz, int ka)
                public PotrzebnaDoSynchronizacjiZdarzen(int os, int ks, DateTime dw, DateTime dz, int ka)
            {
                this.Osoba = os;
                this.Ksiazka = ks;
                this.Wypoz = dw;
                this.Zwrot = dz;
                this.Kar = ka;
            }
        }

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


            List<PotrzebnaDoSynchronizacjiZdarzen> listaZ = (
            from zdarz in xml.Root.Elements("zdarzenie")
            select new PotrzebnaDoSynchronizacjiZdarzen
                (
                int.Parse(zdarz.Element("kto").Value),
                int.Parse(zdarz.Element("co").Value),
                DateTime.Parse(zdarz.Element("kiedyWypozyczyl").Value),
                DateTime.Parse(zdarz.Element("kiedyZwrocil").Value),
                int.Parse(zdarz.Element("kara").Value)
                )
            ).ToList<PotrzebnaDoSynchronizacjiZdarzen>();

            
            for (int i = 0; i < listaZ.Count; i++)
            {
                // tworze predykaty
                Predicate<Egzemplarz> predykatK = CzyEgzemplarzK;
                bool CzyEgzemplarzK(Egzemplarz opis)
                {
                    return opis.Id.Equals(listaZ.ElementAt(i).Ksiazka);
                }
                
                Predicate<Uzytkownik> predykatU = CzyEgzemplarzU;
                bool CzyEgzemplarzU(Uzytkownik opis)
                {
                    return opis.Pesel.Equals(listaZ.ElementAt(i).Osoba);
                }
                // tworze zdarzenie z predykatow
                Zdarzenie zd = new Zdarzenie();
                zd.Co = lista.Find(predykatK);//  listaZ.ElementAt(i)
                zd.Kto = listaU.Find(predykatU);
                zd.KiedyWypozyczyl = Convert.ToDateTime(listaZ.ElementAt(i).Wypoz);
                zd.KiedyZwrocil = Convert.ToDateTime(listaZ.ElementAt(i).Zwrot); 
                zd.Kara = listaZ.ElementAt(i).Kar;

                //dodaje do repozytorium
                contex.zdarzenia.Add(zd);
            }


        }
    }
}
