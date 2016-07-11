using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using System.Dynamic;
using XmlParser;
using System.Collections.Generic;

namespace basic_xml_parser_tests
{
    [TestClass]
    public class XmlParserTests
    {
        [TestMethod]
        public void XMLParserTests()
        {

            dynamic Test = new DynamicXmlObject(@"sample.xml");
            // Using . Member access 
            Assert.AreEqual("3", Test.bar.ToString()); // => 3

            // Chained . Member acess
            Assert.AreEqual("bar", Test.foobar.foo.ToString()); // => bar 

            // Integer Index 
            Assert.AreEqual("bar", Test.foobar[0].ToString()); // => bar

            // ToList<string>
            List<string> Foobar = Test.foobar.ToList();
            string Result = "";
            string Expected = "bar\nfoo\n";
            Foobar.ForEach((elem) => { Result += elem + "\n"; }); // => bar\nfoo\n
            Assert.AreEqual(Expected, Result);

        }
    }
}
