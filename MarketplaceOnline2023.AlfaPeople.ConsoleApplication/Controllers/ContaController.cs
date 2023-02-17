using MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Controllers
{
	public class ContaController
	{
		public CrmServiceClient ServiceClient { get; set; }
		public Conta Conta { get; set; }
		public Dictionary<string, int> TipoRelacao { get; } = new Dictionary<string, int>()
		{
			{ "cliente", 100000000 },
			{ "fornecedor", 100000001 },
			{ "revenda", 100000002 }
		};

		public ContaController(CrmServiceClient serviceClient)
		{
			this.ServiceClient = serviceClient;
			Conta = new Conta(serviceClient);
		}

		public Guid Create(string contaNome)
		{
			string cnpj = AskForCnpj();

			Console.WriteLine("Informe o número de funcionários desta conta: ");
			int numFuncionarios = int.Parse(Console.ReadLine());

			OptionSetValue tipoRelacao = GetTipoRelacao();

			Console.WriteLine("Informe a receita anual desta conta: ");
			decimal receitaAnual = decimal.Parse(Console.ReadLine());

			Console.WriteLine("Informe o id de um cliente potencial desta conta: ");
			Guid clientePotencialId = new Guid(Console.ReadLine());

			Console.WriteLine("\nAguarde enquanto criamos a conta...");
			Guid contaId = Conta.Create(contaNome, cnpj, receitaAnual, numFuncionarios, tipoRelacao, clientePotencialId);
			Console.WriteLine($"Conta criada com sucesso: https://org737e10c5.crm2.dynamics.com/main.aspx?appid=74c97688-24ae-ed11-9885-002248365eb3&pagetype=entityrecord&etn=account&id={contaId}" );

			return contaId;
		}

		public void UpdatePrimaryContact(Guid contactId, Guid contaId)
		{
			Console.WriteLine("\nAguarde enquanto atribuímos o contato a sua conta...");

			bool updateContactSucessful = Conta.UpdatePrimaryContact(contactId, contaId);
			if (updateContactSucessful) { Console.WriteLine("Contato atribuído a conta com sucesso!"); }
		}

		public string AskForCnpj()
		{
			Regex cnpjRegex = new Regex("\\d{2}.\\d{3}.\\d{3}\\/\\d{4}-\\d{2}");

			Console.WriteLine("Informe um CNPJ para sua nova conta (00.000.000/0000-00):");
			string cnpj = Console.ReadLine();

			while (cnpjRegex.Matches(cnpj).Count < 1 || Conta.LookForEqualCnpj(cnpj))
			{
				Console.WriteLine("Este CNPJ já foi cadastrado/Formato inválido. Informe um CNPJ para o novo contato (00.000.000/0000-00):");
				cnpj = Console.ReadLine();
			}

			return cnpj;
		}

		public OptionSetValue GetTipoRelacao()
		{
			Console.WriteLine("Informe o valor do tipo de relação desta conta (Cliente, Fornecedor, Revenda):");
			string tipoRelacao = Console.ReadLine().ToLower();

			while (!TipoRelacao.Keys.Contains(tipoRelacao))
			{
				Console.WriteLine("Opção inválida. Informe o valor do tipo de relação desta conta (Cliente, Fornecedor, Revenda):");
				tipoRelacao = Console.ReadLine().ToLower();
			}

			return new OptionSetValue(this.TipoRelacao[tipoRelacao]);
		}
	}
}
