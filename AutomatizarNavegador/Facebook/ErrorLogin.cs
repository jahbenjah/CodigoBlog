using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook
{
    public class ErrorLogin
    {
        private readonly string ErrorText = "span._50f6";
        private IWebDriver _driver;

        public ErrorLogin(IWebDriver driver)
        {
            _driver = driver;
        }
        public string GetMensajeError()
        {
            //var mensajeDeErrorElement = _driver.FindElement(By.CssSelector(ErrorText));
            return _driver.Title;
        }
    }
}
