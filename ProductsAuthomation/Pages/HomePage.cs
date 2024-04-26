using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ProductsAuthomation.Pages
{
    public class HomePage : BasePage
    {

        private IWebElement Ex => driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[2]/span[5]/div[1]]"));
        private IList<IWebElement> Ex2 => driver.FindElements(By.XPath("s"));

        //private IWebElement addToCartButton => driver.FindElement(By.XPath("//*[@data-testid = 'add-cart-button_product-card-0_home-page']"));
        private IList<IWebElement> addToCartButtonsList => driver.FindElements(By.XPath("//button[contains(@data-testid,'add-cart-button_product-card')]"));
        private IList<IWebElement> cardProductList => driver.FindElements(By.XPath("//*[contains(@data-testid,'card_product-card')]"));

        private IWebElement goToCartPageButton => driver.FindElement(By.XPath("//button[contains(@id, 'cart')]"));

        private IList<IWebElement> cardDetailsButtonList => driver.FindElements(By.XPath("//*[contains(@data-testid, 'description-button_product-card')]"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickOnDetailsButton(int productItemNumber)
        {
            ClickButtonList(cardDetailsButtonList, productItemNumber);
        }

        public int ProductsAmount()
        {
            WaitSecond(3);
            return cardProductList.Count();
        }

        public void ClickOnCartPage()
        {
            WaitSecond(3);
            ClickButton(goToCartPageButton);
        }

        public void AddElementToCart(int elementPlace)
        {
            WaitSecond(3);
            ClickButton(addToCartButtonsList.ElementAt(elementPlace));
        }

        public void AddRndomElementToToCart()
        {
            WaitSecond(3);
            ClickRandomElement(addToCartButtonsList);
        }

        public int RandomIndexFromListSize()
        {
            return RandomElementIndex(cardProductList);
        }

        public string[] ProductDetailsElementCard(int randomIndex)
        {
            WaitSecond(3);

            var productName = driver.FindElement(By.XPath("//*[contains(@data-testid,'product-name_product-card-" + randomIndex + "')]")).Text; 
            var productPrice = driver.FindElement(By.XPath("//*[contains(@data-testid,'product-price_product-card-" + randomIndex + "')]")).Text;
            var productImg = driver.FindElement(By.XPath("//*[contains(@data-testid,'product-image_product-card-" + randomIndex + "')]"));
            var productImgTitle = GetTextAttribute(productImg, "src");

            string[] productDetails = new string[] { productName, productPrice, productImgTitle };

        //    ClickButton(addToCartButtonsList.ElementAt(randomIndex));
          
            return productDetails;
        }

        public void ClickAddToCartButton(int productNumber)
        {
            ClickButton(addToCartButtonsList.ElementAt(productNumber));
        }
    }
}