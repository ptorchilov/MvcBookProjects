namespace SportsStore.WebUI.Controllers
{
    using System;
    using System.Web.Mvc;
    using Domain.Abstract;
    using System.Linq;
    using Models;

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(String category, int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                        repository.Products.Count() :
                        repository.Products.Count(e => e.Category == category)
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}
