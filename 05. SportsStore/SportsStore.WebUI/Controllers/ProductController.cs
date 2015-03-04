namespace SportsStore.WebUI.Controllers
{
    using System.Web.Mvc;
    using Domain.Abstract;
    using System.Linq;
    using Models;

    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };

            return View(model);
        }
    }
}
