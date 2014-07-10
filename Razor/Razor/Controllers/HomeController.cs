﻿namespace Razor.Controllers
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

    }
}
