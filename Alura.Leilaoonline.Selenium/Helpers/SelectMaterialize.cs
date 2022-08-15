using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.Helpers
{
	public class SelectMaterialize
	{
		private IWebDriver driver;
		private IWebElement selectWrapper;
		private IEnumerable<IWebElement> opcoes;

		public SelectMaterialize(IWebDriver driver, By locatorSelectWhapper)
		{
			this.driver = driver;
			selectWrapper = driver.FindElement(locatorSelectWhapper);
			opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
		}

		private void OpenWrapper(){
			selectWrapper.Click();
		}


		private void LooseFocus(){
			selectWrapper.FindElement(By.TagName("li"))
				.SendKeys(Keys.Tab);
		}


		public IEnumerable<IWebElement> Options => opcoes;
		public void DeselectAll(){
			OpenWrapper();
			opcoes.ToList().ForEach(o => { 
				o.Click(); 
			});
			LooseFocus();
		}

		public void SelectByText(string option) {
			OpenWrapper();
			opcoes.Where(o => o.Text.Contains(option))
				.ToList()
				.ForEach(o => { 
					o.Click(); 
				});
			LooseFocus();
		}
	}
}
