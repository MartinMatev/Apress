using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            /*
            ModelState.IsValid tells you if any model errors have been added to ModelState.
            The default model binder will add some errors for basic type conversion issues (for example, passing a non-number for something which is an "int"). You can populate ModelState more fully based on whatever validation system you're using.
            The sample DataAnnotations model binder will fill model state with validation errors taken from the DataAnnotations attributes on your model.
             */
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved.", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }
	}
}