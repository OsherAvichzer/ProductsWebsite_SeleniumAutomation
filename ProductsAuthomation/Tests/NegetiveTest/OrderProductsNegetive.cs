using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.NegetiveTest
{
    [TestClass] 
    public class OrderProductsNegetive : BaseTest
    {
        [TestInitialize]
        public void ItemInCart()
        {
            HomePage Home = new HomePage(driver);
            Home.AddElementToCart(6);
            driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
            Home.ClickOnCartPage();
        }

        [TestMethod]
        public void OrderProductsTest()
        {
            CartPage Cart = new CartPage(driver);
            Assert.AreEqual(Cart.TotalProductPrice(), Cart.TotalButtonPrice());

            Cart.Purche(5);

            Assert.IsTrue(Cart.IsErrorMessegeDisplay());
        }
    }
}
