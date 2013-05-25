using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.Google
{
    public class Route
    {
        public string Summary { get; set; }
        public IList<Leg> Legs { get; set; } 
    }
}
