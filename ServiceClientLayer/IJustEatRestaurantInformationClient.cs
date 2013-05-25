using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer;

namespace ServiceClientLayer
{
    public interface IJustEatRestaurantInformationClient
    {
        Restaurants GetRestaurantList(string postCode);
    }
}
