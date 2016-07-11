using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;


namespace XmlParser
{
    /// <summary>
    /// Serializes an XML file into a C# object
    /// </summary>
    public class DynamicXmlObject : DynamicObject
    {

        XElement element;

        /// <summary>
        /// Takes filename, reads the XML and parses it in a dynamic object
        /// </summary>
        /// <example>
        ///     <code>dynamic foo = new DynamicXmlObject(@"bar.xml");</code>
        /// </example>
        /// <param name="Filename"></param>
        public DynamicXmlObject(string Filename)
        {
            element = XElement.Load(Filename);
        }

        private DynamicXmlObject(XElement e)
        {
            element = e;
        }

        /// <summary>
        /// Override of DynamicObject used to process dynamic gets
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (element == null)
            {
                result = null;
                return false;
            }

            XElement sub = element.Element(binder.Name);

            if (sub == null)
            {
                result = null;
                return false;
            }

            else
            {
                result = new DynamicXmlObject(sub);
                return true;
            }
        }

        /// <summary>
        /// Returns a string representation of the serialzied object or the property.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (element != null)
            {
                return element.Value.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        /* 
         * “IEnumerable. A consensual interface implemented daily by billions of legitimate objects,
            in every namespace, by objects in collections...
             A graphic representation of iteration abstracted from base of every non-generic in the .NET system. 
            Unthinkable complexity. Lines of debug code ranged in the nonspace of the mind, clusters and constellations of data. Like city lights, receding...” 
       */
        public List<string> ToList()
        {
            if (element != null)
            {
                List<string> ReturnList = new List<string>();

                IEnumerable<XElement> Elements = element.Elements();

                foreach (var Element in Elements)
                {
                    ReturnList.Add(Element.Value);
                }

                return ReturnList;
            }
            else
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Query the object like you would query a dictionary
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public string this[string attr]
        {
            get
            {
                if (element == null)
                {
                    return string.Empty;
                }

                return element.Attribute(attr).Value;
            }
        }

        /// <summary>
        /// Query the object like you would an array
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (element == null)
                {
                    return string.Empty;
                }

                // Get a listing of the child elements and match it to the index
                return element.Elements().ElementAtOrDefault(index).Value;
            }
        }
    }
}
