using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Google;

namespace RestaurantFinderApplicationLayer
{
    public interface IDirectionsApplicationLayer
    {
        DirectionsRoute GetDirections(string startPostCode, string endPostCode);
    }
}
