//-------------------------------------------------------------------------------
// <copyright file="WindowsTimeServiceModule.cs" company="bbv Software Services AG">
//   Copyright (c) 2011 bbv Software Services AG
//   Author: Daniel Marbach
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace WindowsTimeService
{
    using System.ServiceModel;
    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Modules;
    using Ninject.Parameters;
    using WcfTimeService;

    /// <summary>
    /// The module of the service.
    /// </summary>
    public class WindowsTimeServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<WindowsTimeService>().ToSelf();

            this.Bind<ServiceHost>().ToMethod(ctx => ctx.Kernel.Get<NinjectServiceHost>(new ConstructorArgument("singletonInstance", c => c.Kernel.Get<ITimeService>())))
                .WhenInjectedInto<WindowsTimeService>();
        }
    }
}