using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            int currentHour = DateTime.Now.Hour;
            ViewBag.Greeting = currentHour < 12 ? "Good Morning" : "Good Evening";
            return View();
        }

        [HttpGet]
        public ViewResult RspvForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RspvForm(GuestResponses guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
	}
}