using Ninject.Modules;

namespace WcfServiceLibrary
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<ServiceLayer.TimeService>().ToSelf();
			this.Bind<Contracts.ISystemClock>().To<BusinessLayer.SystemClock>();

			this.Bind<ILog>().ToMethod(ctx => LogManager.GetLogger(ctx.Request.Target.Member.DeclaringType));
		}
	}
}