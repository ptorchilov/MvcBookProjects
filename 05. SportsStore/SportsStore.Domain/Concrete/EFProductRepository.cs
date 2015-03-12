namespace SportsStore.Domain.Concrete
{
    using Abstract;
    using Entities;
    using System.Linq;

    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
