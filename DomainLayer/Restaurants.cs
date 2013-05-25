using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DomainLayer
{
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Restaurants
    {
        [System.Xml.Serialization.XmlElementAttribute("Restaurant")]
        public Restaurant[] MyRestaurants { get; set; } 
    }
}
