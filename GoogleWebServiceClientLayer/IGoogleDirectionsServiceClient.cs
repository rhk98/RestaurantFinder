using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Google;

namespace GoogleWebServiceClientLayer
{
    public interface IGoogleDirectionsServiceClient
    {
        void GetDirectionsBetweenPostcodesAsXmlAndSaveToFile(string postCode1, string postCode2);
        void GetDirectionsBetweenPostcodes(string postCode1, string postCode2);
        DirectionsRoute GetDirectionsBetweenPostcodesAsXml(string postCode1, string postCode2);
    }
}
