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

		public Guid Create(string nomeConta, string cnpj, decimal receitaAnual, int numFuncionarios, OptionSetValue tipoRelacao, Guid clientePotencialId)
		{
			Entity conta = new Entity(TipoLogico);
			conta["name"] = nomeConta;
			conta["mkt_cnpj"] = cnpj;
			conta["originatingleadid"] = new EntityReference("lead", clientePotencialId);
			conta["numberofemployees"] = numFuncionarios;
			conta["revenue"] = new Money(receitaAnual);
			conta["mkt_tiporelacao"] = tipoRelacao;

			return ServiceClient.Create(conta);
		}

		public bool UpdatePrimaryContact(Guid contactId, Guid contaId)
		{
			Entity conta = new Entity(TipoLogico, contaId);

			try
			{
				conta["primarycontactid"] = new EntityReference("contact", contactId);
				ServiceClient.Update(conta);
				return true;
			} 
			catch (Exception ex)
			{
				Console.WriteLine("Um erro ocorreu no processo de atualizar o contato primário: " + ex.ToString());
				return false;
			}
			
		}
	}
}
