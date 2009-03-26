#region License

//
// Copyright © 2009 Ian Davis <ian.f.davis@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
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
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new WindowsTimeService() 
			};
            ServiceBase.Run(ServicesToRun);
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