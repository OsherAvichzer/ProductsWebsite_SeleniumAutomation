using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductsAuthomation.Pages
{
    public class ProductDetailsPage : HomePage
    {
        private IWebElement productName => driver.FindElement(By.XPath("//*[contains(@id, ':r')]"));
        private IList<IWebElement> productPriceAndDescribtionList => driver.FindElements(By.CssSelector(".MuiDialogContentText-root"));
        private IWebElement productImg => driver.FindElement(By.CssSelector(".MuiDialogContent-root.css-ypiqx9-MuiDialogContent-root > img"));

        private IWebElement addToCartButton => (driver.FindElements(By.XPath("//*[contains(@class,'MuiButton-textPrimary')]"))).ElementAt(0);
        private IWebElement closeWindow => (driver.FindElements(By.XPath("//*[contains(@class,'MuiButton-textPrimary')]"))).ElementAt(1);

        public ProductDetailsPage(IWebDriver driver) : base(driver) { }

        public string[] ProductDetails()
        {
            string productPrice = (Regex.Match(productPriceAndDescribtionList.ElementAt(1).Text, @"\d+(?:\.\d+)?₪").Value);
            var productImgTitle = GetTextAttribute(productImg, "src");

            string[] productDetails = new string[] { productName.Text, productPrice, productImgTitle };

            return productDetails;
        }

        public void ClickAddToCartButton()
        {
            ClickButton(addToCartButton);
        }

        public void ClickCloseWindow()
        {
            ClickButton(closeWindow);
        }
    }
}
