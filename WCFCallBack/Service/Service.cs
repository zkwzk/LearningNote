using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contract;

namespace Service
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class Service : IService
	{
		public int Add(int a, int b)
		{
			int i = 10;
			// simulate the processing progress
			while (i <= 100)
			{
				ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
				callback.Percent(i);
				i = i + 10;
				Thread.Sleep(500);
			}

			return a + b;
		}
	}
}
