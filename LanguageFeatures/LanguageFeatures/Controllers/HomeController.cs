namespace LanguageFeatures.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using LanguageFeatures.Models;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        #region Public Methods and Operators

        public ViewResult AutoProperty()
        {
            var product = new Product { Name = "Kobyak" };

            string productName = product.Name;

            return View("Result", (Object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreateCollection()
        {
            String[] stringArray = { "apple", "orange", "plum" };

            var intList = new List<int> { 10, 20, 30, 40 };

            var myDictionary = new Dictionary<String, int>
                                   {
                                       { "apple", 10 }, { "orange", 20 }, { "plum", 30 }
                                   };

            return View("Result", (Object) stringArray[1]);
        }

        public ViewResult CreateProduct()
        {
            var myProduct = new Product
                                {
                                    ProductID = 100,
                                    Name = "Kobyak",
                                    Description = "A boat for one person",
                                    Price = 270,
                                    Catigory = "Watersports"
                                };

            return View("Result", (Object)String.Format("Category: {0}", myProduct.Price));
        }

        public String Index()
        {
            return "Navigate to URL to show an example";
        }

        #endregion
    }
}