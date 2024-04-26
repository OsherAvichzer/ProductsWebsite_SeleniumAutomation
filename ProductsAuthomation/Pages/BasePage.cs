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
    public class BasePage
    {
        public static string ViteReactST_URL = "http://localhost:5173/";
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions action;

        public Random rand = new Random();

        public BasePage(IWebDriver Driver)
        {
            this.driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            action = new Actions(driver);
        }


        public string GetTextElement(IWebElement Element)
        {

            return Element.Text;

        }
        public bool ElementDisplayed(IWebElement Element)
        {
            return Element.Displayed;
        }
        public Boolean ElementsEnabled(IWebElement Element)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(Element)).Enabled;
        }
        public void SendTextElement(IWebElement Element, string Text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Element)).SendKeys(Text);
        }
        public void SendTextAllElementList(IList<IWebElement> Elements, string Text)
        {
            for (int i = 0; i < Elements.Count; i++)

                wait.Until(ExpectedConditions.ElementToBeClickable(Elements[i])).SendKeys(Text);
        }
        public void ClickRandomElement(IList<IWebElement> Elements)
        {
            int RandomElement = rand.Next(0, Elements.Count);
            ClickButtonList(Elements, RandomElement);
        }

        public int RandomElementIndex(IList<IWebElement> Elements)
        {
            //int RandomElement = rand.Next(0, Elements.Count);
            //return Elements.ElementAt(RandomElement);
            return rand.Next(0, Elements.Count);
        }

        public void ClickButtonList(IList<IWebElement> Elements, int Index)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Elements[Index])).Click();
        }
        public void RandomValueElemet(IWebElement Element, int MinRange, int MaxRange)
        {
            int RandomElement = rand.Next(MinRange, MaxRange);
            SendTextElement(Element, RandomElement.ToString());
        }
        public void SubmitElements(IWebElement Element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Element)).Submit();
        }
        public void ClickButton(IWebElement Element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Element)).Click();
        }
        public void ClearElement(IWebElement Element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Element)).Clear();
        }
        public string GetValueTextField(IWebElement Element)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(Element)).GetAttribute("value");
        }

        public int CountCharElement(IWebElement Element)
        {
            return GetValueTextField(Element).Length;
        }

        public bool ValidCountChar(IWebElement Elements, int Count)
        {

            if (CountCharElement(Elements) != Count)
            {
                return false;
            }
            return true;
        }
        public bool ValidCountElements(IList<IWebElement> Elements, int CountValidElements)
        {
            if (Elements.Count != CountValidElements)
            {
                return false;
            }
            return true;
        }
        public void ClickAllElementsList(IList<IWebElement> Elements)
        {
            for (int i = 0; i < Elements.Count; i++)

                wait.Until(ExpectedConditions.ElementToBeClickable(Elements[i])).Click();
        }

        public string GetTextAttribute(IWebElement Element, string Attribute)
        {
            return Element.GetAttribute(Attribute);

        }
        public void WaitSecond(int Second)
        {
            Thread.Sleep(Second * 1000);
        }
        public void SendKeyWithoutElement(string Text)
        {
            action.SendKeys(Text).Build().Perform();
        }

        public void SendKeyRandomWithoutElement(int MinRange, int MaxRange)
        {
            int RandomElement = rand.Next(MinRange, MaxRange);
            action.SendKeys(RandomElement.ToString()).Build().Perform();
        }
        public Boolean ElementNotExist(By Element)
        {
            return driver.FindElements(Element).Count() == 0;
        }
        public void DoubleClick(By Element)
        {
            IWebElement Mouse = wait.Until(ExpectedConditions.ElementToBeClickable(Element));
            action.MoveToElement(Mouse).DoubleClick().Build().Perform();
        }
    }
}