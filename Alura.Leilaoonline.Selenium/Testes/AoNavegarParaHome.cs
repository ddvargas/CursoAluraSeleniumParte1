using Alura.Leilaoonline.Selenium.Fixtures;
using OpenQA.Selenium;


namespace Alura.Leilaoonline.Selenium.Testes
{
	[Collection("Firefox Driver")]
	public class AoNavegarParaHome
	{
		private IWebDriver driver;


		//Setup
		public AoNavegarParaHome(TestFixture fixture)
		{
			driver = fixture.Driver;
		}





		[Fact]
		public void DadoNaveagdorAbertoDeveMostrarLeiloesNoTitulo()
		{
			//Arrange

			//act
			driver.Navigate().GoToUrl("http://localhost:5000");

			//Assert
			Assert.Contains("Leilões Online", driver.Title);
		}



		[Fact]
		public void DadoNaveagdorAbertoDeveMostrarOsLeiloesAbertos()
		{
			//Arrange


			//act
			driver.Navigate().GoToUrl("http://localhost:5000");

			//Assert
			Assert.Contains("Próximos Leilões", driver.PageSource);
		}



	}
}