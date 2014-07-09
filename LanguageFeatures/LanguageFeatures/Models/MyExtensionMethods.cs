namespace LanguageFeatures.Models
{
    using System;
    using System.Collections.Generic;

    public static class MyExtensionMethods
    {
        public static decimal TotalProces(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;

            foreach (var product in productEnum)
            {
                total += product.Price;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByCategory(
            this IEnumerable<Product> productEnum, String categoryParam)
        {
            foreach (var product in productEnum)
            {
                if (product.Category == categoryParam)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(
            this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (var product in productEnum)
            {
                if (selectorParam(product))
                {
                    yield return product;
                }
            }
        } 
    }
}