using System.Reflection;


namespace Alura.Leilaoonline.Selenium.Helpers
{
	internal class TestHelper
	{
		public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	}
}
