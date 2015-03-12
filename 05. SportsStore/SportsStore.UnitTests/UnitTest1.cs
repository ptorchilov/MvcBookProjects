namespace SportsStore.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Domain.Abstract;
    using Domain.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WebUI.Controllers;
    using WebUI.HtmlHelpers;
    using WebUI.Models;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new[]
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
            var result = (ProductsListViewModel) controller.List(null, 2).Model;

            //Assert
            var productArray = result.Products.ToArray();
            Assert.IsTrue(productArray.Length == 2);
            Assert.AreEqual(productArray[0].Name, "P4");
            Assert.AreEqual(productArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_GeneratePageLinks()
        {
            //Arrnge - define an HTML helper
            HtmlHelper helper = null;

            //Arrange - create PagingInfo data
            var pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //Arrange - set up delegate
            Func<int, String> pageUrlDelegate = i => "Page" + i;

            //Act
            var result = helper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
                + @"<a class=""selected"" href=""Page2"">2</a>"
                + @"<a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_SendPaginationViewModel()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new []
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }.AsQueryable());

            //Arrage
            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = (ProductsListViewModel) controller.List(null, 2).Model;

            //Assert
            var pageInfo = result.PagingInfo;
            
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_FilterProducts()
        {
            //Arrange - create mock repository
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new []
            {
                new Product { ProductID = 1, Name = "P1", Category = "Cat1" }, 
                new Product { ProductID = 2, Name = "P2", Category = "Cat2" }, 
                new Product { ProductID = 3, Name = "P3", Category = "Cat1" }, 
                new Product { ProductID = 4, Name = "P4", Category = "Cat2" }, 
                new Product { ProductID = 5, Name = "P5", Category = "Cat3" }
            }.AsQueryable());

            //Arrage - create a controller and make the page size items
            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Action
            var result = ((ProductsListViewModel) controller.List("Cat2", 1).Model)
                .Products.ToArray();

            //Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
    }
}
