using MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Models;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

		public Guid Create(Guid contaId)
		{
			Console.WriteLine("\nInforme o primeiro nome para o novo contato:");
			string nome = Console.ReadLine();

			Console.WriteLine("Informe o sobrenome do novo contato:");
			string sobrenome = Console.ReadLine();

			string cpf = AskForCpf();

			Console.WriteLine("Informe um email para o novo contato:");
			string email = Console.ReadLine();

			Console.WriteLine("Informe um número de celular para o novo contato:");
			string celular = Console.ReadLine();

			Console.WriteLine("\nAguarde enquanto criamos o contato...");
			Guid contatoId = Contato.Create(contaId, cpf, email, nome, sobrenome, celular);
			Console.WriteLine($"Contato criado com sucesso: https://org737e10c5.crm2.dynamics.com/main.aspx?appid=74c97688-24ae-ed11-9885-002248365eb3&forceUCI=1&pagetype=entityrecord&etn=contact&id={contatoId}");

			return contatoId;
		}

		public string AskForCpf()
		{
			Regex cpfRegex = new Regex("(\\d{3}.){2}\\d{3}-\\d{2}");

			Console.WriteLine("Informe um CPF para o novo contato (000.000.000-00):");
			string cpf = Console.ReadLine();

			while (cpfRegex.Matches(cpf).Count < 1 || Contato.LookForEqualCpf(cpf))
			{
				Console.WriteLine("Este CPF já foi cadastrado/Formato inválido. Informe um CPF para o novo contato (000.000.000-00):");
				cpf = Console.ReadLine();
			}

			return cpf;
		}
	}
}
