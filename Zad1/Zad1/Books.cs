using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Books
    {
        private string autor;
        private string title;
        private string isbn;
        private int yearOfPublishment;

        public string Autor { get; set; }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public int YearOfPublishment
        {
            get { return yearOfPublishment; }
            set { yearOfPublishment = value; }
        }

        public override string ToString()
        {
            string ret = "Ksiazka: " + isbn + " Tytul: " + title + " Autor: " + autor + " Rok wydania: " + yearOfPublishment;
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is Books)
            {
                var tempBook = (Books)obj;
                return autor.Equals(tempBook.autor) && title.Equals(tempBook.title) && isbn.Equals(tempBook.title) & yearOfPublishment.Equals(tempBook.yearOfPublishment);
            }
            else
            {
                return false;
            }
        }
        
    }
 
}
