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
			var registroPO = new RegistroPO(driver);

			//Act
			registroPO.PreencherFormulario("Leonardo de Capriocórnio", "diCapri@email.com", "1234", "1234");
			registroPO.SubmeterFormulario();

			//Assert
			Assert.Contains("Obrigado", driver.PageSource);
		}





		[Fact]
		public void DodoInformacoesVaziasDeveMostrarErroNaHome()
		{
			//Arrange
			var registroPO = new RegistroPO(driver);
			registroPO.Visitar();


			//Act
			registroPO.SubmeterFormulario();

			//Assert
			Assert.Contains("section-registro", driver.PageSource);
			Assert.Contains("Leilões Online", driver.Title);
		}

		[Theory]
		[InlineData ("", "", "", "")]
		[InlineData (" ", " ", " ", " ")]
		[InlineData ("", "jucemar@email.com", "12345", "12345")]
		[InlineData ("José Jucemar", "", "12345", "12345")]
		[InlineData ("José Jucemar", "jucemar@email.com", "", "12345")]
		[InlineData ("José Jucemar", "jucemar@email.com", "12345", "")]
		public void DadoCampoEmBrancoDeveMostrarMsgDeErro(string nome, string email, string senha, string confSenha)
		{
			//Arrange
			var registroPO = new RegistroPO(driver);
			IWebElement msgError = null;
			registroPO.Visitar();

			//act
			registroPO.PreencherFormulario(nome, email, senha, confSenha);
			registroPO.SubmeterFormulario();


			//Assert
			if (nome == ""){
				Assert.Contains("The Nome field is required.", registroPO.NomeVazioMsgErro);
			}
			if (email == "")
			{
				Assert.Contains("The Endereço de Email field is required.", registroPO.EmailVazioMsgErro);
			}
			if (senha == ""){
				Assert.Contains("The Senha field is required.", registroPO.SenhaVazioMsgErro);
			}
			if (confSenha == ""){
				Assert.Contains("The Confirmação de Senha field is required.", registroPO.ConfSenhaVazioMsgErro);
			}
		}




		[Theory]
		[InlineData ("daniel@")]
		[InlineData ("daniel")]
		public void DadoEmailInvalidoDeveMostrarMsgDeErroApropriada(string email){
			//Arrage
			var registroPO = new RegistroPO(driver);
			registroPO.Visitar();


			//act
			registroPO.PreencherFormulario(nome: "", email: email, pass: "", confPass:"");
			registroPO.SubmeterFormulario();

			//Assert
			Assert.Equal("Please enter a valid email address.", registroPO.EmailInvalidoMsgErro);
		}





		[Theory]
		[InlineData ("Jucemara", "", "22344", "22344")]
		[InlineData ("", "jucemara@email.com", "22344", "22344")]
		[InlineData ("Jucemara", "jucemara", "22344", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "2244", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "", "22344")]
		[InlineData ("Jucemara", "jucemara@email.com", "22344", "")]
		[InlineData ("", "", "", "")]
		public void DodoInformacaoVaziaDevePermanecerNaHome(string nome, string email, string senha, string confSenha)
		{
			//Arrange
			var registroPO = new RegistroPO(driver);
			registroPO.Visitar();


			//Act
			registroPO.PreencherFormulario(nome, email, senha, confSenha);
			registroPO.SubmeterFormulario();

			//Assert
			Assert.Contains("section-registro", driver.PageSource);
		}



		/**
		 Quando acessar a página de formulário de registro, todos os erros devem estar não visíveis.
		 */
		[Fact]
		public void DadoHomeAbertaNaoDeveMostrarMsgsDeErro(){
			//Arrage
			RegistroPO registroPO = new RegistroPO(driver);


			//Act
			registroPO.Visitar();

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
