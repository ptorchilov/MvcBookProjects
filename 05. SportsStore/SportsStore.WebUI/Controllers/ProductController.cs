namespace SportsStore.WebUI.Controllers
{
    using System.Web.Mvc;
    using Domain.Abstract;

    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}
