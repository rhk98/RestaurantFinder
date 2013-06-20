using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer;
using ServiceClientLayer;

namespace RestaurantFinderApplicationLayer
{
    public class RestaurantFinder : IRestaurantFinder
    {
        private readonly IJustEatRestaurantInformationClient _restaurantInformationClient;

        public RestaurantFinder(IJustEatRestaurantInformationClient restaurantInformationClient)
        {
            _restaurantInformationClient = restaurantInformationClient;
        }
        
        public IList<Restaurant> GetRestaurantForPostCodeSortedByRating(string postCode)
        {
            var restaurants = _restaurantInformationClient.GetRestaurantList(postCode);
            if (restaurants == null)
                throw new Exception("Error getting restaurants from Service. Aborting!");
            return restaurants.MyRestaurants.OrderByDescending(x => x.AverageRating).ToList();
        }


        public void TestForKiss()
        {
            throw new NotImplementedException();
        }
    }
}
