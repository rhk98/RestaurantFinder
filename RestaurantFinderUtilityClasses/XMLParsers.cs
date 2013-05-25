using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DomainLayer;

namespace RestaurantFinderUtilityClasses
{
    public class XMLParsers : IXMLParsers
    {
        public T CovertNode<T>(XmlNode node) 
        {
            if(node == null)
                throw new ArgumentNullException("node");

            var memoryStream = new MemoryStream();
            var stw = new StreamWriter(memoryStream);

            stw.Write(node.OuterXml);
            stw.Flush();

            memoryStream.Position = 0;

            var serializer = new XmlSerializer(typeof(T));
            var result = (T)serializer.Deserialize(memoryStream);

            return result;
        }
    }
}
