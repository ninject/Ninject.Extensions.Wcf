namespace Ninject.Extensions.Wcf
{
    using System.ServiceModel;

    using Ninject.Activation;
    using Ninject.Activation.Strategies;

    public class WcfDisposableStrategy : DisposableStrategy
    {
        public override void Deactivate(IContext context, InstanceReference reference)
        {
            reference.IfInstanceIs<ICommunicationObject>(x =>
                {
                    if (x.State == CommunicationState.Faulted)
                    {
                        x.Abort();
                    }
                    else
                    {
                        try
                        {
                            x.Close();
                        }
                        catch
                        {
                            x.Abort();
                        }
                    }
                });

            base.Deactivate(context, reference);
        }
    }
}