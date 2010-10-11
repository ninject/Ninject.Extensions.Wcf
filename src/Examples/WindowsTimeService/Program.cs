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

using System;
using Ninject;
using Ninject.Extensions.Wcf;
using WcfTimeService;

#endregion

namespace WindowsTimeService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            KernelContainer.Kernel = new StandardKernel( new ServiceModule() );

#if SERVICE
            var ServicesToRun = new System.ServiceProcess.ServiceBase[]
                                {
                                    new WindowsTimeService()
                                };
            System.ServiceProcess.ServiceBase.Run( ServicesToRun );
#else
            var service = new WindowsTimeService();
            try
            {
                service.Start( new string[] {} );

                do
                {
                } while ( Console.ReadLine() != "q" );
            }
            finally
            {
                service.Stop();
            }
#endif
        }
    }
}