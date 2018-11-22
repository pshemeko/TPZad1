using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class ZdarzenieZwrotu : Zdarzenie
    {
        protected DateTime kiedyZwrocil;
        protected int kara;

       

        public DateTime KiedyZwrocil   
            {
                get { return kiedyZwrocil; }
                set { kiedyZwrocil = value; }
            }
        public int Kara                
            {
                get { return kara; }
                set { kara = value; }
            }

        public override string ToString()
        {

            string s = base.ToString();
            s += " Data zwrotu " + kiedyZwrocil;
            if (kara>0) s+= " kara: " + kara + "zł.";
            return s + "\n";
        }

        public override string WypiszWszystko()
        {

            string s = base.WypiszWszystko();
            s += " Data zwrotu " + kiedyZwrocil;
            if (kara > 0) s += " kara: " + kara + "zł.";
            return s + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is ZdarzenieZwrotu)
            {
                var tmp = (ZdarzenieZwrotu)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co)  && kiedyZwrocil.Equals(tmp.kiedyZwrocil) && kara.Equals(tmp.kara);
            }
            else
            {
                return false;
            }
        }

    }
}
