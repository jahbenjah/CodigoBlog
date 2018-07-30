using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook
{
    public class Muro
    {
        private readonly string Nombre = "div.linkWrap.noCount";
        private IWebDriver _driver;
        public Muro(IWebDriver driver)
        {
            _driver = driver;
        }
        public string GetNombre()
        {
            var NombreElement = _driver.FindElement(By.CssSelector(Nombre));
            return NombreElement.Text;
        }
    }
}
