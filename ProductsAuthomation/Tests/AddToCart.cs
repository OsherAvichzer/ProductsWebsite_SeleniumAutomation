using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAuthomation.Pages;

namespace ProductsAuthomation.Tests
{
    [TestClass]
    public class AddToCart : BaseTest
    {
        [TestMethod]
        public void Home()
        {
            HomePage Home = new HomePage(driver);
        }

        //[TestMethod]
        //public void AddToCart()
        //{
        //    HomePage Home = new HomePage(driver);
        //    int randomElementIndex = Home.RandomIndexFromListSize();
        //    var homePageElementsDetailsArray = Home.RandomElementCard(randomElementIndex);

        //    Home.ClickOnCartPage();
        //    CartPage Cart = new CartPage(driver);
        //    var cartPageElementsDetailsListArray = Cart.NewItemAddedToCart(randomElementIndex);

        //    for(int i = 0; i < 3; i++)
        //    {
        //        Assert.AreEqual(homePageElementsDetailsArray[i], cartPageElementsDetailsListArray[i]);
        //    }
        //}

        [TestMethod]
        public void AddToCartTest()
        {
            HomePage Home = new HomePage(driver);
            CartPage Cart = new CartPage(driver);

            int productsAmount = Home.ProductsAmount();
            for (int i = 0; i < productsAmount; i++)
            {
                var homePageElementsDetailsArray = Home.ProductDetailsElementCard(i);
                Home.ClickAddToCartButton(i);

                driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
                Home.ClickOnCartPage();

                var cartPageElementsDetailsListArray = Cart.NewItemAddedToCart(i);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(homePageElementsDetailsArray[j], cartPageElementsDetailsListArray[j]);
                }
                driver.ExecuteScript("window.scrollTo(0, -document.body.scrllHeight);");
                Cart.GoToHomeButton();
            }
        }
    }
}