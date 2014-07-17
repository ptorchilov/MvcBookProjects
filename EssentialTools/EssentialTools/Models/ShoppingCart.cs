using System.Collections.Generic;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private readonly LinqValueCalculator calculator;

        public ShoppingCart(LinqValueCalculator calculator)
        {
            this.calculator = calculator;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calculator.ValueProducts(Products);
        }
    }
}