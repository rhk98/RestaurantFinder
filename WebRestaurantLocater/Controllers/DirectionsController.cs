using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleWebServiceClientLayer;
using ViewModel;

namespace WebRestaurantLocater.Controllers
{
    public class DirectionsController : Controller
    {

        private readonly IGoogleDirectionsServiceClient _googleDirectionsServiceClient;

        public DirectionsController(IGoogleDirectionsServiceClient googleDirectionsServiceClient)
        {
            _googleDirectionsServiceClient = googleDirectionsServiceClient;
        }


        //
        // GET: /Directions/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDirections(string startPostCode, string endPostCode)
        {
            var xx = _googleDirectionsServiceClient.GetDirectionsBetweenPostcodesAsXml("AL6", "lu7");

            IList<DirectionStep> steps = new List<DirectionStep>();

            foreach (var route in xx.Routes)
            {
                foreach (var leg in route.Legs)
                {
                    foreach (var step in leg.Steps)
                    {
                        var directionStep = new DirectionStep();
                        directionStep.Distance = step.Distance.Text;
                        directionStep.Duration = step.Duration.Text;
                        directionStep.HtmlText = step.HtmlDirections;
                        steps.Add(directionStep);
                    }
                }
            }
            return View(steps);
        }

    }
}
