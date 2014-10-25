//-------------------------------------------------------------------------------
// <copyright file="NinjectServiceBehavior.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Ian Davis (ian@innovatian.com)
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

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// Service behavior implementation for Ninject.
    /// </summary>
    public class NinjectServiceBehavior : IServiceBehavior
    {
        /// <summary>
        /// Factroy method to create instance providers
        /// </summary>
        private readonly Func<Type, IInstanceProvider> instanceProviderFactory;

        /// <summary>
        /// The <see cref="IDispatchMessageInspector"/> that is attached to each end point
        /// dispatcher to cleanup the request scope objects in the ninject cache after each
        /// operation. 
        /// </summary>
        private readonly IDispatchMessageInspector requestScopeCleanUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceBehavior"/> class.
        /// </summary>
        /// <param name="instanceProviderFactory">The instance provider factory.</param>
        /// <param name="requestScopeCleanUp">The <see cref="IDispatchMessageInspector"/> 
        /// that is attached to each end point dispatcher to cleanup the request scope 
        /// objects in the ninject cache after each operation.</param>
        public NinjectServiceBehavior(Func<Type, IInstanceProvider> instanceProviderFactory, IDispatchMessageInspector requestScopeCleanUp)
        {
            this.instanceProviderFactory = instanceProviderFactory;
            this.requestScopeCleanUp = requestScopeCleanUp;
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service
        /// description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description.
        /// </param>
        /// <param name="serviceHostBase">
        /// The service host that is currently being constructed.
        /// </param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to
        /// support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description of the service.
        /// </param>
        /// <param name="serviceHostBase">
        /// The host of the service.
        /// </param>
        /// <param name="endpoints">
        /// The service endpoints.
        /// </param>
        /// <param name="bindingParameters">
        /// Custom objects to which binding elements have access.
        /// </param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change run-time property values or insert
        /// custom extension objects such as error handlers, message or
        /// parameter interceptors, security extensions, and other custom
        /// extension objects.
        /// </summary>
        /// <param name="serviceDescription">
        /// The service description.
        /// </param>
        /// <param name="serviceHostBase">
        /// The host that is currently being built.
        /// </param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var endpointDispatchers =
                serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>()
                    .SelectMany(channelDispatcher => channelDispatcher.Endpoints)

#if !NET_35
                    .Where(endpointDispatcher => !endpointDispatcher.IsSystemEndpoint);
#else
                    .Where(endpointDispatcher => endpointDispatcher.ContractName != "IMetadataExchange" &&
                                                 endpointDispatcher.ContractNamespace != "http://schemas.microsoft.com/2006/04/mex");
#endif

            foreach (EndpointDispatcher endpointDispatcher in endpointDispatchers)
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider =
                    this.instanceProviderFactory(serviceDescription.ServiceType);
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this.requestScopeCleanUp);
            }
        }
    }
}