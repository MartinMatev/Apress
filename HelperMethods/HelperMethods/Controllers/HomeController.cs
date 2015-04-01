using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ExternalHelpers()
        {
            ViewBag.Fruits = new string[] { "Tomato", "Djanki", "Oranges" };
            ViewBag.Cities = new string[] { "Burgas", "Plovdiv", "Montana" };

            string message = "This is an HTML element: <input>";

            return View((object)message);
        }

        public ActionResult Index()
        {
            ViewBag.Fruits = new string[] { "Tomato", "Djanki", "Oranges" };
            ViewBag.Cities = new string[] { "Burgas", "Plovdiv", "Montana" };

            string message = "This is an HTML element: <input>";

            return View((object)message);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("DisplayPerson", person);
        }
    }
}