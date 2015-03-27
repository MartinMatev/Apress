using System.Web.SessionState;
using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Fast ",
                ActionName = "Index"
            });
        }
	}
}