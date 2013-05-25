using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GoogleWebServiceClientLayer;
using NUnit.Framework;

namespace GoogleWebServiceClientTester
{
    [TestFixture]
    public class GoogleDirectionServiceCientTests
    {
        [Test]
        public void GetDirectionsBetweenPostcodesTest()
        {
            var googleDirectionServiceClient = new GoogleDirectionsServiceClient();
            googleDirectionServiceClient.GetDirectionsBetweenPostcodes("AL6 0RU", "LU7 9GH");

        }

        [Test]
        public void GetDirectionsBetweenPostcodesTestAsXml()
        {
            var googleDirectionServiceClient = new GoogleDirectionsServiceClient();
            googleDirectionServiceClient.GetDirectionsBetweenPostcodesAsXml("AL6 0RU", "LU7 9GH");

        }

        [Test]
        public void GetDirectionsBetweenPostcodesAsXmlAndSaveToFileSuccess()
        {
            var googleDirectionServiceClient = new GoogleDirectionsServiceClient();
            googleDirectionServiceClient.GetDirectionsBetweenPostcodesAsXmlAndSaveToFile("AL6 0RU", "LU7 9GH");

            Assert.IsTrue(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\googleDirections.xml"));

        }
    }
}
