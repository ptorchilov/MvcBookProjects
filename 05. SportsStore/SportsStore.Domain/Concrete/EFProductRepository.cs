namespace SportsStore.Domain.Concrete
{
    using Domain.Abstract;
    using Domain.Entities;
    using System.Linq;

    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
