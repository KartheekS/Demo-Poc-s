using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            

            string path = @"D:\Users\C402193\Desktop\codeathon\Drug.xlsx ";

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet excelSheet = wb.ActiveSheet;
            var x = excelSheet.UsedRange.Rows.Count-1;

            //Read the first cell
            for (int i = 1; i <= x; i++)
            {
                string drug = excelSheet.Cells[i+1, 1].Value.ToString();
                string path2 = @"D:\Users\C402193\Desktop\codeathon\Websites.xlsx ";
                Application excel2 = new Application();
                Workbook wb2 = excel2.Workbooks.Open(path2);
                Worksheet excelSheet2 = wb2.ActiveSheet;
                var y = excelSheet2.UsedRange.Rows.Count - 1;
                for (int j = 1; j <= y; j++)
                {
                    var url = excelSheet2.Cells[j+1 , 2].Value.ToString() + drug;
                    var xpath = excelSheet2.Cells[j+1 , 3].Value.ToString();
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    
                    HtmlWeb web = new HtmlWeb();
                    var doc = web.Load(url);

                    string drugvalue = doc.DocumentNode.SelectNodes(xpath)[0].InnerText;


                }
              // // //bulk ineser

            }
            

            wb.Close();

        }
    }
}
/*
 * ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string Url = "https://www.healthwarehouse.com/solr/result/?q=Aspirin";
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(Url);

                string stockrate = doc.DocumentNode.SelectNodes("//*[@id=\"product_listings\"]/ul/li[1]/div[3]/h3/text()")[0].InnerText;
*/