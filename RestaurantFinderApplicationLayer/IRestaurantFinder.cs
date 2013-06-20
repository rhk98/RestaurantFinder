using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer;

namespace RestaurantFinderApplicationLayer
{
    public interface IRestaurantFinder
    {
        IList<Restaurant> GetRestaurantForPostCodeSortedByRating(string postCode);

        void TestForKiss();
    }
}
