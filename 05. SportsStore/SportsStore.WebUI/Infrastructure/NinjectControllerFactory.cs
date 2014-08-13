namespace SportsStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Domain.Abstract;
    using Domain.Entities;
    using Moq;
    using Ninject;

    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var mock = new Mock<IProductsRepository>();


            mock.Setup(m => m.Products).Returns(new List<Product>
                {
                    new Product { Name = "Football", Price = 25},
                    new Product { Name = "Surf board", Price = 179},
                    new Product {Name = "Running shoes", Price = 95}
                }.AsQueryable());

            ninjectKernel.Bind<IProductsRepository>().ToConstant(mock.Object);
        }
    }
}