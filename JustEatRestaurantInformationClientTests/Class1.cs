using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RestaurantFinderUtilityClasses;
using ServiceClientLayer;

namespace JustEatRestaurantInformationClientTests
{
    [TestFixture]
    public class JustEatRestaurantInformationClientTest
    {
        [Test]
        public void xx()
        {
            IXMLParsers xParsers =  new XMLParsers();
            var client = new JustEatRestaurantInformationClient(xParsers);
            client.GetRestaurantList("sasa ffdfd");
        }
    }
}
