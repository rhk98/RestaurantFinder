using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DomainLayer
{
    [Serializable()]
    public class Restaurant
    {
        [System.Xml.Serialization.XmlElement("RestaurantId")]
        public int RestaurantId { get; set; }

        [System.Xml.Serialization.XmlElement("AvgRating")]
        public string AvgRating { get; set; }

        public float AverageRating
        {
            get { return string.IsNullOrEmpty(AvgRating) ? (float) 0.0 : float.Parse(AvgRating); }
        }

        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("Foodtype1")]
        public string Foodtype1 { get; set; }

        [System.Xml.Serialization.XmlElement("Foodtype2")]
        public string Foodtype2 { get; set; }

        [System.Xml.Serialization.XmlElement("URL")]
        public string URL { get; set; }

        [System.Xml.Serialization.XmlElement("Address")]
        public string Address { get; set; }

        [System.Xml.Serialization.XmlElement("Postcode")]
        public string PostCode { get; set; }

        [System.Xml.Serialization.XmlElement("Open")]
        public string Open { get; set; }
    }
}
