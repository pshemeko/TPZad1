using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class OpisStanuEgzemplarza
    {
        protected Egzemplarz ktoryEgzemplarz;
        protected DateTime dataZakupu;
        protected Boolean dostepna; // czy egzemplarz jest dostepny
        protected string opisStanu; // w jakim jest stanie co zniszczone
        
        public DateTime DataZakupu { get; set; }
        public Boolean Dostepna { get; set; }
        public Egzemplarz KtoryEgzemplarz { get; set; }
        public string OpisStanu { get; set; }

        public override string ToString()
        {
            string s = ktoryEgzemplarz + " Data zakupu " + dataZakupu + "Stan:" + opisStanu + "\n";
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj is OpisStanuEgzemplarza)
            {
                OpisStanuEgzemplarza tmp = (OpisStanuEgzemplarza)obj;
                return dataZakupu.Equals(tmp.dataZakupu) && ktoryEgzemplarz.Equals(tmp.ktoryEgzemplarz) && dostepna.Equals(tmp.dostepna);
            }
            else
            {
                return true;
            }
        }
    }
}
