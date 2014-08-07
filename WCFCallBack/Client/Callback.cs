using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Client
{
	public class Callback : ICallback
	{
		public void Percent(int x)
		{
			Console.WriteLine(string.Format("Percent: {0}\t", x));
		}
	}
}
