using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;

namespace Zad1
{
    class WypelnianieXMLLinq : IWypelnianie
    {
        ///////   Klasy potrzebne do wczytywania z XML
        
        public class PotrzebnaDoSynchronizacjiZdarzen
        {
            public int Osoba { get; set; }
            public int Ksiazka { get; set; }
            //public string Wypoz { get; set; }
            //public string Zwrot { get; set; }
            public DateTime Wypoz { get; set; }
            public DateTime Zwrot { get; set; }
            public int Kar { get; set; }

            public PotrzebnaDoSynchronizacjiZdarzen(int os, int ks, DateTime dw, DateTime dz, int ka)
            {
                this.Osoba = os;
                this.Ksiazka = ks;
                this.Wypoz = dw;
                this.Zwrot = dz;
                this.Kar = ka;
            }
        }

        public class PotrzebnaDoSynchronizacjiOpisuEgzemplarza
        {
            public int KtoryEgzemplarz { get; set; } // klucz
            public DateTime DataZakupu { get; set; }
            public Boolean Dostepna { get; set; }
            public string OpisStanu { get; set; }
            public int LicznikWypozyczen { get; set; }
            
            public PotrzebnaDoSynchronizacjiOpisuEgzemplarza(int egzemplarz, DateTime dataZakupy, Boolean dostepna, string opisStanu, int licznikWypozyczen)
            {
                this.KtoryEgzemplarz = egzemplarz;
                this.DataZakupu = dataZakupy;
                this.Dostepna = dostepna;
                this.OpisStanu = opisStanu;
                this.LicznikWypozyczen = licznikWypozyczen;
            }
        }

        public class KsiazkaZEnumem
        {
            public int Id { get; set; } //klucz
            public string Tytul { get; set; }

            public int IloscStron { get; set; }
            public string ImieAutora { get; set; }
            public string NazwiskoAutora { get; set; }
            public string Isbn { get; set; }
            public string RodzajEgz { get; set; }

            public KsiazkaZEnumem(int id, string tytul, string rodzajEgz,  int iloscStron, string imieAutora, string nazwiskoAutora, string isbn)
            {
                this.Id = id;
                this.Tytul = tytul;
                this.IloscStron = iloscStron;
                this.ImieAutora = imieAutora;
                this.NazwiskoAutora = nazwiskoAutora;
                this.Isbn = isbn;
                this.RodzajEgz = rodzajEgz;
            }

        }


        //********************* Główna metoda

        public void Wypelnij(ref DataContext contex)
        {

            //**************************** Dodajemy osoby
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
            
            //**************************** Dodajemy ksiazki



        List<KsiazkaZEnumem> lista1 = (
            from ksiazka in xml.Root.Elements("ksiazka")
            select new KsiazkaZEnumem
                (
                int.Parse(ksiazka.Element("id").Value),
                ksiazka.Element("tytul").Value,

                ksiazka.Element("rodzaj").Value,
                //Enum.Parse(typeof(Rodzaj), ksiazka.Element("rodzaj").Value),
                //Rodzaj.ksiazka.Element("rodzaj").Value),
                int.Parse(ksiazka.Element("iloscStron").Value),
                ksiazka.Element("imieAutora").Value,
                ksiazka.Element("nazwiskoAutora").Value,
                ksiazka.Element("isbn").Value
                )
            ).ToList<KsiazkaZEnumem>();

           

            List<Ksiazka> lista = new List<Ksiazka>();

            foreach (var item in lista1)
            {
                
                Rodzaj rodz = (Rodzaj)(Rodzaj)Enum.Parse(typeof(Rodzaj), item.RodzajEgz);

                Ksiazka ks = new Ksiazka(item.Id, item.Tytul, rodz, item.IloscStron, item.ImieAutora, item.NazwiskoAutora, item.Isbn);
                lista.Add(ks);
            }

            //contex.egzemplarze.Add(e1.Id, e1);
            //contex.egzemplarze.Add(lista.ElementAt(1).Id, lista.ElementAt(1));


            for (int i = 0; i < lista.Count; i++)
            {

                contex.egzemplarze.Add(lista.ElementAt(i).Id, lista.ElementAt(i));

            }

            ////////////////////////////////////////////////////////////////////////////
            //**************************** Dodajemy wypozyczenia


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


            ////////////////////////////////////////////////////////////////////////////
            //**************************** Dodajemy opisy Egzemplarza


            List<PotrzebnaDoSynchronizacjiOpisuEgzemplarza> listaO = (
            from opis in xml.Root.Elements("opisstanuegzemplarza")
            select new PotrzebnaDoSynchronizacjiOpisuEgzemplarza
                (
                int.Parse(opis.Element("egzemplarz").Value),
                DateTime.Parse(opis.Element("datazakupu").Value),
                Boolean.Parse(opis.Element("dostepna").Value),
                opis.Element("opisstanu").Value,
                int.Parse(opis.Element("licznikwypozyczen").Value)
                )
            ).ToList<PotrzebnaDoSynchronizacjiOpisuEgzemplarza>();


            for (int i = 0; i < listaO.Count; i++)
            {
                // tworze predykaty
                Predicate<Egzemplarz> predykatK = CzyEgzemplarzK;
                bool CzyEgzemplarzK(Egzemplarz opis)
                {
                    return opis.Id.Equals(listaO.ElementAt(i).KtoryEgzemplarz);
                    
                }

                
                // tworze zdarzenie z predykatow
                OpisStanuEgzemplarza op = new OpisStanuEgzemplarza();
                op.KtoryEgzemplarz = lista.Find(predykatK);//  listaZ.ElementAt(i)
                //----op.Kto = listaU.Find(predykatU);
                op.DataZakupu = Convert.ToDateTime(listaO.ElementAt(i).DataZakupu);
                op.Dostepna = listaO.ElementAt(i).Dostepna;
                op.OpisStanu = listaO.ElementAt(i).OpisStanu;
                op.LicznikWypozyczen = listaO.ElementAt(i).LicznikWypozyczen;

                //dodaje do repozytorium
                contex.opisStanow.Add(op);
            }

        }
    }
}