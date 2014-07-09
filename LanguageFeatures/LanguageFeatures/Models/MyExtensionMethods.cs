using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalProces(this ShoppingCart cartParam)
        {
            decimal total = 0;

            foreach (var product in cartParam.Products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}