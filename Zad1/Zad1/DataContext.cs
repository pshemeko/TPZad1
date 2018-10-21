using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class DataContext
    {
        public List<Uzytkownik> listaUzytkownikow;
        public Dictionary<int, Egzemplarz> ksiazki;
        public ObservableCollection<Zdarzenie> zdarzenia;
        public List<OpisStanuEgzemplarza> opisStanow;

        public DataContext()
        {
            listaUzytkownikow = new List<Uzytkownik>();
            ksiazki = new Dictionary<int, Egzemplarz>();
            zdarzenia = new ObservableCollection<Zdarzenie>();
            opisStanow = new List<OpisStanuEgzemplarza>();

            //TODO moze dodac jeszcze info przy akcjach dziejacych sie pdczas ObservableCollection np dodawaniu
        }

    }
}
