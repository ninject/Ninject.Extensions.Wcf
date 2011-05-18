namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using Ninject.Parameters;
    using System.ServiceModel.Web;
    public class NinjectWebServiceHostFactory : WebServiceHostFactory
    {
        private static IKernel kernelInstance;

        public static void SetKernel(IKernel kernel)
        {
            kernelInstance = kernel;
        }
        
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceTypeParameter = new ConstructorArgument("serviceType", serviceType);
            var baseAddressesParameter = new ConstructorArgument("baseAddresses", baseAddresses);
            return kernelInstance.Get<WebServiceHost>("webService", serviceTypeParameter, baseAddressesParameter);
        }

    }
}
