//-------------------------------------------------------------------------------
// <copyright file="NinjectWcfConfiguration.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2013 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
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
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Wcf.SelfHost
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Configuration for a self hosted WCF Service.
    /// </summary>
    public class NinjectWcfConfiguration
    {
        private NinjectWcfConfiguration(Type serviceType, Type serviceHostFactoryType, Action<ServiceHost> configureHost)
        {
            this.ServiceType = serviceType;
            this.ServiceHostFactoryType = serviceHostFactoryType;
            this.ConfigureHost = configureHost;
        }

        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// Gets the type of the service host factory.
        /// </summary>
        public Type ServiceHostFactoryType { get; private set; }

        /// <summary>
        /// Gets the host configuration callback.
        /// </summary>
        public Action<ServiceHost> ConfigureHost { get; private set; }

        /// <summary>
        /// Gets the base addresses.
        /// </summary>
        public Uri[] BaseAddresses { get; private set; }

        /// <summary>
        /// Creates a self host wcf configuration instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TServiceHostFactory">The type of the service host factory.</typeparam>
        /// <param name="configureHost">The host configuration callback.</param>
        /// <returns>The newly created NinjectWcfConfiguration instance.</returns>
        public static NinjectWcfConfiguration Create<TService, TServiceHostFactory>(Action<ServiceHost> configureHost)
            where TServiceHostFactory : INinjectSelfHostFactory
        {
            return Create<TService, TServiceHostFactory>(configureHost, new Uri[0]);
        }

        /// <summary>
        /// Creates a self host wcf configuration instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TServiceHostFactory">The type of the service host factory.</typeparam>
        /// <param name="configureHost">The host configuration callback.</param>
        /// <param name="baseAddresses">The base addresses of the wcf service.</param>
        /// <returns>The newly created NinjectWcfConfiguration instance.</returns>
        public static NinjectWcfConfiguration Create<TService, TServiceHostFactory>(Action<ServiceHost> configureHost, Uri[] baseAddresses)
            where TServiceHostFactory : INinjectSelfHostFactory
        {
            return new NinjectWcfConfiguration(typeof(TService), typeof(TServiceHostFactory), configureHost) { BaseAddresses = baseAddresses };
        }
    }
}