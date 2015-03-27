using System.Web.Mvc;
using ControllerExtensibility.Models;
using System.Threading.Tasks;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        public async Task<ActionResult> Data()
        {
            string data = await Task<string>.Factory.StartNew( () =>
            {
                return new RemoteService().GetRemoteData();
            });
            return View((object)data);
        }

        // You can see that both action methods follow the same basic pattern and that the difference is where the Task object is created.
        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            string data = await new RemoteService().GetRemoteDataAsync();
            return View("Data", (object)data);
        }
	}
}