using MarketplaceOnline2023.AlfaPeople.ConsoleApplication.Controllers;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CrmServiceClient serviceClient = Singleton.GetService();
			ContaController contaController = new ContaController(serviceClient);

			Console.WriteLine("\nPor favor, informe o nome da conta: ");
			string contaNome = Console.ReadLine();

			Guid contaId = contaController.Create(contaNome);

			bool criarContatoResposta = AskToAddContact();
			if (criarContatoResposta)
			{
				AddAndLinkContact(serviceClient, contaController, contaId);
			}

			Console.WriteLine("\nPrograma Finalizado. Aperte qualquer tecla para fechar o console.");
			Console.ReadKey();
		}

		private static void AddAndLinkContact(CrmServiceClient serviceClient, ContaController contaController, Guid contaId)
		{
			ContatoController contatoController = new ContatoController(serviceClient);
			Guid contatoId = contatoController.Create(contaId);

			contaController.UpdatePrimaryContact(contatoId, contaId);
		}

		private static bool AskToAddContact()
		{
			Console.WriteLine("\nVocê deseja criar um contato para essa conta? (S/N)?");
			string criarContatoResposta = Console.ReadLine().ToUpper();

			while (criarContatoResposta != "S" && criarContatoResposta != "N")
			{
				Console.WriteLine("Resposta inválida. Você deseja criar um contato para essa conta? (S/N)?");
				criarContatoResposta = Console.ReadLine().ToUpper();
			}

			return criarContatoResposta == "S";
		}
	}
}
