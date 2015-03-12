namespace SportsStore.UnitTests
{
    using System.Linq;
    using Domain.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_AddNewLines()
        {
            //Arrange - create test products
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };

            //Arrange - create new cart
            var cart = new Cart();

            //Action
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            var cartLines = cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(cartLines.Length, 2);
            Assert.AreEqual(cartLines[0].Product, product1);
            Assert.AreEqual(cartLines[1].Product, product2);
        }

        [TestMethod]
        public void Can_AddQuantityForExistingLine()
        {
            //Arrange - create products
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };

            //Arrange - create a new cart
            var cart = new Cart();

            //Act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product1, 10);

            var cartLines = cart.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            //Assert
            Assert.AreEqual(cartLines.Length, 2);
            Assert.AreEqual(cartLines[0].Quantity, 11);
            Assert.AreEqual(cartLines[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_RemoveLine()
        {
            //Arrange - create products
            var product1 = new Product { ProductID = 1, Name = "P1" };
            var product2 = new Product { ProductID = 2, Name = "P2" };
            var product3 = new Product { ProductID = 3, Name = "P3" };

            //Arrange - create cart
            var cart = new Cart();

            //Arrange - add products in cart
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 3);
            cart.AddItem(product3, 5);
            cart.AddItem(product2, 1);

            //Act
            cart.RemoveLine(product2);

            //Assert
            Assert.AreEqual(cart.Lines.Count(l => l.Product == product2), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_CartTotal()
        {
            //Arrange - create products
            var product1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            var product2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            //Arrange - create cart
            var cart = new Cart();

            //Act
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product1, 3);

            var result = cart.ComputeTotalvalue();

            //Assert
            Assert.AreEqual(result, 450M);
        }

        [TestMethod]
        public void Can_ClearContents()
        {
            //Arrange - create products
            var product1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            var product2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            //Arrange - create new cart
            var cart = new Cart();

            //Arrange - add some products
            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            //Act - reset the cart
            cart.Clear();

            //Assert
            Assert.AreEqual(cart.Lines.Count(), 0);
        }
    }
}
