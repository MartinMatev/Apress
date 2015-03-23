using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";

            return View("ActionName");
        }

        public ActionResult CustomVariable(string catchall = "nothing", string id = "DefaultId")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            //ViewBag.CustomVariable = RouteData.Values["id"];
            // Routing-a предава данните си на ActionResult-а
            ViewBag.CustomVariable = id;
            string[] splittedCatch = catchall.Split('/');
            ViewBag.Caught = splittedCatch;

            return View();
        }
	}
}