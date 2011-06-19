//-------------------------------------------------------------------------------
// <copyright file="ServiceLocatorServiceHost.cs" company="Ninject Project Contributors">
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
    using System.ServiceModel;

    /// <summary>
    /// Service locaotr service host
    /// </summary>
    public class ServiceLocatorServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        public ServiceLocatorServiceHost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public ServiceLocatorServiceHost(TypeCode serviceType)
            : base(serviceType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="singletonInstance">The singleton instance.</param>
        public ServiceLocatorServiceHost(object singletonInstance)
            : base(singletonInstance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public ServiceLocatorServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new ServiceLocatorServiceBehavior());
            base.OnOpening();
        }
    }
}