using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class DeleteProdFromCart : BaseTest
    {
        [TestInitialize]
        public void AddProductToCart()
        {
            HomePage Home = new HomePage(driver);
            CartPage Cart = new CartPage(driver);

            int productsAmount = Home.ProductsAmount();
            for (int i = 0; i < productsAmount; i++)
            {
                Home.ClickAddToCartButton(i);
            }

            driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
            Home.ClickOnCartPage();
        }

        [TestMethod]
        public void DeleteProductFromCart()
        {
            HomePage Home = new HomePage(driver);
            CartPage Cart = new CartPage(driver);

            int productsAmount = Home.ProductsAmount();
            for (int i = productsAmount; i > 0; i--)
            {
                Cart.DeleteProduct(i);
            }
        }
    }
}
