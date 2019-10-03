using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {

            //var queryObject = extensions.Where(x => x.Url.Contains(url)).Select(y => y.Value).FirstOrDefault();
            //if (queryObject == null)
            //    return default(T);

            var value = "2017-11-07T00:26:47Z";

            DateTime result;
           
                result = (DateTime)Convert.ChangeType(value, typeof(DateTime));
            string z = result.ToString();
            Console.WriteLine(z);
            Console.ReadKey();
        }
    }
}
