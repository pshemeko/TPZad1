using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public abstract class Zdarzenie
    {
        protected Uzytkownik kto;
        protected Egzemplarz co;


        public Uzytkownik Kto { get; set; }
        public Egzemplarz Co { get; set; }



        public  virtual string ToString()
        {

            string s = Co.ToString();
            return s + "\n";
        }

        public virtual string WypiszWszystko()
        {
            string s = Kto.ToString() + " Pozyczyl: " + Co.ToString();
            return s + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is Zdarzenie)
            {
                var tmp = (Zdarzenie)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co);
            }
            else
            {
                return false;
            }
        }
    }
}
