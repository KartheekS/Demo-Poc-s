using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {

        public static void somemethod(List<int>z, int offset =0)
        {
            var skip = 0;
            int limit = 10;
           
            foreach (var item in z.Skip(skip + offset).Take(limit))
            {

                Console.Write(item + " ");

                offset = offset + limit;
            }

        }
        static void Main(string[] args)
        {
            List<int> x = new List<int>();
            for(int i =1; i<=100; i++)
            {
                x.Add(i);
            }
            int totalRows = x.Count();
            int limit = 10;
            for (var offSet = 0; offSet < totalRows; offSet += limit)
            {
                
                    
                    somemethod(x, offSet);
                Console.WriteLine("");


                   
            }
            Console.ReadKey();

        }
           

        }
    }

