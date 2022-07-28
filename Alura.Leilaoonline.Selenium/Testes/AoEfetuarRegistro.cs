using Alura.Leilaoonline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.Testes
{
	[Collection("Firefox Driver")]
	public class AoEfetuarRegistro
	{
		private IWebDriver driver;


		public AoEfetuarRegistro(TestFixture fixture)
		{
			driver = fixture.Driver;
		}



		[Fact]
		public void DodoInformacoesValidasDeveIrAtePaginaDeAgradecimento(){
			//Arrange
			//Dado o firefox aberto, na página inicial do site de leilões
			//Dados de registro válidos informados
			driver.Navigate().GoToUrl("http://localhost:5000");

			var imputNome = driver.FindElement(By.Id("Nome"));
			var imputEmail = driver.FindElement(By.Id("Email"));
			var imputPassword = driver.FindElement(By.Id("Password"));
			var imputConfPassword = driver.FindElement(By.Id("ConfirmPassword"));
			var button = driver.FindElement(By.Id("btnRegistro"));


			//Act
			imputNome.SendKeys("Daniel Leonardo de Capriocórnio");
			imputEmail.SendKeys("diCaprio@email.com");
			imputPassword.SendKeys("1234");
			imputConfPassword.SendKeys("1234");
			button.Click();


			//Assert
			Assert.Contains("Obrigado", driver.PageSource);
		}





		[Fact]
		public void DodoInformacoesVaziasDeveMostrarErroNaHome()
		{
			//Arrange
			driver.Navigate().GoToUrl("http://localhost:5000");
			var button = driver.FindElement(By.Id("btnRegistro"));

			//Act
			button.Click();

			//Assert
			Assert.Contains("section-registro", driver.PageSource);
			Assert.Contains("", driver.PageSource);
		}

		[Theory]
		[InlineData ("", "", "", "")]
		[InlineData ("", "jucemar@email.com", "12345", "12345")]
		[InlineData ("José Jucemar", "", "12345", "12345")]
		[InlineData ("José Jucemar", "jucemar@email.com", "", "12345")]
		[InlineData ("José Jucemar", "jucemar@email.com", "12345", "")]
		public void DadoCampoEmBrancoDeveMostrarMsgDeErro(
				string nome,
				string email,
				string senha,
				string confSenha){
			//Arrange
			IWebElement msgError = null;
			driver.Navigate().GoToUrl("http://localhost:5000");
			var imputNome = driver.FindElement(By.Id("Nome"));
			var imputEmail = driver.FindElement(By.Id("Email"));
			var imputPassword = driver.FindElement(By.Id("Password"));
			var imputConfPassword = driver.FindElement(By.Id("ConfirmPassword"));
			var button = driver.FindElement(By.Id("btnRegistro"));

			//act
			imputNome.SendKeys(nome);
			imputEmail.SendKeys(email);
			imputPassword.SendKeys(senha);
			imputConfPassword.SendKeys(confSenha);
			button.Click();

			//Assert
			if (nome == ""){
				msgError = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome"));
			}
			if (email == "")
			{
				msgError = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email"));
			}
			if (senha == ""){
				msgError = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Password"));
			}
			if (confSenha == ""){
				msgError = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=ConfirmPassword"));
			}

			//Assert
			Assert.False(string.IsNullOrEmpty(msgError.Text));
		}


		[Theory]
		[InlineData ("daniel@")]
		[InlineData ("daniel")]
		public void DadoEmailInvalidoDeveMostrarMsgDeErroApropriada(string email){
			//Arrage
			driver.Navigate().GoToUrl("http://localhost:5000");
			var imputEmail = driver.FindElement(By.Id("Email"));
			var button = driver.FindElement(By.Id("btnRegistro"));
			IWebElement msgError = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email"));


			//act
			imputEmail.SendKeys(email);
			button.Click();

			//Assert
			Assert.Equal("Please enter a valid email address.", msgError.Text);
		}



		[Theory]
		[InlineData ("Jucemara", "", "22344", "22344")]
		[InlineData ("", "jucemara@email.com", "22344", "22344")]
		[InlineData ("Jucemara", "jucemara", "22344", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "2244", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "22344", "")]
		[InlineData ("", "", "", "")]
		public void DodoInformacaoVaziaDevePermanecerNaHome(
				string nome,
				string email,
				string senha,
				string confSenha)
		{
			//Arrange
			driver.Navigate().GoToUrl("http://localhost:5000");
			var button = driver.FindElement(By.Id("btnRegistro"));
			var imputNome = driver.FindElement(By.Id("Nome"));
			var imputEmail = driver.FindElement(By.Id("Email"));
			var imputPassword = driver.FindElement(By.Id("Password"));
			var imputConfPassword = driver.FindElement(By.Id("ConfirmPassword"));

			//Act
			imputNome.SendKeys(nome);
			imputEmail.SendKeys(email);
			imputPassword.SendKeys(senha);
			imputConfPassword.SendKeys(confSenha);
			button.Click();

			//Assert
			Assert.Contains("section-registro", driver.PageSource);
		}



		[Fact]
		public void DadoHomeAbertaNaoDeveMostrarMsgsDeErro(){
			//Arrage


			//Act
			driver.Navigate().GoToUrl("http://localhost:5000");
			var form = driver.FindElement(By.TagName("form"));
			var spans = form.FindElements(By.TagName("span"));

			//Assert
			foreach (var span in spans)
			{
				Assert.True(string.IsNullOrEmpty(span.Text));
			}
		}
	}
}
