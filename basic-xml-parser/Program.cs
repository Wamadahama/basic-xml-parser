using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser 
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic Test = new DynamicXmlObject(@"sample.xml");

            // Using . Member access 
            Console.WriteLine(Test.bar.ToString()); // => 3

            // Chained . Member acess
            Console.WriteLine(Test.foobar.foo); // => bar 

            // Using String index 
            //Console.WriteLine(Test["foo"].ToString()); // => 2

            // Integer Index 
            Console.WriteLine(Test.foobar[0].ToString()); // => bar

            // ToList<string>
            List<string> Foobar = Test.foobar.ToList();
            Foobar.ForEach((elem) => { Console.WriteLine(elem.ToString()); }); // => bar\nfoo\n

            Console.Read();
        }
    }
}
