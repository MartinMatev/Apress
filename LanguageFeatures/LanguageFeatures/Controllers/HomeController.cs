using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        public ViewResult AutoProperty()
        {
            // create a new Product object
            Product myProduct = new Product();

            // set the property value
            myProduct.Name = "Kayak";

            // get the property
            string productName = myProduct.Name;

            return View("Result", (object)string.Format("Product name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            //// create a new Product object
            //Product myProduct = new Product();
            
            //// set the property values
            //myProduct.ProductID = 100;
            //myProduct.Name = "Kayak";
            //myProduct.Description = "A boat for one person";
            //myProduct.Price = 275M;
            //myProduct.Category = "Watersports";

            //// Ver.2
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };


            return View("Result", (object)string.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int>() { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>(){
                {"apple", 10}, {"orange", 20}, {"plum", 30}
            };

            return View("Result", (object)myDict["orange"]);
        }

        public ViewResult UseExtension()
        {
            //create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)string.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            //create and populate ShoppingCart
            IEnumerable<Product> cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // create and populate an array of product objects
            Product[] productArray = 
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();

            return View("Result", (object)string.Format("Cart total: {0:c}, Array total: {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            //// Ver.1 Func with a lambda expression
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal productsTotal = 0;
            //foreach (Product prod in products.Filter(categoryFilter))
            //{
            //    productsTotal += prod.Price;
            //}

            //Ver.2 Lambda without Func
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                productsTotal += prod.Price;
            }

            return View("Result", (object)string.Format("Total filtered price (including only products from category 'Soccer'): {0:c}", productsTotal));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat", Category = "Clothing"},
                new {Name = "Apple", Category = "Fruit"}
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" is of type ").Append(item.Category).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProducts()
        {
            Product[] products = 
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            // Old syntax
            //var foundProducts = from match in products
            //                    orderby match.Price descending
            //                    select new { match.Name, match.Price };

            // Preffered syntax
            var foundProducts = products.OrderByDescending(x => x.Price)
                                        .Take(3)
                                        .Select(x => new { x.Name, x.Price });

            // Deffered linq queries are evaluated from scratch every time the results are enumerated
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();
            foreach (var prod in foundProducts)
            {
                result.AppendFormat("Price: {0:c} ", prod.Price);
            }

            return View("Result", (object)result.ToString());
        }
	}
}