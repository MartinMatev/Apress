using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    [SimpleMessage(Message = "A", Order = 1)]
    public class CustomerController : Controller
    {
        [SimpleMessage(Message = "B", Order = 1)]
        [SimpleMessage(Message = "C", Order = 2)]
        public string Index()
        {
            return "This is the Customer controller";
        }

        [CustomOverrideActionFilters]
        [SimpleMessage(Message = "Overriden A", Order = 1)]
        public string OverridenAttributeMethod()
        {
            return "This Customer controller methods overrides the class defined attributes!";
        }
	}
}