using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Leilaoonline.Selenium.Fixtures
{
	
	/**
	 * Classe que representa uma coleção de classes de testes que iram usar os mesmos recursos (navegador)
	 */

	[CollectionDefinition("Firefox Driver")]
	public class CollectionFixture : ICollectionFixture<TestFixture>
	{
			
		
	}
}
