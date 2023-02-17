using MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Controllers
{
	public class ContatoController
	{
		public CrmServiceClient ServiceClient { get; set; }
		public Contato Contato { get; set; }

		public ContatoController(CrmServiceClient serviceClient)
		{
			this.ServiceClient = serviceClient;
			Contato = new Contato(this.ServiceClient);
		}
	}
}
