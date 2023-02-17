using MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Controllers
{
	public class ContaController
	{
		public CrmServiceClient ServiceClient { get; set; }
		public Conta Conta { get; set; }

		public ContaController(CrmServiceClient serviceClient)
		{
			this.ServiceClient = serviceClient;
			Conta = new Conta(serviceClient, "account");
		}

		public void Create()
		{
			Guid contaId = Conta.Create("Cinema", 150040.14m, 30, new OptionSetValue(100000000), new Guid("63a38ae0-4d0e-ea11-a813-000d3a1bbd52"));
			Console.WriteLine($"Conta criada com sucesso: https://org737e10c5.crm2.dynamics.com/main.aspx?appid=74c97688-24ae-ed11-9885-002248365eb3&pagetype=entityrecord&etn=account&id={contaId}" );
		}
	}
}
