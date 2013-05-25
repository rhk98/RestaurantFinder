using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRestaurantLocater.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to RKs TakeAway locator along with Directions!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string myPostCode = formCollection["takeawayPostcode"];
            if (!string.IsNullOrEmpty(myPostCode))
            {
                return RedirectToAction("GetRestaurantsFor", "Restaurant", new { postCode = myPostCode});
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
