using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HashCode2020
{
    class File
    {
        string Path;
        public Meta m1 = new Meta();
        public List<Library> l1 = new List<Library>();
        public File(string Path)
        {
            this.Path = Path;
            Console.WriteLine(Path);
        }
        public File()
        {

        }
        public List<Library> Read()
        {
            string Data;
            string[] BooksScores;

            string[] Temp;
            string[] Temp2;
            string[] Temp3;

            using (StreamReader s1 = new StreamReader(System.IO.File.Open(Path, FileMode.Open)))
            {
                Data = s1.ReadToEnd();
            }
            Temp = Data.Split('\n');
            Temp2 = Temp[0].Split(' ');
            m1 = new Meta() { TotalBooks = int.Parse(Temp2[0]), TotalLibrary = int.Parse(Temp2[1]), TotalScanningDays = int.Parse(Temp2[2]) };
            BooksScores = Temp[1].Split(' ');
         
            for (int i = 2; i < Temp.Length-1; i += 2)
            {
                Temp2 = Temp[i].Split(' ');
                Temp3 = Temp[i + 1].Split(' ');
                
                Library l2 = new Library() { TotalBooks = int.Parse(Temp2[0]), SignupProcessTime = int.Parse(Temp2[1]), BooksPerDay = int.Parse(Temp2[2]) };
                for (int j = 0; j < Temp3.Length; j++)
                {
                  
                    int id = int.Parse(Temp3[j]);
                   
                    l2.Books.Add(new Book() { Id = id, BookScore = int.Parse(BooksScores[id]) });
                }
                l1.Add(l2);
            }
            return l1;
        }
        public void Wirte(List<int> PizzaTypes, int TotalPizzas)
        {
            using (StreamWriter s1 = new StreamWriter(System.IO.File.Open(@"C:\Users\HP\Downloads\test.in", FileMode.Create)))
            {
                s1.WriteLine(TotalPizzas);
                s1.WriteLine(MakeString(PizzaTypes));

            }
        }
        public string MakeString(List<int> PizzaTypes)
        {
            string text = "";
            for (int i = 0; i < PizzaTypes.Count; i++)
            {
                if (i + 1 > PizzaTypes.Count)
                {
                    text += PizzaTypes[i];
                }
                else
                {
                    text += PizzaTypes[i] + " ";
                }

            }
            return text;
        }
    }
}
