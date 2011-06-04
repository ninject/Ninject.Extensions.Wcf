//-------------------------------------------------------------------------------
// <copyright file="WcfModule.cs" company="bbv Software Services AG">
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

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using Modules;

    using Ninject.Web.Common;

    using Parameters;
    using System.ServiceModel.Web;

    /// <summary>
    /// A inject module that defines the bindings that are used to create the services for the wcf extension.
    /// </summary>
    public class WcfModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWcfHttpApplicationPlugin>();
            Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWcfWebHttpApplicationPlugin>();

            Bind<NinjectInstanceProvider>().ToSelf();
            Bind<IServiceBehavior>().To<NinjectServiceBehavior>();
            Bind<IDispatchMessageInspector>().To<WcfRequestScopeCleanup>()
                .WithConstructorArgument("releaseScopeAtRequestEnd", ctx => ctx.Kernel.Settings.Get("ReleaseScopeAtRequestEnd", true));

            Bind<Func<Type, IInstanceProvider>>().ToMethod(ctx => serviceType => ctx.Kernel.Get<NinjectInstanceProvider>(new ConstructorArgument("serviceType", serviceType)));
            Bind<Func<Type, Uri[], ServiceHost>>().ToMethod(
                ctx =>
                (serviceType, baseAddresses) =>
                ctx.Kernel.Get<NinjectServiceHost>(new ConstructorArgument("serviceType", serviceType), new ConstructorArgument("baseAddresses", baseAddresses)));

            Bind<Func<Type, Uri[], WebServiceHost>>().ToMethod(
                ctx =>
                (serviceType, baseAddresses) =>
                ctx.Kernel.Get<NinjectWebServiceHost>(new ConstructorArgument("serviceType", serviceType), new ConstructorArgument("baseAddresses", baseAddresses)));
                
        }
    }
}