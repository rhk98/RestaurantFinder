using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DomainLayer.Google;

namespace GoogleWebServiceClientLayer
{
    public class GoogleXMLUtilityMethods
    {
        public DirectionsRoute GetRouteFromXML(string xml)
        {
            var linqDirections = XElement.Parse(xml);

            var status = linqDirections.Element("status").Value;


            var directionsRoute = new DirectionsRoute();
            directionsRoute.Routes = new List<Route>();

            directionsRoute.Status = status;

            var routesQuery = from route in linqDirections.Descendants("route")
                              select route;

            foreach (var xElement in routesQuery)
            {
                directionsRoute.Routes.Add(GetRouteFromXElement(xElement));
            }

            return directionsRoute;
        }

        public Distance GetDistanceFromXElement(XElement distanceElement)
        {
            if(distanceElement == null)
                throw new ArgumentNullException();

            var distance = new Distance();

            var xElement = distanceElement.Element("text");
            if (xElement != null) 
                distance.Text = xElement.Value;

            var element = distanceElement.Element("value");
            if (element != null)
                distance.Value = int.Parse(element.Value);

            return distance;
        }

        public Duration GetDurationFromXElement(XElement durationElement)
        {
            if (durationElement == null)
                throw new ArgumentNullException();

            var duration = new Duration();

            var xElement = durationElement.Element("text");
            if (xElement != null)
                duration.Text = xElement.Value;

            var element = durationElement.Element("value");
            if (element != null)
                duration.Value = int.Parse(element.Value);

            return duration;
        }

        public Address GetAddressFromXElement(XElement locationElement)
        {
            if (locationElement == null)
                throw new ArgumentNullException();

            var latitude = locationElement.Element("lat").Value;
            var longitude = locationElement.Element("lng").Value;

            return GetAddessFromLatitudeLongitude(latitude, longitude);
        }

        private Address GetAddessFromLatitudeLongitude(string latitude, string longitude)
        {
            return new Address();
        }

        public Step GetStepFromXElement(XElement stepElement)
        {
            if (stepElement == null)
                throw new ArgumentNullException();

            var step = new Step();

            var startLocationElement = stepElement.Element("start_location");
            var endLocationElement = stepElement.Element("end_location");
            var distanceElement = stepElement.Element("distance");
            var durationElement = stepElement.Element("duration");
            

            step.StartAddress = GetAddressFromXElement(startLocationElement);
            step.EndAddress = GetAddressFromXElement(endLocationElement);
            step.Distance = GetDistanceFromXElement(distanceElement);
            step.Duration = GetDurationFromXElement(durationElement);

            step.HtmlDirections = stepElement.Element("html_instructions").Value;

            return step;
        }

        public Leg GetLegFromXElement(XElement legElement)
        {
            if (legElement == null)
                throw new ArgumentNullException();

            var leg = new Leg {Steps = new List<Step>()};

            leg.StartAddress = legElement.Element("start_address").Value;
            leg.EndAddress  = legElement.Element("end_address").Value;

            var stepsQuery = from step in legElement.Descendants("step")
                             select step;

            foreach (var xElement in stepsQuery)
            {
                leg.Steps.Add(GetStepFromXElement(xElement));
            }

            return leg;
        }

        public Route GetRouteFromXElement(XElement routeElement)
        {
            if (routeElement == null)
                throw new ArgumentNullException();


            var route = new Route {Legs = new List<Leg>()};

            route.Summary = routeElement.Element("summary").Value;

            var legsQuery = from leg in routeElement.Descendants("leg")
                            select leg;

            foreach (var xElement in legsQuery)
            {
                route.Legs.Add(GetLegFromXElement(xElement));
            }

            return route;

        }
    }
}
