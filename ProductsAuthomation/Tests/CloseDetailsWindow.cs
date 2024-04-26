using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class CloseDetailsWindow : BaseTest
    {
        [TestMethod]
        public void CloseWindows()
        {
            HomePage Home = new HomePage(driver);
            CartPage Cart = new CartPage(driver);
            ProductDetailsPage PD = new ProductDetailsPage(driver);

            int productsAmount = Home.ProductsAmount();
            for (int i = 0; i < productsAmount; i++)
            {
                Home.WaitSecond(2);

                Home.ClickOnDetailsButton(i);
                var productDetailsPageArray = PD.ProductDetails();

                PD.ClickCloseWindow();
            }
        }
    }
}
