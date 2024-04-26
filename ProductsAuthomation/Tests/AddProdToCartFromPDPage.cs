using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class AddProdToCartFromPDPage : BaseTest
    {
        [TestMethod]
        public void AddProductToCart()
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

                PD.ClickAddToCartButton();
                driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
                Home.ClickOnCartPage();

                var cartPageElementsDetailsListArray = Cart.NewItemAddedToCart(i);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(productDetailsPageArray[j], cartPageElementsDetailsListArray[j]);
                }

                Cart.GoToHomeButton();
            }
        }
    }
}
