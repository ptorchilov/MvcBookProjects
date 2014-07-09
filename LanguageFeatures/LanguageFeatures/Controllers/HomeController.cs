namespace LanguageFeatures.Controllers
{
    using System;
    using System.Web.Mvc;

    using LanguageFeatures.Models;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public String Index()
        {
            return "Navigate to URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            var product = new Product();

            product.Name = "Kobyak";

            var productName = product.Name;

            return View("Result", (Object) String.Format("Product name: {0}", productName));
        }
    }
}
