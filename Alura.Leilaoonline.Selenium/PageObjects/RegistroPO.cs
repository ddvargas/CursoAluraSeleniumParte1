using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.PageObjects
{
	public class RegistroPO
	{

		private IWebDriver driver;
		private By byInputNome;
		private By byInputEmail;
		private By byInputPass;
		private By byInputConfPass;
		private By byBtnRegistro;
		private By bySpanErroPEmailInvalido;
		private By bySpanErroEmailVazio;
		private By bySpanErroNomeVazio;
		private By bySpanErroPassVazio;
		private By bySpanErroConfPassVazio;

		public string EmailInvalidoMsgErro => driver.FindElement(bySpanErroPEmailInvalido).Text;
		public string EmailVazioMsgErro => driver.FindElement(bySpanErroEmailVazio).Text;
		public string NomeVazioMsgErro => driver.FindElement(bySpanErroNomeVazio).Text;
		public string SenhaVazioMsgErro => driver.FindElement(bySpanErroPassVazio).Text;
		public string ConfSenhaVazioMsgErro => driver.FindElement(bySpanErroConfPassVazio).Text;



		public RegistroPO(IWebDriver _driver)
		{
			this.driver = _driver;
			byInputNome = By.Id("Nome");
			byInputEmail = By.Id("Email");
			byInputPass = By.Id("Password");
			byInputConfPass = By.Id("ConfirmPassword");
			byBtnRegistro = By.Id("btnRegistro");

			bySpanErroNomeVazio = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
			bySpanErroEmailVazio = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
			bySpanErroPassVazio = By.CssSelector("span.msg-erro[data-valmsg-for=Password]");
			bySpanErroConfPassVazio = By.CssSelector("span.msg-erro[data-valmsg-for=ConfirmPassword]");

			bySpanErroPEmailInvalido = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
		}




		public void Visitar(){
			driver.Navigate().GoToUrl("http://localhost:5000");
		}


		public void SubmeterFormulario(){
			driver.FindElement(byBtnRegistro).Click();
		}

		public void PreencherFormulario(string nome, string email, string pass, string confPass)
		{
			driver.FindElement(byInputNome).SendKeys(nome);
			driver.FindElement(byInputEmail).SendKeys(email);
			driver.FindElement(byInputPass).SendKeys(pass);
			driver.FindElement(byInputConfPass).SendKeys(confPass);
		}
	}
}
