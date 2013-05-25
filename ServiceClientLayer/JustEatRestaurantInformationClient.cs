using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer;
using RestaurantFinderUtilityClasses;
using ServiceClientLayer.JustEatWebService;

namespace ServiceClientLayer
{
    public class JustEatRestaurantInformationClient : IJustEatRestaurantInformationClient
    {
        private readonly IXMLParsers _xmlParsers;

        public JustEatRestaurantInformationClient(IXMLParsers xmlParsers)
        {
            _xmlParsers = xmlParsers;
        }
        
        public Restaurants GetRestaurantList(string postCode)
        {
            var webservices = new webservices();
            var node = webservices.getRestaurantList(postCode);
            return _xmlParsers.CovertNode<Restaurants>(node);
        }
    }
}
