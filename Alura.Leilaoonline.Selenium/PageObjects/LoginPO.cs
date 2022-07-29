using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.PageObjects
{
	public class LoginPO
	{
		IWebDriver driver;
		private By byInputLogin;
		private By byInputPass;
		private By byBtnLogin;
		private By byMsgErroLoginVazio;
		private By byMsgErroSenhaVazia;

		public string MsgErroLoginVazio => driver.FindElement(byMsgErroLoginVazio).Text;
		public string MsgErroSenhaVazia => driver.FindElement(byMsgErroSenhaVazia).Text;

		public LoginPO(IWebDriver driver)
		{
			this.driver = driver;
			byInputLogin = By.Id("Login");
			byInputPass = By.Id("Password");
			byBtnLogin = By.Id("btnLogin");
			byMsgErroLoginVazio = By.CssSelector("span.msg-erro[data-valmsg-for=Login]");
			byMsgErroSenhaVazia = By.CssSelector("span.msg-erro[data-valmsg-for=Password]");
		}


		public void Visitar(){
			driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
		}

		public void PreencherFormulario(string user, string password){
			driver.FindElement(byInputLogin).SendKeys(user);
			driver.FindElement(byInputPass).SendKeys(password);
		}

		public void SumeterFormulario(){
			driver.FindElement(byBtnLogin).Click();
		}
	}
}
