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
			Regex cpfRegex = new Regex("(\\d{3}.){2}\\d{3}-\\d{2}");

			//Console.WriteLine("Informe o primeiro nome para o novo contato:");
			//string nome = Console.ReadLine();

			//Console.WriteLine("Informe o sobrenome do novo contato:");
			//string sobrenome = Console.ReadLine();

			//Console.WriteLine("Informe um CPF para o novo contato (000.000.000-00):");
			//string cpf = Console.ReadLine();

			//while (cpfRegex.Matches(cpf).Count < 1)
			//{
			//	Console.WriteLine("Formato/CPF inválido. Informe um CPF para o novo contato (000.000.000-00):");
			//	cpf = Console.ReadLine();
			//}

			//Console.WriteLine("Informe um email para o novo contato:");
			//string email = Console.ReadLine();

			//Console.WriteLine("Informe um número de celular para o novo contato:");
			//string celular = Console.ReadLine();

			//Contato.Create(contaId, email, nome, sobrenome celular);

			Console.WriteLine("\nAguarde enquanto criamos o contato...");
			Guid contatoId = Contato.Create(contaId, "000.000.000-00", "ruanvictor.qa@gmail.com", "Ruan Victor", "Anastacio", "11 99194-1346");
			Console.WriteLine($"Contato criado com sucesso: https://org737e10c5.crm2.dynamics.com/main.aspx?appid=74c97688-24ae-ed11-9885-002248365eb3&forceUCI=1&pagetype=entityrecord&etn=contact&id={contatoId}");

			return contatoId;
		}
	}
}
