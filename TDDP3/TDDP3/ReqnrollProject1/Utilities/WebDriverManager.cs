using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.NewFolder
{
    public static class WebDriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (_driver == null)
            {
                Console.WriteLine("Creando una nueva instancia de WebDriver...");
                _driver = browser.ToLower() switch
                {
                    "chrome" => new OpenQA.Selenium.Chrome.ChromeDriver(),
                    "firefox" => new OpenQA.Selenium.Firefox.FirefoxDriver(),
                    "edge" => new OpenQA.Selenium.Edge.EdgeDriver(),
                    _ => throw new ArgumentException($"Browser '{browser}' is not supported")
                };
            }
            else
            {
                Console.WriteLine("Usando la instancia existente de WebDriver...");
            }

            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                Console.WriteLine("Cerrando WebDriver...");
                try
                {
                    _driver.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cerrar WebDriver: " + ex.Message);
                }
                finally
                {
                    _driver = null;
                }
            }
        }
    }
}

