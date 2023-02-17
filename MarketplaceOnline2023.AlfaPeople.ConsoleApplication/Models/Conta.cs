using Microsoft.Rest;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models
{
	public class Conta
	{
		public CrmServiceClient ServiceClient { get; set; }
		public string TipoLogico { get => "account"; }

		public Conta(CrmServiceClient serviceClient)
		{
			this.ServiceClient = serviceClient;
		}

		public Guid Create(string nomeConta, decimal receitaAnual, int numFuncionarios, OptionSetValue tipoRelacao, Guid clientePotencialId)
		{
			Entity conta = new Entity(TipoLogico);
			conta["name"] = nomeConta;
			conta["originatingleadid"] = new EntityReference("lead", clientePotencialId);
			conta["numberofemployees"] = numFuncionarios;
			conta["revenue"] = new Money(receitaAnual);
			conta["mkt_tiporelacao"] = tipoRelacao;

			return ServiceClient.Create(conta);
		}
	}
}
