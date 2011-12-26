using System;
using System.ServiceModel;

namespace WcfServiceLibrary.Contracts
{
	[ServiceContract(Namespace = "http://examples.ninject.org/2011/12")]
	public interface ITimeService
	{
		[OperationContract]
		DateTime WhatTimeIsIt();
	}
}
