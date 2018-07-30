using Facebook;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;
using System.IO;

namespace FacebookTest
{
    public class IniciaSesionTest : IDisposable
    {
        private IWebDriver _driver;
        public IniciaSesionTest()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            //_driver = new FirefoxDriver(Directory.GetCurrentDirectory());
            _driver.Navigate().GoToUrl("https://www.facebook.com/");
            _driver.Manage().Window.Maximize();
        }
        public void Dispose()
        {
           _driver.Close();
        }
        [Fact]
        public void Login()
        {
            IniciaSesion login = new IniciaSesion(_driver);
            login.IngresarCorreoElectronico("");
            login.IngresarPassword("");
            login.IniciarSesion();
            var muro = new Muro(_driver);
            Assert.Equal("Benjamin Camacho",muro.GetNombre());
        }
        [Theory]
        [InlineData("usuario", "password1")]
        [InlineData("usuario2", "password2")]
        public void FailedLogin(string usuario, string contraseña)
        {
            IniciaSesion login = new IniciaSesion(_driver);
            login.IngresarCorreoElectronico(usuario);
            login.IngresarPassword(contraseña);
            login.IniciarSesion();
            var error = new ErrorLogin(_driver);
            Assert.Equal("Inicia sesión en Facebook", error.GetMensajeError());
        }
    }
}
