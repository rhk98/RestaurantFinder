using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.Google
{
    public class Leg
    {
        public string StartAddress { get; set; } //change to address
        public string EndAddress { get; set; }   //change to address
        public Duration Duration { get; set; }
        public Distance Distance { get; set; }

        public IList<Step> Steps { get; set; } 
    }
}
