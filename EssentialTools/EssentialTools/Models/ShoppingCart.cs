namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private readonly IValueCalculator calculator;

        public ShoppingCart(IValueCalculator calculator)
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