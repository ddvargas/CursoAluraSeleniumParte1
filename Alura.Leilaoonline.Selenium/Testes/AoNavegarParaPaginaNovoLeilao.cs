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
	[Collection("Firefox Driver")]
	public class AoNavegarParaPaginaNovoLeilao
	{
		IWebDriver driver;

		public AoNavegarParaPaginaNovoLeilao(TestFixture fixture)
		{
			this.driver = fixture.Driver;
		}

		[Fact]
		public void DadoLoginAdminDeveAparecerTresCategorias(){
			//arrange
			var loginPO = new LoginPO(driver);
			var novoLeilaoPO = new NovoLeilaoPO(driver);
			loginPO.Visitar();
			loginPO.PreencherFormulario("admin@example.org", "123");
			loginPO.SumeterFormulario();

			//act
			novoLeilaoPO.Visitar();

			//assert
			Assert.Equal(3, novoLeilaoPO.Categorias.Count());
		}
	}
}
