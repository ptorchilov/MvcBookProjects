namespace SportsStore.Domain.Abstract
{
    using System.Linq;
    using Entities;

    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
