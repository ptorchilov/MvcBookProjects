namespace SportsStore.WebUI.Models
{
    using System.Collections.Generic;
    using Domain.Entities;

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}