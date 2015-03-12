namespace SportsStore.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Domain.Abstract;

    public class NavController : Controller
    {
        private readonly IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(String category = null)
        {
            ViewBag.SelectedCategory = category;

            var categories = repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categories);
        }

    }
}
