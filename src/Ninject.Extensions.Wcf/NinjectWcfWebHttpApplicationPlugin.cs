namespace Ninject.Extensions.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using Ninject.Components;
    using Ninject.Web.Common;
    using System.ServiceModel.Web;

    public class NinjectWcfWebHttpApplicationPlugin : NinjectComponent, INinjectHttpApplicationPlugin
    {
        private readonly IKernel kernel;

        public NinjectWcfWebHttpApplicationPlugin(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object RequestScope
        {
            get
            {
                return OperationContext.Current;
            }
        }

        public void Start()
        {
            NinjectWebServiceHostFactory.SetKernel(kernel);
            RegisterCustomBehavior();
        }

        public void Stop()
        {
        }

        /// <summary>
        /// Creates a kernel binding for a <c>ServiceHost</c>. If you wish to
        /// provide your own <c>ServiceHost</c> implementation, override this method
        /// and bind your implementation to the <c>ServiceHost</c> class.
        /// </summary>
        protected virtual void RegisterCustomBehavior()
        {
            if (kernel.GetBindings(typeof(WebServiceHost)).Count() == 0) {
                kernel.Bind<WebServiceHost>().To<NinjectWebServiceHost>().Named("webService");
            }
        }
    }
}
