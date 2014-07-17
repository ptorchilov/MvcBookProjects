namespace EssentialTools.Controllers
{
    using System.Web.Mvc;
    using EssentialTools.Models;

    public class HomeController : Controller
    {
        private readonly Product[] products =
            {
                new Product { Name = "Kobyak", Category = "Watersports", Price = 275M },
                new Product { Name = "Lifejacker", Category = "Watersports", Price = 48.95M },
                new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
            };

        public ActionResult Index()
        {
            IValueCalculator calculator = new LinqValueCalculator();
            var cart = new ShoppingCart(calculator)
                           {
                               Products = products
                           };

            var totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }

    }
}
