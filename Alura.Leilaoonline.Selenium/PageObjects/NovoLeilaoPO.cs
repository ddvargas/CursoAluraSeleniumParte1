using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.PageObjects
{
	public class NovoLeilaoPO
	{
		private IWebDriver driver;
		private By byInputTitulo;
		private By byInputDescricao;
		private By byInputCategoria;
		private By byInputValor;
		private By byInputImg;
		private By byInputPregaoInicio;
		private By byInputPregaoFim;
		private By byBtnSalvar;
		

		public NovoLeilaoPO(IWebDriver _driver)
		{
			this.driver = _driver;
			byInputTitulo = By.Id("Titulo");
			byInputDescricao = By.Id("Descricao");
			byInputCategoria = By.Id("Categoria");
			byInputValor = By.Id("ValorInicial");
			byInputImg = By.Id("ArquivoImagem");
			byInputPregaoInicio = By.Id("InicioPregao");
			byInputPregaoFim = By.Id("TerminoPregao");
			byBtnSalvar = By.CssSelector("button[type=submit]");
	}

		public void Visitar(){
			driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
		}

		public void PreencherFormulario(string titulo, string descricao, string categoria, double valor, string arq, DateTime inicio, DateTime fim){
			driver.FindElement(byInputTitulo).SendKeys(titulo);
			driver.FindElement(byInputDescricao).SendKeys(descricao);
			driver.FindElement(byInputCategoria).SendKeys(categoria);
			driver.FindElement(byInputValor).SendKeys(valor.ToString());
			driver.FindElement(byInputImg).SendKeys(arq);
			driver.FindElement(byInputPregaoInicio).SendKeys(inicio.ToString("dd/MM/yyyy"));
			driver.FindElement(byInputPregaoFim).SendKeys(fim.ToString("dd/MM/yyyy"));

		}


		internal void Sumeterformulario()
		{
			driver.FindElement(byBtnSalvar).Click();
		}



		public IEnumerable<string> Categorias{
			get
			{
				var elementoCategorias = new SelectElement(driver.FindElement(byInputCategoria));
				return elementoCategorias.Options
					.Where(o => o.Enabled)
					.Select(o => o.Text);
			}
		}
	}
}
