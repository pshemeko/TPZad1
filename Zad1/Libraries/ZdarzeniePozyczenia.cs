using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class ZdarzeniePozyczenia : Zdarzenie
    {
        protected DateTime kiedyWypozyczyl;

        public DateTime KiedyWypozyczyl 
        {
            get { return kiedyWypozyczyl; }
            set { kiedyWypozyczyl = value; }
        }


        public override string ToString()
        {

            return base.ToString() + " Data wypożyczenia " + kiedyWypozyczyl.ToString(); ;
        }

        public override string WypiszWszystko()
        {

            return base.WypiszWszystko() + " Data wypożyczenia " + kiedyWypozyczyl.ToString(); ;
        }

        public override bool Equals(object obj)
        {
            if (obj is ZdarzeniePozyczenia)
            {
                var tmp = (ZdarzeniePozyczenia)obj;
                return kto.Equals(tmp.kto) && co.Equals(tmp.co) && kiedyWypozyczyl.Equals(tmp.kiedyWypozyczyl);
            }
            else
            {
                return false;
            }
        }

    }
}