using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ProductsAuthomation.Pages
{
    public class CartPage : HomePage
    {
        private IWebElement homeButton => driver.FindElement(By.XPath("//button[contains(@id, 'home')]"));

        private IList<IWebElement> productNamesList => driver.FindElements(By.CssSelector(".MuiListItemText-primary"));
        //private int productNamesListSize => productNamesList.Count();
        
        private IList<IWebElement> productPricesList => driver.FindElements(By.CssSelector(".MuiListItemText-secondary"));
        private IList<IWebElement> productImgList => driver.FindElements(By.XPath("//*[contains(@data-testid, 'cart-item-image')]"));

        private IList<IWebElement> cardProductList => driver.FindElements(By.XPath("//*[contains(@data-testid, 'cart-item-text-')]"));

        private IWebElement orderButton => driver.FindElement(By.XPath("//*[@data-testid='order-button_cart-page']"));

        private IWebElement congratulationsButton => driver.FindElement(By.CssSelector(".MuiButton-textPrimary"));

        private IWebElement errorMessage => driver.FindElement(By.XPath("//*[@data-testid = 'alert-error_cart-page']"));

        //!
        private IList<IWebElement> deleteProductButtonList => driver.FindElements(By.XPath("//*[contains(@class, 'MuiButton-textError')]"));

        private IWebElement remainingMoney => driver.FindElement(By.XPath("//*[@data-testid='total-sum_app-bar']"));

        private IList<IWebElement> deleteProductButtonsList => driver.FindElements(By.CssSelector(".MuiButton-text"));

        public CartPage(IWebDriver driver) : base(driver) { }

        public void DeleteProduct(int productIndex)
        {
            deleteProductButtonList.ElementAt(productIndex);
        }

        public double RemainingMoney()
        {
            return double.Parse(Regex.Match(remainingMoney.Text, @"\d+(\.\d+)?").Value);
        }

        public bool IsErrorMessegeDisplay()
        {
            return ElementDisplayed(errorMessage);
        }

        public bool IsCongratsButtonDisplay()
        {
            return ElementDisplayed(congratulationsButton);
        }

        public void Purche(int itemsAmount)
        {
            ClickOnOrderButton();
            WaitSecond(itemsAmount);
        }

        public void CloseCongratsMessage()
        {
            ClickButton(congratulationsButton);
        }

        public void ClickOnOrderButton()
        {
            ClickButton(orderButton);
        }

        public void GoToHomeButton()
        {
            ClickButton(homeButton);
        }

        public string[] NewItemAddedToCart(int randomIndex)
        {
            //productNamesList.ElementAt(productNamesListSize - 1).Text.Equals(productName);  

            var productName = productNamesList.ElementAt(productNamesList.Count - 1).Text;
            var productPrice = productPricesList.ElementAt(productPricesList.Count - 1).Text;
            var productImg = driver.FindElement(By.XPath("//*[contains(@data-testid, 'cart-item-image-" + randomIndex + "')]"));
            var productImgTitle = GetTextAttribute(productImg, "src");

            string[] productDetails = new string[] { productName, productPrice, productImgTitle };

            return productDetails;
        }

        public double TotalProductPrice()
        {
            double totalProductsPrice = 0;
            foreach(var productPrice in productPricesList)
            {
                totalProductsPrice = totalProductsPrice + double.Parse(Regex.Match(productPrice.Text, @"\d+(\.\d+)?").Value);
            }
            return Math.Round(totalProductsPrice,2);
        }

        public double TotalButtonPrice()
        {
            return double.Parse(Regex.Match(orderButton.Text, @"\d+(\.\d+)?").Value);
        }
    }
}
