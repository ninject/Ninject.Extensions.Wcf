// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

namespace WindowsTimeService
{
    using System;
    using Ninject;
    using WcfTimeService;

    /// <summary>
    /// The application main.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var kernel = new StandardKernel(new ServiceModule(), new WindowsTimeServiceModule());           

#if SERVICE
            var ServicesToRun = new System.ServiceProcess.ServiceBase[]
                                {
                                    kernel.Get<WindowsTimeService>()
                                };
            System.ServiceProcess.ServiceBase.Run( ServicesToRun );
#else
            var service = kernel.Get<WindowsTimeService>();
            try
            {
                service.Start(new string[] { });

                do
                {
                } 
                while (Console.ReadLine() != "q");
            }
            finally
            {
                service.Stop();
            }
#endif
        }
    }
}