using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantFinderApplicationLayer;

namespace WebRestaurantLocater.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantFinder _restaurantFinder;

        public RestaurantController(IRestaurantFinder restaurantFinder)
        {
            _restaurantFinder = restaurantFinder;
        }
        
        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRestaurantsFor(string postCode)
        {
            var model = _restaurantFinder.GetRestaurantForPostCodeSortedByRating(postCode);

            return View(model);
        }

    }
}
