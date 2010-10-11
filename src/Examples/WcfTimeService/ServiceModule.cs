#region License

// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using Ninject.Modules;
using WindowsTimeService;

#endregion

namespace WcfTimeService
{
    internal class ServiceModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind<ITimeService>().To<TimeService>().InSingletonScope();
            Bind<ISystemClock>().To<SystemClock>().InSingletonScope();
        }

        #endregion
    }
}