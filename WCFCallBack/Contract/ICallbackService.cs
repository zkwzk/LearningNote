﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Contract
{
	[ServiceContract]
	public interface ICallback
	{
		[OperationContract]
		void Percent(int x);
	}
}
