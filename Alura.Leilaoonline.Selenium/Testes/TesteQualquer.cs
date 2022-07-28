using Alura.Leilaoonline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.Testes
{
	[Collection ("Firefox Driver")]
	public class TesteQualquer
	{
		private IWebDriver driver;

		public TesteQualquer(TestFixture fixture)
		{
			driver = fixture.Driver;
		}


		[Fact]
		public void TesteQualquerParaFuncionalidadeQualquer()
		{
			//Arrange

			//act
			driver.Navigate().GoToUrl("http://localhost:5000");

			//Assert
			Assert.Contains("Leilões Online", driver.Title);
		}
	}
}
