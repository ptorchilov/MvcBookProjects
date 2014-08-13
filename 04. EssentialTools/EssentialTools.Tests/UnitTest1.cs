namespace EssentialTools.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper GetTestObject()
        {
            return new MinimumDiscoutHelper();
        }

        [TestMethod]
        public void DiscountAbove100()
        {
            //arrange
            IDiscountHelper target = GetTestObject();
            decimal total = 200;

            //act
            var discountedTotal = target.ApplyDiscount(total);

            //assert
            Assert.AreEqual(total * 0.9m, discountedTotal);
        }

        [TestMethod]
        public void DiscountBetween10And100()
        {
            //arrage
            IDiscountHelper target = GetTestObject();

            //act
            var tenDollarDiscount = target.ApplyDiscount(10);
            var hundredDollarDiscount = target.ApplyDiscount(100);
            var fiftyDollarDiscount = target.ApplyDiscount(50);

            //assert
            Assert.AreEqual(5, tenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, hundredDollarDiscount, "100$ discount is wrong");
            Assert.AreEqual(45, fiftyDollarDiscount, "$50 discount is wrong.");
        }

        [TestMethod]
        public void DiscountLessThan10()
        {
            //arrage
            IDiscountHelper target = GetTestObject();

            //act
            var discount5 = target.ApplyDiscount(5);
            var discount0 = target.ApplyDiscount(0);

            //assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DiscountNegativeTotal()
        {
            //arrage
            IDiscountHelper target = GetTestObject();

            //act

            target.ApplyDiscount(-1);
        }
    }
}
