using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {

        public static void GetConfigurationValue()
        {
            var title = ConfigurationManager.AppSettings["title"];
            var language = ConfigurationManager.AppSettings["language"];

            Console.WriteLine(string.Format("'{0}' project is created in '{1}' language ", title, language));
        }
        static void Main(string[] args)
        {
            GetConfigurationValue();
        }
    }
}
