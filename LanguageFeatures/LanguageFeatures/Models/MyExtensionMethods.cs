using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
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
    }
}