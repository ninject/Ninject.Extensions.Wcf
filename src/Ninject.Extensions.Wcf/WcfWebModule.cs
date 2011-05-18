namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using Modules;
    using Ninject.Web.Common;
    using Parameters;
    using System.ServiceModel.Web;
    public class WcfWebModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWcfWebHttpApplicaitonPlugin>();

            this.Bind<NinjectWebInstanceProvider>().ToSelf();
            this.Bind<Func<Type, Uri[], WebServiceHost>>().ToMethod(
                ctx =>
                (serviceType, baseAddresses) =>
                ctx.Kernel.Get<NinjectWebServiceHost>(new ConstructorArgument("serviceType", serviceType), new ConstructorArgument("baseAddresses", baseAddresses)));
        }
    }
}
