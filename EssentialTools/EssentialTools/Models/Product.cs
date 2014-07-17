using System;

namespace EssentialTools.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public decimal Price { get; set; }

        public String Category { get; set; }
    }
}