namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
