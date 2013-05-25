using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.Google
{
    public class Address
    {
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string HouseName { get; set; }
        public int HouseNumber { get; set; }

    }
}
