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
            File f1 = new File(@"C:\Users\HP\Downloads\f_libraries_of_the_world.txt");
            f1.Read();
            Console.WriteLine("Total Books: "+f1.m1.TotalBooks);
            Console.WriteLine("Total Library: "+f1.m1.TotalLibrary);
            Console.WriteLine("Scannig Days: "+f1.m1.TotalScanningDays);
            Console.WriteLine();
            int i = 1;

            //foreach (Library l in f1.l1)
            //{
            //    Console.WriteLine("Library " + i+" >>>");

            //    Console.WriteLine("Total Books: "+l.TotalBooks);
            //    Console.WriteLine("SignupDays: "+l.SignupProcessTime);
            //    Console.WriteLine("Books Per Day: "+l.BooksPerDay);

            //    for (int j = 0; j < l.Books.Count; j++)
            //    {
            //        Console.WriteLine("Book id:{0} Book score:{1} " , l.Books[j].Id, l.Books[j].BookScore);

            //    }
            //    ++i;
            //}
            Program.StartProcess2(f1.l1, f1.m1);
            f1.Wirte(Program.GetTotalSignedLib(f1.l1));
        }
        static void StartProcess(List<Library> l1, Meta m1)
        {//i =days
            l1 = l1.OrderByDescending(o => o.BooksPerDay).ToList();
            int t = 0;
            int signinginprocess = l1[t].id;
            for (int i = 1; i <= m1.TotalScanningDays; i++)
            {
                for (int j = 0; j < l1.Count; j++)
                {
                    if (signinginprocess == l1[j].id && l1[j].IsSignedup == false)
                    {
                        if (l1[j].SignupProcessTime == i)
                        {
                            l1[j].IsSignedup = true;
                            if (t + 1 < l1.Count)
                            {
                                ++t;

                                signinginprocess = l1[t].id;


                            }

                        }
                        else
                        {
                            ++l1[j].Processdays;

                        }
                    }
                    if (l1[j].IsSignedup == true && i > l1[j].Processdays)
                    {//scanne books
                        for (int x = 0; x < l1[j].BooksPerDay; x++)
                        {
                           
                            if (l1[j].Books[x].IsScanneed == false)
                            {
                                l1[j].Books[x].IsScanneed = true;
                            }

                        }
                    }



                }
            }

        }
        static int GetTotalSignedLib(List<Library> l1)
        {
            int counter = 0;
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i].IsSignedup)
                {
                    ++counter;
                }
            }
            return counter;

        }
        static void StartProcess2(List<Library> l1, Meta m1)
        {
            List<Library> l2 = new List<Library>();
            int booksperday=0;
            l2.Add(l1[0]);
            //i =days
            l1 = l1.OrderByDescending(o => o.BooksPerDay).ToList();
            int t = 0;
            
            for (int i = 1; i <= m1.TotalScanningDays; i++)
            {
                for (int j = 0; j < l1.Count; j++)
                {
                    
                    if (l2.Contains(l1[j])&& l1[j].IsSignedup == false)
                    {
                        if (l1[j].SignupProcessTime == i)
                        {
                          
                            l1[j].IsSignedup = true;
                            if (t + 1 < l1.Count)
                            {
                                ++t;
                                
                                l2.RemoveAt(0);
                                l2.Add(l1[t]);
                            }
                          

                        }
                        else
                        {
                            ++l1[j].Processdays;

                        }
                    }
                   // Console.WriteLine(l1[j].IsSignedup);
                    if (l1[j].IsSignedup == true && i>l1[j].Processdays)
                    {//scanne books
                        booksperday = 0;
                        for (int x = 0; x < l1[j].Books.Count; x++)
                        {
                            if (l1[j].Books[x].IsScanneed == false&& booksperday<l1[j].BooksPerDay)
                            {
                                l1[j].Books[x].IsScanneed = true;
                               
                            }
                            
                        }
                     
                    }



                }
            
            }
            Console.WriteLine(l1[0].TotalScannedBooks());

        }
    }
}

