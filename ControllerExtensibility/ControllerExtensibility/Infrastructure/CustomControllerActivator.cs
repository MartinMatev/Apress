using System;
using System.Web.Mvc;
using System.Web.Routing;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomControllerActivator : IControllerActivator
    {
        // Demonstrates how you can use the IControllerActivator interface to intercept requests between the controller factory and the dependency resolver.
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(ProductController))
            {
                controllerType = typeof(CustomerController);
            }

            return (IController)DependencyResolver.Current.GetService(controllerType);
        }
    }
}