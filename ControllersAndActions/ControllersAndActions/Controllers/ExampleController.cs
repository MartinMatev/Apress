using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Sup matey";
            ViewBag.Date = DateTime.Now;
            // Take the data from the TempData, deleting it
            //ViewBag.Message = TempData["Message"];
            //ViewBag.Date = TempData["Date"];

            // Take it with a peek, leaving it in the TempData container
            //string message = (string)TempData.Peek("Message");
            //DateTime date = (DateTime)TempData.Peek("Date");

            // You can preserve a value that would otherwise be deleted by using the Keep method, like this:
            //TempData.Keep("Message");
            //TempData.Keep("Date");

            return View();
        }

        public RedirectToRouteResult Redirect()
        {
            return RedirectToRoute(new 
            {
                controller = "Example",
                action = "Index",
                id = "MyID"
            });
        }

        // Assigning temp data
        public RedirectToRouteResult RedirectToRoute()
        {
            TempData["Message"] = "Sup matey";
            TempData["Date"] = DateTime.Now;

            return RedirectToAction("Index");
        }

        // you can override the layout used by a view by explicitly naming an alternative, like this:
        public ViewResult Example()
        {
            return View("Index", "_AlternateLayoutPage");
        }

        public HttpStatusCodeResult StatusCode()
        {
            //return HttpNotFound();
            return new HttpUnauthorizedResult();
            //return new HttpStatusCodeResult(404, "YOU ARE NOT PREPARED");
        }
	}
}