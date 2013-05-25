using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Google;
using GoogleWebServiceClientLayer;

namespace RestaurantFinderApplicationLayer
{
    class DirectionsApplicationLayer : IDirectionsApplicationLayer
    {
        private readonly IGoogleDirectionsServiceClient _googleDirectionsServiceClient;

        public DirectionsApplicationLayer(IGoogleDirectionsServiceClient googleDirectionsServiceClient)
        {
            _googleDirectionsServiceClient = googleDirectionsServiceClient;
        }
        
        public DirectionsRoute GetDirections(string startPostCode, string endPostCode)
        {
            return _googleDirectionsServiceClient.GetDirectionsBetweenPostcodesAsXml(startPostCode, endPostCode);
        }
    }
}
