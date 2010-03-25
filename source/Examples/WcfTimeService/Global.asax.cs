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

using Ninject;
using Ninject.Extensions.Wcf;

#endregion

namespace WcfTimeService
{
    public class Global : NinjectWcfApplication
    {
        #region Overrides of NinjectWcfApplication

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel( new ServiceModule() );
            return kernel;
        }

        #endregion
    }
}