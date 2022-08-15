using Alura.Leilaoonline.Selenium.Fixtures;
using Alura.Leilaoonline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.Testes
{
	[Collection ("Firefox Driver")]
	public class AoFiltrarLeiloes
	{
		IWebDriver driver;

		public AoFiltrarLeiloes(TestFixture fixture)
		{
			this.driver = fixture.Driver;
		}

		[Fact]
		public void DadoLoginInteressadaDeveMostrarPainelResultado(){
			//arrange
			var loginPO = new LoginPO(driver);
			var dashboardPO = new DashboardInteressadaPO(driver);
			loginPO.Visitar();
			loginPO.PreencherFormulario("fulano@example.org", "123");
			loginPO.SumeterFormulario();

			//act
			dashboardPO.PesquisarLeiloes(new List<string> {"Arte", "Coleções" }, "", true);

			//assert
			Assert.Contains("Resultado da pesquisa", driver.PageSource);
		}
	}
}
