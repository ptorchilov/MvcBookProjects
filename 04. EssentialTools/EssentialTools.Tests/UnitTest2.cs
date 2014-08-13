namespace EssentialTools.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System.Linq;
    
    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
            {
                new Product {Name = "Kobyak", Category = "Watersports", Price = 275M },
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M }
            };


        [TestMethod]
        public void SumProductsCorrectly()
        {
            //arrage
            var discounter = new MinimumDiscoutHelper();
            var target = new LinqValueCalculator(discounter);
            var goalTotal = products.Sum(e => e.Price);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(goalTotal, result);
        }
    }
}