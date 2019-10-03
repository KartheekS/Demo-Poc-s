using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "GRGGLGGG";
            int maxtime=0;
            for (int i = 0; i < s.Length; i++)
            {
                int p=0,q=0,time=0 ;
                if (s[i] == 'R' || s[i] == 'L')
                { continue; }
                
                
               var f = s.Substring(i,s.Length-i);
               var b = s.Substring(0, i);
                int  l = f.IndexOf("L");
                int r = b.IndexOf("R");
                if (l == -1 && r == -1)
                {
                    Console.WriteLine("-1");
                    break;
                }
                if (l > 0)
                {
                     p = l - i;
                }
                if (r > 0)
                {
                     q = i - r;
                }
                if (p > 0 && q > 0)
                {
                    if (p < q) { time = p; }
                    else { time = q; }
                }
                else
                {
                    if(q==0)
                     time = p;
                    if (p == 0)
                        time = q;
                }
                
                if (maxtime < time) { maxtime = time; }




            }
            Console.WriteLine(maxtime);
            Console.ReadKey();
           
        }
    }
}
