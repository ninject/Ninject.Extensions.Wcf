// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectServiceHost.cs" company="Ninject Project Contributors">
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
    using System.ServiceModel;
    using System.ServiceModel.Description;

    /// <summary>
    /// A service host that uses Ninject to create the service instances.
    /// </summary>
    public class NinjectServiceHost : ServiceHost
    {
        /// <summary>
        /// The service behavior.
        /// </summary>
        private readonly IServiceBehavior serviceBehavior;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, TypeCode serviceType)
            : base(serviceType)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="singletonInstance">The singleton instance.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, object singletonInstance)
            : base(singletonInstance)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(this.serviceBehavior);
            base.OnOpening();
        }
    }
}