using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceOnline2023.AlfaPeople.ConsoleApplication
{
	public class Singleton
	{
		public static CrmServiceClient GetService()
		{
			string url = "org737e10c5";
			string clientId = "ab841361-ebf1-443b-b7bd-3e703d9e460f";
			string clientSecret = "teo8Q~zCgu_S-FSjGLUdHItUU9Mx~ABF3~-BIb8b";

			CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url=https://{url}.crm2.dynamics.com/;AppId={clientId};ClientSecret={clientSecret};");
			if (!serviceClient.CurrentAccessToken.Equals(null)) { Console.WriteLine("Conexão bem sucedida"); }
			else { Console.WriteLine("Ocorreu um erro"); }

			return serviceClient;
		}
	}
}
