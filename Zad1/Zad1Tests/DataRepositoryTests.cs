using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;
using Logic;
using Fill;

namespace Zad1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {

        
            IWypelnianie wypelnia = new WypelnianieStalymi();
            DataContext dataConstexx = new DataContext();
        

    [TestMethod()]

        // ****************************************  ADD *******************************************
        public void AddUzytkownikaTest()
        {
                       
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            //DataService data_serwis = new DataService(repozytorium);
            ///

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };

            Assert.AreEqual(repozytorium.SizeOfUzytkownicy(), 0);
            repozytorium.AddUzytkownika(uz);
            Assert.ReferenceEquals(repozytorium.GetUzytkownika(1234), uz);
            Assert.AreEqual(repozytorium.SizeOfUzytkownicy(), 1);

        }
        
        [TestMethod()]
        public void AddEgzemplarzTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

           
            Assert.AreEqual(repozytorium.SizeOfEgzemplarze(), 0);
            repozytorium.AddEgzemplarz(egz);
            Assert.AreEqual<Egzemplarz>(egz, repozytorium.GetEgzemplarz(111));
            Assert.ReferenceEquals(egz, repozytorium.GetEgzemplarz(111));
            Assert.AreEqual(repozytorium.SizeOfEgzemplarze(), 1);

        }

        [TestMethod()]
        public void AddZdarzenieWypozyczenieTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };

            ZdarzeniePozyczenia zd = new ZdarzeniePozyczenia
            {
                Co = egz,
                Kto = uz,
                KiedyWypozyczyl = new DateTime(2018, 3, 1, 9, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 15,
            };

            Assert.AreEqual(repozytorium.SizeOfZdarzenia(), 0);
            repozytorium.AddZdarzenie(zd);
            Assert.ReferenceEquals(zd, repozytorium.GetZdarzenie(0));
            Assert.AreEqual(repozytorium.SizeOfZdarzenia(), 1);
        }

      
        [TestMethod()]
        public void AddOpisStanuEgzemplarzaTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 0);

            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            OpisStanuEgzemplarza op1 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 3, 1, 9, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 0;
            op1.OpisStanu = "nowy, nie uszkodzony";

            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 0);
            repozytorium.AddOpisStanuEgzemplarza(op1);
            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 1);

            Assert.ReferenceEquals(repozytorium.GetOpisStanuEgzemplarzaNr(0), op1);

        }

        // ****************************************  GET *******************************************
        [TestMethod()]
        public void GetUzytkownikaTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            //DataService data_serwis = new DataService(repozytorium);
            ///

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };

            repozytorium.AddUzytkownika(uz);
            Assert.ReferenceEquals(repozytorium.GetUzytkownika(1234), uz);


        }

        [TestMethod()]
        public void GetEgzemplarzTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            repozytorium.AddEgzemplarz(egz);
            Assert.ReferenceEquals(egz, repozytorium.GetEgzemplarz(111));
        }

        [TestMethod()]
        public void GetZdarzenieTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };

            ZdarzeniePozyczenia zd = new ZdarzeniePozyczenia
            {
                Co = egz,
                Kto = uz,
                KiedyWypozyczyl = new DateTime(2018, 3, 1, 9, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 15,
            };

            repozytorium.AddZdarzenie(zd);
            Assert.ReferenceEquals(zd, repozytorium.GetZdarzenie(0));
        }

        [TestMethod()]
        public void GetOpisStanuEgzemplarzaTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 0);

            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            OpisStanuEgzemplarza op1 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 3, 1, 9, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 0;
            op1.OpisStanu = "nowy, nie uszkodzony";

            repozytorium.AddOpisStanuEgzemplarza(op1);
            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 1);

            Assert.ReferenceEquals(repozytorium.GetOpisStanuEgzemplarzaNr(0), op1);
        }

        // ****************************************  GET ALL *******************************************
        [TestMethod()]
        public void GetAllUzytkownikowTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            
            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };
            Uzytkownik uzB = new Uzytkownik()
            {
                Adres = "bandurskiego 1/7",
                Imie = "Bogdan",
                Nazwisko = "Brzechwa",
                Pesel = 2345,
            };

            repozytorium.AddUzytkownika(uz);
            repozytorium.AddUzytkownika(uzB);

            List<Uzytkownik> nowa = new List<Uzytkownik>();
            nowa.Add(uz);
            nowa.Add(uzB);

            List<Uzytkownik> zRepozytorium = repozytorium.GetAllUzytkownikow();

            for(int i = 0; i < repozytorium.SizeOfUzytkownicy(); i++)
            {
                Assert.ReferenceEquals(nowa[i], zRepozytorium[i]);
            }

        }
        [TestMethod()]

        public void GetAllEgzemplarzeTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            Egzemplarz egz2 = new Ksiazka(222, "c++ Biblioteka Standardowa", Rodzaj.popularno_naukowy, 1120, "Nicolai", "Jostuttis", "978-83-246-5576-2");
            
            repozytorium.AddEgzemplarz(egz);
            repozytorium.AddEgzemplarz(egz2);

            List<Egzemplarz> nowa = new List<Egzemplarz>();
            nowa.Add(egz);
            nowa.Add(egz2);

            List<Egzemplarz> zRepozytorium = repozytorium.GetAllEgzemplarze().ToList<Egzemplarz>();

            for (int i = 0; i < repozytorium.SizeOfUzytkownicy(); i++)
            {
                Assert.ReferenceEquals(nowa[i], zRepozytorium[i]);
            }
        }

        [TestMethod()]
        public void GetAllZdarzeniaTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");
            Egzemplarz egz2 = new Ksiazka(222, "c++ Biblioteka Standardowa", Rodzaj.popularno_naukowy, 1120, "Nicolai", "Jostuttis", "978-83-246-5576-2");

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };
            Uzytkownik uzB = new Uzytkownik()
            {
                Adres = "bandurskiego 1/7",
                Imie = "Bogdan",
                Nazwisko = "Brzechwa",
                Pesel = 2345,
            };


            ZdarzeniePozyczenia zd = new ZdarzeniePozyczenia
            {
                Co = egz,
                Kto = uz,
                KiedyWypozyczyl = new DateTime(2018, 3, 1, 9, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 15,
            };
            ZdarzeniePozyczenia zd2 = new ZdarzeniePozyczenia
            {
                Co = egz2,
                Kto = uzB,
                KiedyWypozyczyl = new DateTime(2018, 5, 2, 19, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 0,
            };

            repozytorium.AddZdarzenie(zd);
            repozytorium.AddZdarzenie(zd2);

            List<Zdarzenie> nowa = new List<Zdarzenie>();
            nowa.Add(zd);
            nowa.Add(zd2);

            List<Zdarzenie> zRepozytorium = repozytorium.GetAllZdarzenia().ToList<Zdarzenie>();

            for (int i = 0; i < repozytorium.SizeOfUzytkownicy(); i++)
            {
                Assert.ReferenceEquals(nowa[i], zRepozytorium[i]);
            }
       
        }

        [TestMethod()]
        public void GetAllOpisStanuEgzemplarzasTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 0);

            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            OpisStanuEgzemplarza op1 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 3, 1, 9, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 0;
            op1.OpisStanu = "nowy, nie uszkodzony";

            OpisStanuEgzemplarza op2 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 4, 2, 8, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 1;
            op1.OpisStanu = "malunki na stonie 2";

            repozytorium.AddOpisStanuEgzemplarza(op1);
            repozytorium.AddOpisStanuEgzemplarza(op2);
            
            List<OpisStanuEgzemplarza> nowa = new List<OpisStanuEgzemplarza>();
            nowa.Add(op1);
            nowa.Add(op2);

            List<OpisStanuEgzemplarza> zRepozytorium = repozytorium.GetAllOpisStanuEgzemplarza();

            for (int i = 0; i < repozytorium.SizeOfUzytkownicy(); i++)
            {
                Assert.ReferenceEquals(nowa[i], zRepozytorium[i]);
            }

        }

        [TestMethod()]
        public void UpdateUzytkownikTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            //DataService data_serwis = new DataService(repozytorium);
            ///

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };
            Uzytkownik uzB = new Uzytkownik()
            {
                Adres = "bandurskiego 1/7",
                Imie = "Bogdan",
                Nazwisko = "Brzechwa",
                Pesel = 2345,
            };

            //Assert.Equals(repozytorium.SizeOfUzytkownicy(), 0);
            //repozytorium.AddUzytkownika(uz);
            //Assert.AreEqual(repozytorium.GetUzytkownika(1234), uz);
            //Assert.Equals(repozytorium.SizeOfUzytkownicy(), 1);
            repozytorium.AddUzytkownika(uz);
            //repozytorium.AddUzytkownika(uzB);
            Assert.ReferenceEquals(repozytorium.GetUzytkownika(1234), uz);
            repozytorium.UpdateUzytkownik(uz, uzB);
            Assert.ReferenceEquals(repozytorium.GetUzytkownika(2345), uzB);
            
        }

        [TestMethod()]
        public void UpdateEgzemplarzTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            Egzemplarz egz2 = new Ksiazka(222, "c++ Biblioteka Standardowa", Rodzaj.popularno_naukowy, 1120, "Nicolai", "Jostuttis", "978-83-246-5576-2");

            repozytorium.AddEgzemplarz(egz);

            Assert.ReferenceEquals(repozytorium.GetEgzemplarz(111), egz);
            repozytorium.UpdateEgzemplarz(egz, egz2);
            Assert.ReferenceEquals(repozytorium.GetUzytkownika(222), egz2);

        }

        [TestMethod()]
        public void UpdateZdarzenieTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");
            Egzemplarz egz2 = new Ksiazka(222, "c++ Biblioteka Standardowa", Rodzaj.popularno_naukowy, 1120, "Nicolai", "Jostuttis", "978-83-246-5576-2");

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };
            Uzytkownik uzB = new Uzytkownik()
            {
                Adres = "bandurskiego 1/7",
                Imie = "Bogdan",
                Nazwisko = "Brzechwa",
                Pesel = 2345,
            };


            ZdarzeniePozyczenia zd = new ZdarzeniePozyczenia
            {
                Co = egz,
                Kto = uz,
                KiedyWypozyczyl = new DateTime(2018, 3, 1, 9, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 15,
            };
            ZdarzeniePozyczenia zd2 = new ZdarzeniePozyczenia
            {
                Co = egz2,
                Kto = uzB,
                KiedyWypozyczyl = new DateTime(2018, 5, 2, 19, 0, 0), //01/03/2008 07:00:00
                //KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                //Kara = 0,
            };

            repozytorium.AddZdarzenie(zd);
            Assert.ReferenceEquals(repozytorium.GetZdarzenie(0), zd);

            repozytorium.UpdateZdarzenie(zd, zd2);

            Assert.ReferenceEquals(repozytorium.GetZdarzenie(0), zd2);
            
        }

        [TestMethod()]
        public void UpdateOpisStanowEgzemplarzaTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            Assert.AreEqual(repozytorium.SizeOfOpisStanow(), 0);

            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            OpisStanuEgzemplarza op1 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 3, 1, 9, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 0;
            op1.OpisStanu = "nowy, nie uszkodzony";

            OpisStanuEgzemplarza op2 = new OpisStanuEgzemplarza();
            op1.KtoryEgzemplarz = egz;
            op1.DataZakupu = new DateTime(2018, 4, 2, 8, 0, 0);
            op1.Dostepna = true;
            op1.LicznikWypozyczen = 1;
            op1.OpisStanu = "malunki na stonie 2";

            repozytorium.AddOpisStanuEgzemplarza(op1);
            
            Assert.ReferenceEquals(repozytorium.GetOpisStanuEgzemplarzaNr(0), op1);

            repozytorium.UpdateOpisStanowEgzemplarza(op1, op2);

            Assert.ReferenceEquals(repozytorium.GetOpisStanuEgzemplarzaNr(0), op2);

        }

        [TestMethod()]
        public void DeleteUzytkownikTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };

            //DataService data_serwis = new DataService(repozytorium);
            ///

            Uzytkownik uz = new Uzytkownik()
            {
                Adres = "Abramowskiego 1/7",
                Imie = "Adam",
                Nazwisko = "Andrzejczyk",
                Pesel = 1234,
            };
            Uzytkownik uzB = new Uzytkownik()
            {
                Adres = "bandurskiego 1/7",
                Imie = "Bogdan",
                Nazwisko = "Brzechwa",
                Pesel = 2345,
            };

            Assert.AreEqual(0, repozytorium.SizeOfUzytkownicy());
            repozytorium.AddUzytkownika(uz);
            repozytorium.AddUzytkownika(uzB);

            Assert.AreEqual(2, repozytorium.SizeOfUzytkownicy());

            repozytorium.DeleteUzytkownik(uz);
            Assert.AreEqual(1, repozytorium.SizeOfUzytkownicy());
        }

        [TestMethod()]
        public void DeleteEgzemplarzTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            Egzemplarz egz2 = new Ksiazka(222, "c++ Biblioteka Standardowa", Rodzaj.popularno_naukowy, 1120, "Nicolai", "Jostuttis", "978-83-246-5576-2");

            Assert.AreEqual(0, repozytorium.SizeOfEgzemplarze());
            repozytorium.AddEgzemplarz(egz);
            repozytorium.AddEgzemplarz(egz2);

            Assert.AreEqual(2, repozytorium.SizeOfEgzemplarze());
            repozytorium.DeleteEgzemplarz(111);
            Assert.AreEqual(1, repozytorium.SizeOfEgzemplarze());

        }
            
        // TODO testy zwracania oraz test wypozyczenia i zwrocenia rzgemplarza przez uzytkiwnia 
        //TODO test czy zmienia sie licznik wypozyczen
    }
}