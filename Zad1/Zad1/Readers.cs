using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Readers
    {
        private string name;
        private string firstName;
        private int id;
        private string adress;

        public string Name { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public override string ToString()
        {
            string ret = "Czytelnik: " + name + " " + firstName + " Adress: " + adress + " Id: " + id;
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Readers)
            {
                var tempReader = (Readers)obj;
                return name.Equals(tempReader.name) && firstName.Equals(tempReader.firstName) && id.Equals(tempReader.id) && adress.Equals(tempReader.adress);
            }
            else
            {
                return false;
            }
            
        }

    }
}
