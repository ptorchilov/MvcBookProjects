namespace Razor.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Razor.Models;

    public class HomeController : Controller
    {
        private Product myProduct = new Product
                                        {
                                            ProductID = 1,
                                            Name = "Kobyak",
                                            Description = "A boat for one person",
                                            Category = "Watersports",
                                            Price = 275M
                                        };

        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            var array = new []
                {
                    new Product { Name = "Kobyak", Price = 275M },
                    new Product { Name = "Lifejacker", Price = 48.95M},
                    new Product { Name = "Soccer ball", Price = 19.50M},
                    new Product { Name = "Corner flag", Price = 34.95M}
                };

            return View(array);
        }
    }
}
