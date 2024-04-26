using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class ValidateProductDetails : BaseTest
    {
        [TestMethod]
        public void SameProductDetails()
        {
            HomePage Home = new HomePage(driver);
            CartPage Cart = new CartPage(driver);
            ProductDetailsPage PD = new ProductDetailsPage(driver);

            Home.WaitSecond(3);
            int productsAmount = Home.ProductsAmount();
              for (int i = 0; i < productsAmount; i++) 
            {
                var homePageElementsDetailsArray = Home.ProductDetailsElementCard(i);

                Home.ClickOnDetailsButton(i);

                var productDetailsPageArray = PD.ProductDetails();

                for (int j = 0; j < 3; j++)
                {
                    
                    Assert.AreEqual(homePageElementsDetailsArray[j], productDetailsPageArray[j]);
                }

                PD.ClickCloseWindow();
            }
        }
    }
}
