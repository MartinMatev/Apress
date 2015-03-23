using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class LegacyController : Controller
    {
        public ActionResult GetLegacyURL(string legacyURL)
        {
            /*One of the overloaded versions of
             * the View method takes a string specifying the name of the view to render and, 
             * without the cast, this would be the overload that the C# compiler thinks I want.
             */
            return View((object)legacyURL);
        }
	}
}