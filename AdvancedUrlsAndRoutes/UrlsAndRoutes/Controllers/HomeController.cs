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

        public ViewResult MyActionMethod()
        {
            // myActionUrl variable would be set to /Home/Index/MyID
            string myActionUrl = Url.Action("Index", new { id = "MyID" });

            // myRouteUrl variable would be set to /
            string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });

            //.... do something with URLs...
            return View();
        }

        //public RedirectToRouteResult MyActionMethod()
        //{
        //    return RedirectToRoute(new { controller = "Home", aciton = "Index", id = "MyID"});
        //}
	}
}