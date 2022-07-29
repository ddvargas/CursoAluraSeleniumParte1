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
	public class AoEfetuarLogin
	{
		private IWebDriver driver;

		public AoEfetuarLogin(TestFixture fixture)
		{
			this.driver = fixture.Driver;
		}



		[Fact]
		public void Dado_Credenciais_Validas_Ir_Pra_Pagina_De_Usuario()
		{
			//fulano@exemple.org
			//123
			//Arrange
			var loginPO = new LoginPO(driver);
			loginPO.Visitar();

			//act
			loginPO.PreencherFormulario("fulano@example.org", "123");
			loginPO.SumeterFormulario();

			//Assert
			Assert.Contains("Dashboard", driver.PageSource);

		}




		[Fact]
		public void Dado_Credenciais_Invalidas_Permanecer_Na_Pagina_De_Login()
		{
			var loginPO = new LoginPO(driver);
			loginPO.Visitar();

			//act
			loginPO.PreencherFormulario("osvaldo@example.org", "123");
			loginPO.SumeterFormulario();

			//Assert
			Assert.Contains("Ainda não possui cadastro? ", driver.PageSource);
		}





		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("Giuliana Paes", " ")]
		[InlineData("GiulianaPaes", "")]
		[InlineData("", "12345")]
		[InlineData(" ", "12345")]
		public void Dado_Credenciais_Invalidas_Permanecer_Na_Pagina_De_Login_Mostrar_Erros(string login, string senha)
		{
			var loginPO = new LoginPO(driver);
			loginPO.Visitar();

			//act
			loginPO.PreencherFormulario(login, senha);
			loginPO.SumeterFormulario();

			//Assert
			if (login == "" || login == " ")
			{
				Assert.Contains("The Usuário field is required.", loginPO.MsgErroLoginVazio);
			}
			if (senha == "" || senha == " ")
			{
				Assert.Contains("The Senha field is required.", loginPO.MsgErroSenhaVazia);
			}
		}
	}
}
