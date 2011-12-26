using System;
using Ninject.Extensions.Wcf;
using Ninject;
using System.ServiceModel;

namespace WcfServiceLibrary
{
	class NinjectFileLessServiceHostFactory : NinjectServiceHostFactory
	{
		public NinjectFileLessServiceHostFactory()
		{
			StandardKernel kernel = new StandardKernel(new ServiceModule());
			kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
			SetKernel(kernel);
		}
	}
}
