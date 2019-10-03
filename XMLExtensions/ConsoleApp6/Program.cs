using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp6
{

    public static class Extensions
    {
        public static string AsString(this XmlDocument xmlDoc)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    xmlDoc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }
    }
    class Program
    {
        // conversion
        //public static XmlDocument ConvertToXmlDocument(XDocument input)

        //{

        //    var xmlDocumentObj = new XmlDocument();

        //    using (var xmlReader = input.CreateReader())

        //    {

        //        xmlDocumentObj.Load(xmlReader);

        //        return xmlDocumentObj;

        //    }



        //}
        //// conversion
        //public static XDocument ConvertToXDocument(XmlDocument input)

        //{

        //    using (var reader = new XmlNodeReader(input))

        //    {

        //        reader.MoveToContent();

        //        return XDocument.Load(reader);

        //    }

        //}


        //private static XDocument DocumentToXDocument(XmlDocument doc)
        //{
        //    return XDocument.Parse(doc.OuterXml);
        //}

        
        static void Main(string[] args)
        {
            Dictionary < int , string > z1 = new Dictionary<int, string>();

            string z = @"<?xml version = '1.0' encoding='UTF-8' standalone='yes'?><emr xmlns:json='http://james.newtonking.com/projects/json'><resourceType>Bundle</resourceType><id>20875</id><meta><lastUpdated>2019-08-08T20:23:16Z</lastUpdated></meta><type>transaction</type><entry json:Array='true'><resource><resourceType>Observation</resourceType><meta><lastUpdated>2019-08-08T20:23:16Z</lastUpdated></meta><id>1-18-40953610-BMI-1700879096</id><status>completed</status><category json:Array='true'> <coding json:Array='true'><system>http://hl7.org/fhir/observation-category</system><code>vital-signs</code></coding></category><category json:Array='true'> <coding json:Array='true'><system>http://wcm</system><code>BMI</code></coding></category><code><coding json:Array='true'><system>PHYTEL</system><code>BMI</code></coding></code><subject><reference>16</reference></subject><effectiveDateTime>2016-03-18T00:00:00Z</effectiveDateTime><valueQuantity><value>15.9700</value><unit>kg/m2</unit></valueQuantity></resource><request><method>POST</method><url>Observation/1-18-40953610-BMI-1700879096</url></request></entry><entry json:Array='true'><resource><resourceType>Observation</resourceType><meta><lastUpdated>2019-08-08T20:23:16Z</lastUpdated></meta><id>1-18-40953610-HEIGHT-1700888649</id><status>completed</status><category json:Array='true'> <coding json:Array='true'><system>http://hl7.org/fhir/observation-category</system><code>vital-signs</code></coding></category><category json:Array='true'> <coding json:Array='true'><system>http://wcm</system><code>Height</code></coding></category><code><coding json:Array='true'><system>PHYTEL</system><code>Height</code></coding></code><subject><reference>16</reference></subject><effectiveDateTime>2016-03-18T00:00:00Z</effectiveDateTime><valueQuantity><value>45.0000</value><unit>in</unit></valueQuantity></resource><request><method>POST</method><url>Observation/1-18-40953610-HEIGHT-1700888649</url></request></entry><entry json:Array='true'><resource><resourceType>Observation</resourceType><meta><lastUpdated>2019-08-08T20:23:16Z</lastUpdated></meta><id>1-18-40953610-WEIGHT-1700886618</id><status>completed</status><category json:Array='true'> <coding json:Array='true'><system>http://hl7.org/fhir/observation-category</system><code>vital-signs</code></coding></category><category json:Array='true'> <coding json:Array='true'><system>http://wcm</system><code>Weight</code></coding></category><code><coding json:Array='true'><system>PHYTEL</system><code>Weight</code></coding></code><subject><reference>16</reference></subject><effectiveDateTime>2016-03-18T00:00:00Z</effectiveDateTime><valueQuantity><value>736.0000</value><unit>oz</unit></valueQuantity></resource><request><method>POST</method><url>Observation/1-18-40953610-WEIGHT-1700886618</url></request></entry><entry json:Array='true'><resource><resourceType>Observation</resourceType><meta><lastUpdated>2019-08-08T20:23:16Z</lastUpdated></meta><id>13-32-2017986578</id><status>completed</status><category json:Array='true'> <coding json:Array='true'><system>http://hl7.org/fhir/observation-category</system><code>vital-signs</code></coding></category><category json:Array='true'> <coding json:Array='true'><system>http://wcm</system><code>Blood Pressure</code></coding></category><subject><reference>16</reference></subject><effectiveDateTime>2016-03-18T00:00:00Z</effectiveDateTime><component><code><coding><system>PHYTEL</system><code>Blood Pressure</code><display>Blood Pressure - Systolic</display></coding><coding><system>http://wcm</system><code>bp-s</code><display>Blood Pressure - Systolic</display></coding></code><valueQuantity><value>104.000000</value><unit>mmHg</unit></valueQuantity></component><component><code><coding><system>PHYTEL</system><code>Blood Pressure</code><display>Blood Pressure - Diastolic</display></coding><coding><system>http://wcm</system><code>bp-d</code><display>Blood Pressure - Diastolic</display></coding></code><valueQuantity><value>62.000000</value><unit>mmHg</unit></valueQuantity></component></resource><request><method>POST</method><url>Observation/13-32-2017986578</url></request></entry></emr>";

            XmlDocument docket = new XmlDocument();
            docket.LoadXml(z);

            XmlDocument p = (XmlDocument)docket.CloneNode(true);
           // p.LoadXml(z);
            
            
            
            XmlNode product = p.SelectSingleNode("/emr");
            foreach (XmlNode category in product.SelectNodes("entry"))
            {
                product.RemoveChild(category);
            }
            // string x = p.AsString();
            p.SelectSingleNode("//emr/id").InnerText = 100.ToString();
            docket.SelectSingleNode("//emr/id").InnerText = 100.ToString();

            var y = docket.AsString();
            //ChunkDocket(docket, 3, p);


        }



        public static List<XmlDocument> ChunkDocket(XmlDocument docket, int chunkSize, XmlDocument master)
        {
            List<XmlDocument> newDockets = new List<XmlDocument>();
            //
            
            int orderCount = docket.SelectNodes("//emr/entry").Count;
            int chunkStart = 0;
            
            //XmlElement root = null;
            XmlNodeList chunk = null;
            
            while (chunkStart < orderCount)
            {
                XmlDocument newDocket = (XmlDocument)master.CloneNode(true);
                var user = newDocket.SelectSingleNode("//emr");
                // newDocket = new XmlDocument();
                //root = newDocket.CreateElement("emr");
                //newDocket.AppendChild(root);

                // TRYING TO APPEND CHILD NODES TO EXISTING XML DOC

                chunk = docket.SelectNodes(String.Format("//emr/entry[position() > {0} and position() <= {1}]", chunkStart, chunkStart + chunkSize));

                chunkStart += chunkSize;

                XmlNode targetNode = null;
                foreach (XmlNode c in chunk)
                {
                    targetNode = newDocket.ImportNode(c, true);
                    user.AppendChild(targetNode);
                    
                }

                newDockets.Add(newDocket);
            }

            return newDockets;
        }
    }
}
