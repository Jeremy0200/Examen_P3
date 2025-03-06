using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject1.NewFolder;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class EliminarStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public EliminarStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReports.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _driver.Manage().Window.Maximize();
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }
        [Given("El usuario esta en la pagina para hacer el crud-delete")]
        public void GivenElUsuarioEstaEnLaPaginaParaHacerElCrud_Delete()
        {
            _driver.Navigate().GoToUrl("http://localhost:5015/Cliente");
            _test.Log(Status.Pass, "El usuairo navega a la pagina Crud de clientes");
        }

        [When("Se da click en el boton de eliminar")]
        public void WhenSeDaClickEnElBotonDeEliminar()
        {
            _driver.FindElement(By.Id("btn-eliminar-1")).Click();
            _driver.FindElement(By.Id("delete-button")).SendKeys(Keys.PageDown);
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("delete-button")).Click();
        }

        [Then("Verificar la url de la pagina final")]
        public void ThenVerificarLaUrlDeLaPaginaFinal()
        {
            try
            {
                bool isErrorVisible = _driver.Url.Equals("http://localhost:5015/Cliente");
                if (isErrorVisible)
                {
                    _test.Log(Status.Pass, "Usuario Eliminado");
                }
                else
                {
                    _test.Log(Status.Fail, "Usuario no Eliminado");
                }
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.QuitDriver();
            _extent.Flush();
        }
    }
}
