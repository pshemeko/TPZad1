using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class DataRepository
    {
        private DataContext dataContext;
        private Wypelnianie wypelniacz;

        public DataContext DataContex
        {
            set => dataContext = value;
        }
        public Wypelnianie Wypelniacz
        {
            set => wypelniacz = value;
        }

        public void Wypelnij()
        {
            wypelniacz.Wypelnij(ref dataContext);
        }

        ////TODO dodaj inne metody by dodawac elementy jak dodaj/usun/zmien Egzemplarz, Uzytkownika - uwaga rozne klasy bo dziedziczenie

    }
}
