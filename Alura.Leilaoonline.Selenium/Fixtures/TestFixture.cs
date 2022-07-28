using Alura.Leilaoonline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



/**
 * Classe que representa o contexto do navegador que está sendo compartilhado entre os testes
 * Ela é quem cria os drivers e fecha-os.
 */

namespace Alura.Leilaoonline.Selenium.Fixtures
{
	public class TestFixture : IDisposable
	{

		public IWebDriver Driver { get; set; }



		//Setup
		public TestFixture()
		{
			Driver = new FirefoxDriver(TestHelper.PastaDoExecutavel);
		}

		


		//TearDown
		public void Dispose(){
			Driver.Quit();
		}

	}
}
