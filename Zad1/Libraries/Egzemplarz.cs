using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{

    abstract public class Egzemplarz
    {
        protected int id; //klucz
        protected string tytul;
 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tytul { get; set; }
        
        public Egzemplarz(int id, string tytul)
        {
            this.id = id;
            this.tytul = tytul;

        }



        public override string ToString()
        {
            string ret = "Id: " + id.ToString() ;

            ret += " Tytul: " + tytul.ToString();
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Egzemplarz)
            {
                var tempBook = (Egzemplarz)obj;
                return id.Equals(tempBook.id) && tytul.Equals(tempBook.tytul); 
            }
            else
            {
                return false;
            }
        }
    }

}
