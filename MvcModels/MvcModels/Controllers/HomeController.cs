using System;
using System.Linq;
using System.Web.Mvc;
using MvcModels.Models;
using System.Collections.Generic;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = 
        {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman",Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth",Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName = "Smith",Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones",Role = Role.Guest}
        };
        public ActionResult Index(int? id = 1)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).FirstOrDefault();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        // Binds the data, only for certain fields
        //public ActionResult DisplaySummary([Bind(Include = "City"] ....)

        // Binds the data with option of excluding certain fields
        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")] AddressSummary addressSummary)
        {
            return View(addressSummary);
        }

        public ActionResult Names(IList<string> names)
        {
            // Check if it's null and if SO, initialize names with an empty string array with lenght 0
            //names = names ?? new string[0];

            // Same with collections of type Ilist
            names = names ?? new List<string>();
            return View(names);
        }

        public ActionResult Addresses(FormCollection formData)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();

            //// When I manually invoke the binding process, I am able to restrict the binding process to a single source of data. By default, the binder looks in four places: form data, route data, the query string, and any uploaded files. Below is  shown how to restrict the binder to searching for data in a single location—in this case, the form data.
            //try
            //{
            //    UpdateModel(addresses, formData);
            //}
            //catch (InvalidOperationException e)
            //{
            //    // Inform of exception
            //}
            //return View(addresses);

            UpdateModel(addresses);
            return View(addresses);
        }
    }
}