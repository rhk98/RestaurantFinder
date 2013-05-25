using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using DomainLayer.Google;
using Newtonsoft.Json;
using RestSharp;

namespace GoogleWebServiceClientLayer
{
    public class GoogleDirectionsServiceClient : IGoogleDirectionsServiceClient
    {
        public void GetDirectionsBetweenPostcodesAsXmlAndSaveToFile(string postCode1, string postCode2)
        {
            var client = new RestClient("http://maps.googleapis.com/maps/api/directions/xml");

            var request = new RestRequest(Method.GET);
            request.AddParameter("origin", postCode1);
            request.AddParameter("destination", postCode2);

            request.AddParameter("sensor", "false");

            var response = client.Execute(request);
            var content = response.Content; // raw content as string

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);


            var fileWithPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\googleDirections.xml";

            xmlDoc.Save(fileWithPath);
        }

        public DirectionsRoute GetDirectionsBetweenPostcodesAsXml(string postCode1, string postCode2)
        {
            var client = new RestClient("http://maps.googleapis.com/maps/api/directions/xml");

            var request = new RestRequest(Method.GET);
            request.AddParameter("origin", postCode1);
            request.AddParameter("destination", postCode2);

            request.AddParameter("sensor", "false");

            var response = client.Execute(request);
            var content = response.Content; // raw content as string

            var googleXMLUtilityMethods = new GoogleXMLUtilityMethods();
            return googleXMLUtilityMethods.GetRouteFromXML(content);

        }

        public void GetDirectionsBetweenPostcodes(string postCode1, string postCode2)
        {
            var client = new RestClient("http://maps.googleapis.com/maps/api/directions/json");

            var request = new RestRequest(Method.GET);
            request.AddParameter("origin", postCode1);
            request.AddParameter("destination", postCode2);

            request.AddParameter("sensor", "false");

            var response = client.Execute(request);
            var content = response.Content; // raw content as string

          

            dynamic xx = JsonConvert.DeserializeObject(content);
            var zz = xx["routes"];

            var serializer = new JavaScriptSerializer();
            dynamic value = serializer.DeserializeObject(content);

            var routes = value["routes"];
            var oneRoute = routes[0]; //One route
            var legs = oneRoute["legs"];
            var oneLeg = legs[0];
            var distance = oneLeg["distance"];
            var duration = oneLeg["duration"];


        }
    }
}
