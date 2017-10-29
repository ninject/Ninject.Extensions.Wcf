// -------------------------------------------------------------------------------------------------
// <copyright file="WcfModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    using Ninject.Activation.Strategies;
    using Ninject.Web.Common;
    using Parameters;

    /// <summary>
    /// A inject module that defines the bindings that are used to create the services for the wcf extension.
    /// </summary>
    public class WcfModule : GlobalKernelRegistrationModule<WcfRequestScopeCleanup>
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            base.Load();
            this.Kernel.Components.Remove<IActivationStrategy, DisposableStrategy>();
            this.Kernel.Components.Add<IActivationStrategy, WcfDisposableStrategy>();
            this.Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWcfHttpApplicationPlugin>();

            this.Bind<NinjectInstanceProvider>().ToSelf();
            this.Bind<IServiceBehavior>().To<NinjectServiceBehavior>();
            this.Bind<IDispatchMessageInspector>().To<WcfRequestScopeCleanup>()
                .WithConstructorArgument("releaseScopeAtRequestEnd", ctx => ctx.Kernel.Settings.Get("ReleaseScopeAtRequestEnd", true));

            this.Bind<Func<Type, IInstanceProvider>>()
                .ToMethod(ctx => serviceType => ctx.Kernel.Get<NinjectInstanceProvider>(new ConstructorArgument("serviceType", serviceType)));
        }
    }
}