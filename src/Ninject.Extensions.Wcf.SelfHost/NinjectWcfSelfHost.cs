// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectWcfSelfHost.cs" company="Ninject Project Contributors">
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

namespace Ninject.Extensions.Wcf.SelfHost
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Ninject.Web.Common.SelfHost;

    /// <summary>
    /// Web API self host for ninject web common
    /// </summary>
    public class NinjectWcfSelfHost : INinjectSelfHost, IDisposable
    {
        private readonly IEnumerable<NinjectWcfConfiguration> wcfConfigurations;
        private readonly List<ServiceHost> hosts = new List<ServiceHost>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWcfSelfHost"/> class.
        /// </summary>
        /// <param name="wcfConfigurations">The WCF configurations.</param>
        public NinjectWcfSelfHost(IEnumerable<NinjectWcfConfiguration> wcfConfigurations)
        {
            this.wcfConfigurations = wcfConfigurations;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            foreach (var ninjectWcfConfiguration in this.wcfConfigurations)
            {
                var factory = (INinjectSelfHostFactory)Activator.CreateInstance(ninjectWcfConfiguration.ServiceHostFactoryType);
                var host = factory.CreateServiceHost(ninjectWcfConfiguration.ServiceType, ninjectWcfConfiguration.BaseAddresses);

                ninjectWcfConfiguration.ConfigureHost(host);
                host.Open();

                this.hosts.Add(host);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposable"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposable)
        {
            foreach (var serviceHost in this.hosts)
            {
                serviceHost.Close();
            }
        }
    }
}