using Microsoft.Xrm.Sdk;
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

		public Guid Create(Guid contaId, string cpf, string email, string nome, string sobrenome, string celular)
		{

			Entity contato = new Entity(TipoLogico);
			contato["accountid"] = contaId;
			contato["mkt_cpf"] = cpf;
			contato["emailaddress1"] = email;
			contato["firstname"] = nome;
			contato["lastname"] = sobrenome;
			contato["mobilephone"] = celular;

			return ServiceClient.Create(contato);
		}
	}
}
