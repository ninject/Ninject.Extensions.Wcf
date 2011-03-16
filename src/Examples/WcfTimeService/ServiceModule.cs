// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

namespace WcfTimeService
{
    using Ninject.Modules;
    using Ninject.Syntax;

    /// <summary>
    /// The module declaring the bindings of the service.
    /// </summary>
    internal class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IResolutionRoot>().ToConstant(this.Kernel);

            Bind<ITimeService>().To<TimeService>().InSingletonScope();
            Bind<ISystemClock>().To<SystemClock>().InSingletonScope();
        }
    }
}