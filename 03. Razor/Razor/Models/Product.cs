namespace Razor.Models
{
    using System;

    public class Product
    {
        public int ProductID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public decimal Price { get; set; }

        public String Category { get; set; }
    }
}