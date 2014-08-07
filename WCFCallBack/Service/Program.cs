using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Service
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ServiceHost service = new ServiceHost(typeof(Service)))
			{
				service.Opened += (a, b) =>
				{
					Console.WriteLine("Service Started");
				};
				service.Open();
				Console.Read();
			}
		}
	}
}
