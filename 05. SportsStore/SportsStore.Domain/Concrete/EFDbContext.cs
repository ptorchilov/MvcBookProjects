namespace SportsStore.Domain.Concrete
{
    using Domain.Entities;
    using System.Data.Entity;

    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}