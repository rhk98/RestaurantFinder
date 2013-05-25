using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.Google
{
    public class DirectionsRoute
    {
        public string Status { get; set; }
        public IList<Route> Routes;
    }
}
