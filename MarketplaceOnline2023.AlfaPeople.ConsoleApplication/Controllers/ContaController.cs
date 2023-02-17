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
			Conta = new Conta(serviceClient);
		}

		public Guid Create(string contaNome)
		{
			//Console.WriteLine("Informe o número de funcionários desta conta: ");
			//int numFuncionarios = int.Parse(Console.ReadLine());

			//Console.WriteLine("Informe o valor do tipo de relação desta conta: ");
			//OptionSetValue tipoRelacao = new OptionSetValue(int.Parse(Console.ReadLine()));

			//Console.WriteLine("Informe a receita anual desta conta: ");
			//decimal receitaAnual = decimal.Parse(Console.ReadLine());

			//Console.WriteLine("Informe o id de um cliente potencial desta conta: ");
			//Guid clientePotencialId = new Guid(Console.ReadLine());

			//Guid contaId = Conta.Create(contaNome, receitaAnual, numFuncionarios, tipoRelacao, clientePotencialId);

			Console.WriteLine("\nAguarde enquanto criamos a conta...");
			Guid contaId = Conta.Create(contaNome, 120400.12m, 36, new OptionSetValue(100000000), new Guid("e4a18ae0-4d0e-ea11-a813-000d3a1bbd52"));
			Console.WriteLine($"Conta criada com sucesso: https://org737e10c5.crm2.dynamics.com/main.aspx?appid=74c97688-24ae-ed11-9885-002248365eb3&pagetype=entityrecord&etn=account&id={contaId}" );

			return contaId;
		}

		public void UpdatePrimaryContact(Guid contactId, Guid contaId)
		{
			Console.WriteLine("\nAguarde enquanto atribuímos o contato a sua conta...");

			bool updateContactSucessful = Conta.UpdatePrimaryContact(contactId, contaId);
			if (updateContactSucessful) { Console.WriteLine("Contato atribuído a conta com sucesso!"); }
		}
	}
}
