using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            List<Thread> list2 = new List<Thread>();

            for (int i = 1; i <= 10000; i++)
            {
                list.Add(i);

            }

            list.ForEach(i =>
            {
                Thread thread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    
                    Console.WriteLine("Current Thread" + i);

                }
                );
                thread.Start();
                list2.Add(thread);
            });

            foreach (var workingthread in list2)
            {
                do
                { Thread.Sleep(5000); } while (workingthread.IsAlive);
            }
            Console.ReadKey();





        }
    }
}
