using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models
{
	public class Contato
	{
		public CrmServiceClient ServiceClient { get; set; }
		public string TipoLogico { get => "contact"; }

		public Contato(CrmServiceClient serviceClient)
		{
			this.ServiceClient = serviceClient;
		}
	}
}
