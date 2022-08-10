using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Leilaoonline.Selenium.Fixtures;
using Alura.Leilaoonline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.Leilaoonline.Selenium.Testes
{
	[Collection("Firefox Driver")]
	public class AoCriarLeilao
	{
		private IWebDriver driver;

		public AoCriarLeilao(TestFixture fixture)
		{
			this.driver = fixture.Driver;
		}


		[Fact]
		public void DadoLoginAdminValidoDeveCadastrarLeilao(){
			//arrange
			var loginPO = new LoginPO(driver);
			var novoLeilaoPO = new NovoLeilaoPO(driver);
			loginPO.Visitar();
			loginPO.PreencherFormulario("admin@example.org", "123");
			loginPO.SumeterFormulario();
			novoLeilaoPO.Visitar();
			novoLeilaoPO.PreencherFormulario(
				"Leilão de Coleção de Carros",
				"A expressão Lorem ipsum em design gráfico e editoração é um texto padrão em latim utilizado na produção gráfica para preencher os espaços de texto em publicações para testar e ajustar aspectos visuais antes de utilizar conteúdo real.",
				"Item de Colecionador",
				4000,
				"C:\\Users\\varga\\Documents\\SistemasDeInformacao-OFF\\Cursos\\TestesEmDotNET\\colecaoCarros.jpg",
				DateTime.Now.AddDays(20),
				DateTime.Now.AddDays(40)
			);


			//act
			Thread.Sleep(3000);
			novoLeilaoPO.Sumeterformulario();


			//Assert
			Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
		}
	}
}
