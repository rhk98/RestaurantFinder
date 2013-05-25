using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using RestaurantFinderUtilityClasses;

namespace RestaurantFinderUtilityClassesTest
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
    }
    
    
    [TestFixture]
    public class XMLParsersTests
    {
        [Test]
        public void CovertNodeCorrectlyConvertsSampleXMLDocumentToPersonObject()
        {
            //Create sample XMLDocument
            var doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode personNode = doc.CreateElement("Person");
            doc.AppendChild(personNode);

            XmlNode idNode = doc.CreateElement("Id");
            idNode.InnerText = "1";
            personNode.AppendChild(idNode);

            XmlNode nameNode = doc.CreateElement("Name");
            nameNode.InnerText = "Joe";
            personNode.AppendChild(nameNode);

            XmlNode ageNode = doc.CreateElement("Age");
            ageNode.InnerText = "23";
            personNode.AppendChild(ageNode);

            XmlNode occupationNode = doc.CreateElement("Occupation");
            occupationNode.InnerText = "Programmer";
            personNode.AppendChild(occupationNode);

            //System under Test(SUT)
            var xmlParsers = new XMLParsers();
            var person = xmlParsers.CovertNode<Person>(doc);

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Joe", person.Name);
            Assert.AreEqual(23, person.Age);
            Assert.AreEqual("Programmer", person.Occupation);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void CovertNodeThrowsArgumentNullExceptionWhenNullArgumentPassedToConvertNode()
        {
            XmlDocument doc = null;
            //System under Test(SUT)
            var xmlParsers = new XMLParsers();
            var person = xmlParsers.CovertNode<Person>(doc);
        }
    }
    
}
