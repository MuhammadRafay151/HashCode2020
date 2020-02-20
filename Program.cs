using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            File f1 = new File(@"C:\Users\HP\Downloads\a_example.txt");
            f1.Read();
            Console.WriteLine(f1.m1.TotalBooks);
            Console.WriteLine(f1.m1.TotalLibrary);
            Console.WriteLine(f1.m1.TotalScanningDays);
            int i = 1;
           
            foreach(Library l in f1.l1)
            {
                Console.WriteLine("Library "+i);
                Console.WriteLine(l.TotalBooks);
                Console.WriteLine(l.SignupProcessTime);
                Console.WriteLine(l.BooksPerDay);
               
                for(int j=0;j<l.Books.Count;j++)
                {
                    Console.WriteLine("Book id"+l.Books[j].Id);
                    Console.WriteLine("Book score" + l.Books[j].BookScore);
                }
                ++i;
            }


        }
    }
}

