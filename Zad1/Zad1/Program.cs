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
            //wypelnij.Wypelnij(ref dataConstexx);

            DataRepository repozytorium = new DataRepository()
            {
                DataContex = dataConstexx,
                Wypelniacz = wypelnia
            };

            
        }
    }
}
