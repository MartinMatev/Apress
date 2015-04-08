using System;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello, World!";
            ViewBag.Date = DateTime.Now.ToShortTimeString();
            return View("DebugData");
        }

        public ActionResult List()
        {
            return View();
        }
	}
}