using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Contract
{
	[ServiceContract(CallbackContract = typeof(ICallback))]
	public interface IService
	{
		[OperationContract]
		int Add(int i, int j);
	}
}
