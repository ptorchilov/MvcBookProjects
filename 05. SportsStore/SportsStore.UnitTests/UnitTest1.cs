namespace SportsStore.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Abstract;
    using Domain.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WebUI.Controllers;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanPaginate()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new []
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 1, Name = "P2"},
                new Product {ProductID = 1, Name = "P3"},
                new Product {ProductID = 1, Name = "P4"},
                new Product {ProductID = 1, Name = "P5"}
            }.AsQueryable());

            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = (IEnumerable<Product>) controller.List(2).Model;

            //Assert
            var productArray = result.ToArray();
            Assert.IsTrue(productArray.Length == 2);
            Assert.AreEqual(productArray[0].Name, "P4");
            Assert.AreEqual(productArray[1].Name, "P5");
        }
    }
}
