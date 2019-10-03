using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        class manifestdata
        {
            public List<someclass> Data { get; set; }
        }



        static void Main(string[] args)
        {
            JObject o1 = JObject.Parse(File.ReadAllText(@"c:\manifestFile.json"));
            
            try {
                // read JSON directly from a file
                manifestdata movie1 = JsonConvert.DeserializeObject<manifestdata>(File.ReadAllText(@"c:\manifestFile.json"));
                List<newclass> z = new List<newclass>();
                foreach(var item1 in movie1.Data)
                {
                    foreach(var item2 in item1.patient_ids)
                    {
                        z.Add((new newclass() { name = item1.name, id = item1.id, patient_ids = item2 }));
                       
                    }
                }

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
          }
    }

    public class someclass
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<int> patient_ids { get; set; }
        
        
    }
    public class newclass
    {
        public string name { get; set; }
        public string id { get; set; }
        public int patient_ids { get; set; }

    }
   
}

