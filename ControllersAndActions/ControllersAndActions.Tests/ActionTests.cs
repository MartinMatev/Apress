using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            // Arrange - create the controller
            var target = new ExampleController();

            // Act - call the action method
            RedirectToRouteResult result = target.Redirect();

            // Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["id"]);
        }

        [TestMethod]
        public void ViewSelectionTest()
        {
            // Arrange - create the controller
            var target = new ExampleController();

            // Act - call the action method
            ViewResult result = target.Index();

            // Assert
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewBag.Date, typeof(System.DateTime));
        }
    }
}
