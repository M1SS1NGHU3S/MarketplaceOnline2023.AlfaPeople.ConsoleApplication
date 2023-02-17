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
			Console.ReadKey();
		}
	}
}
