using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {

        
            Wypelnianie wypelnia = new WypelnianieStalymi();
            DataContext dataConstexx = new DataContext();
        

    /*
    [TestMethod()]
    public void WypelnijTest()
    {
        Assert.Fail();
    }
    */
    [TestMethod()]
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

            repozytorium.AddUzytkownika(uz);
            Assert.AreEqual(repozytorium.GetUzytkownika(1234), uz);

        }
        
        [TestMethod()]
        public void AddEgzemplarzTest()
        {
            DataRepository repozytorium = new DataRepository(wypelnia);
            {
                repozytorium.DataContex = dataConstexx;
            };
            Egzemplarz egz = new Ksiazka(111, "c# 6.0 Leksykon ieszonkowy", Rodzaj.popularno_naukowy, 200, "Joseph", "Albahari", "978-83-283-2446-6");

            repozytorium.AddEgzemplarz(egz);
            Assert.AreEqual(egz, repozytorium.GetEgzemplarz(111));
                      
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

            Zdarzenie zd = new Zdarzenie
            {
                Co = egz,
                Kto = uz,
                KiedyWypozyczyl = new DateTime(2018, 3, 1, 9, 0, 0), //01/03/2008 07:00:00
                KiedyZwrocil = new DateTime(2018, 5, 2, 19, 0, 0),
                Kara = 15,
            };

            repozytorium.AddZdarzenie(zd);
            Assert.AreEqual(zd, repozytorium.GetZdarzenie(0));
        }

        //[TestMethod()]
        //public void AddZdarzenieZwrotTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddOpisStanuEgzemplarzaTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void GetUzytkownikaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEgzemplarzTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetZdarzenieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOpisStanuEgzemplarzaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUzytkownikowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllOpisStanuEgzemplarzasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUzytkownikTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEgzemplarzTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateZdarzenieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateOpisStanowEgzemplarzaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUzytkownikTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEgzemplarzTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteZdarzenieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteOpisStanuEgzemplarzaTest()
        {
            Assert.Fail();
        }
    }
}