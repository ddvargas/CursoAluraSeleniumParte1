using Alura.Leilaoonline.Selenium.Fixtures;
using Alura.Leilaoonline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.PageObjects
{
	public class DashboardInteressadaPO
	{
		private IWebDriver driver;
		private By byLogoutLink;
		private By byPerfilLink;
		private By bySelectCategorias;
		private By byInputTermoPesquisa;
		private By byInputAndamento;
		private By byBotaoPesquisar;



		public DashboardInteressadaPO(IWebDriver _driver)
		{
			driver = _driver;
			byLogoutLink = By.Id("logout");
			byPerfilLink = By.Id("meu-perfil");
			bySelectCategorias = By.ClassName("select-wrapper");
			byInputAndamento = By.Id("termo");
			byInputTermoPesquisa = By.Name("andamento");
			byBotaoPesquisar = By.CssSelector("form>button.btn");

		}

		public void EfetuarLogout(){
			var linkMeuPerfil = driver.FindElement(byPerfilLink);
			var linkLogout = driver.FindElement(byLogoutLink);

			IAction acaoLogout = new Actions(driver)
				//move para o elemento meu perfil
				.MoveToElement(linkMeuPerfil)
				//move para o link do logout
				.MoveToElement(linkLogout)
				//clicar sobre o elemento de logout
				.Click()
				//contruir a ação
				.Build();

			acaoLogout.Perform();
		}


		public void PesquisarLeiloes(
			List<string> categorias,
			string termo,
			bool emAndamento){
			var select = new SelectMaterialize(driver, bySelectCategorias);

			//desmarcar todas as opções do selector
			select.DeselectAll();

			//testar se as categorias recebidas por parâmetro existem
			categorias.ForEach(categ =>
			{
				select.SelectByText(categ);
			});


			driver.FindElement(byInputTermoPesquisa).SendKeys(termo);

			if(emAndamento){
				driver.FindElement(byInputAndamento).Click();
			}

			driver.FindElement(byBotaoPesquisar).Click();

		}
	}
}
