using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2020
{
    class Library
    {
        public int id;
        public int TotalBooks;
        public int SignupProcessTime { get; set; }
        public int BooksPerDay { get; set; }
        public List<Book> Books=new List<Book>();
        public bool IsSignedup = false;
        public int Processdays;
        public int TotalScannedBooks()
        {
            int counter = 0;
            foreach(Book b1 in Books)
            {
                if(b1.IsScanneed)
                {
                    ++counter;
                }
            }
            return counter;
        }

    }
}
