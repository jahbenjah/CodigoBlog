using OpenQA.Selenium;
using System;

namespace Facebook
{
    public class IniciaSesion
    {
        private readonly string Email = "email";
        private readonly string Password = "pass";
        private readonly string Inicia = "u_0_2";

        private IWebDriver _driver;
        public IniciaSesion(IWebDriver driver)
        {
            _driver = driver;
        }

        public void IngresarCorreoElectronico(string correo)
        {
            var emailElement = _driver.FindElement(By.Id(Email));
            emailElement.SendKeys(correo);
        }
        public void IngresarPassword(string password)
        {
            var passwordElement = _driver.FindElement(By.Id(Password));
            passwordElement.SendKeys(password);
        }
        public void IniciarSesion()
        {
            var iniciarSesionElement = _driver.FindElement(By.Id(Inicia));
            iniciarSesionElement.Click();
        }
    }
}
