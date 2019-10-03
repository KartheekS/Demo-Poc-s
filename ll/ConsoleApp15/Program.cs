using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        //internal class kvp
        //{
        //    public int i { get; set; }
        //    public int[] j { get; set; }
        //}
        static void Main(string[] args)
        {
           // LinkedList<List<kvp>> x = new LinkedList<List<kvp>>();
           LinkedList<Dictionary<int, int[]>> dictll = new LinkedList<Dictionary<int, int[]>>();

            Dictionary<int, int[]> obj = new Dictionary<int, int[]>()
            {
                {1,new int[]{ 1,2,3} },{2,new int[]{4,5,6} },{3,new int[]{7,8,9 } }
            };
            dictll.AddLast(obj);
            if(dictll.Count>0)
            {
                Console.WriteLine(dictll.Count);
                Console.ReadKey();
            }
           // List<kvp> c = new List<kvp>()
           // {
           //     new kvp()
           //     {
           //         i =1,
           //         j = new int[] {1,2,3}
           //     }

           // };
           // List<kvp> d = new List<kvp>()
           // {
           //      new kvp()
           //      {
           //          i =2,
           //          j =new int[]{4,5,6}
           //      }
           //};
           // List<kvp> e = new List<kvp>()
           // {

           //     new kvp()
           //     {
           //         i =3,
           //         j = new int[] {7,8,9}
           //     }


           // };
            //x.AddLast(c);
            //x.AddLast(d);
            //x.AddLast(e);
            //x.Remove(node);


        }
    }


}
