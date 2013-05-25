using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DomainLayer;

namespace RestaurantFinderUtilityClasses
{
    public interface IXMLParsers
    {
        T CovertNode<T>(XmlNode node);
    }
}
