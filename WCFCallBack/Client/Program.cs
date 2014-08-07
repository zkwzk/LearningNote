using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ICallback callback = new Callback();
			InstanceContext context = new InstanceContext(callback);
			WSDualHttpBinding binding = new WSDualHttpBinding();
			//the Guid ensure the client call back address is unique if there are more than one client using the same base callback address
			binding.ClientBaseAddress = new Uri(string.Format("{0}{1}", "http://localhost:7799/Callback/", Guid.NewGuid().ToString()));
			using (DuplexChannelFactory<IService> channel = new DuplexChannelFactory<IService>(context, binding, new EndpointAddress("http://localhost:9888/Service"))) 
			{
				IService proxy = channel.CreateChannel();
				Console.WriteLine("output is :" + proxy.Add(9, 10));
				Console.Read();
			}
		}
	}
}
