using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.Google
{
    public class Step
    {
        public Address StartAddress { get; set; }
        public Address EndAddress { get; set; }
        public Duration Duration { get; set; }
        public Distance Distance { get; set; }
        public TravelModes Mode { get; set; }
        public string HtmlDirections { get; set; }
    }
}
