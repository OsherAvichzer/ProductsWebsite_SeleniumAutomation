using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class OrderProducts : BaseTest
    {
        [TestInitialize]
        public void ItemInCart()
        {
            HomePage Home = new HomePage(driver);
            for (int i = 0; i < 5; i++)
            {
                Home.AddElementToCart(i);
                driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
            }
            Home.ClickOnCartPage();
        }

        //check money
        [TestMethod]
        public void OrderProductsTest()
        {
            CartPage Cart = new CartPage(driver);

            double beginningMoney = Cart.RemainingMoney();
            double purchaseAmount = Cart.TotalProductPrice();

            Assert.AreEqual(purchaseAmount, Cart.TotalButtonPrice());

            Cart.Purche(5);

            Assert.IsTrue(Cart.IsCongratsButtonDisplay());

            double moneyAtTheEnd = Cart.RemainingMoney();
            Assert.AreEqual(beginningMoney - purchaseAmount, moneyAtTheEnd);

            Cart.CloseCongratsMessage();
        }

        [TestMethod]
        public void OrderProductsTest2()
        {
            CartPage Cart = new CartPage(driver);
            Assert.AreEqual(Cart.TotalProductPrice(), Cart.TotalButtonPrice());

            Cart.Purche(5);

            Assert.IsTrue(Cart.IsCongratsButtonDisplay());
            Cart.CloseCongratsMessage();
        }
    }
}
