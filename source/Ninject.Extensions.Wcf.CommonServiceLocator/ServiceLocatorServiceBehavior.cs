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

using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

#endregion

namespace Ninject.Extensions.Wcf
{
    public class ServiceLocatorServiceBehavior : IServiceBehavior
    {
        #region Implementation of IServiceBehavior

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
        public void Validate( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase )
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
        public void AddBindingParameters( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
                                          Collection<ServiceEndpoint> endpoints,
                                          BindingParameterCollection bindingParameters )
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
        public void ApplyDispatchBehavior( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase )
        {
            foreach ( ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers )
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;

                if ( channelDispatcher == null )
                {
                    continue;
                }

                foreach ( EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints )
                {
                    endpointDispatcher.DispatchRuntime.InstanceProvider =
                        new ServiceLocatorInstanceProvider( serviceDescription.ServiceType );
                }
            }
        }

        #endregion
    }
}