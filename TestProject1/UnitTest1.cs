using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Reflection;

namespace TestProject1
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			IWebDriver driver = new FirefoxDriver(
				Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

			driver.Navigate().GoToUrl("http://localhost:5000");

			Assert.Contains("Online", driver.Title);

			driver.Quit();
		}
	}
}