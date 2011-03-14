namespace WcfTimeService
{
    using System;
    using System.ServiceModel;
    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Syntax;

    public class TimeServiceHostFactory : NinjectServiceHostFactory
    {
        private static IResolutionRoot resolutionRoot;

        protected override Func<Type, Uri[], ServiceHost> ServiceHostFactory
        {
            get { return resolutionRoot.Get<Func<Type, Uri[], ServiceHost>>(); }
        }

        public static void SetResolutionRoot(IResolutionRoot root)
        {
            resolutionRoot = root;
        }
    }
}