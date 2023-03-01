// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectAbstractWebServiceHost.cs" company="Ninject Project Contributors">
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
    /// Abstract base class for WebServiceHost that initializes based on the
    /// ServiceBehavior attribute as singleton or multi instance web service
    /// </summary>
    /// <typeparam name="T">The type of the web service</typeparam>
    public abstract class NinjectAbstractWebServiceHost<T> : NinjectWebServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectAbstractWebServiceHost{T}"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="baseBaseAddresses">The base addresses.</param>
        protected NinjectAbstractWebServiceHost(IServiceBehavior serviceBehavior, T instance, Uri[] baseBaseAddresses)
            : base(serviceBehavior)
        {
            var addresses = new UriSchemeKeyedCollection(baseBaseAddresses);

            this.InitializeDescription(instance, addresses);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectAbstractWebServiceHost{T}"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        /// <param name="baseBaseAddresses">The base addresses.</param>
        protected NinjectAbstractWebServiceHost(IServiceBehavior serviceBehavior, Uri[] baseBaseAddresses)
            : base(serviceBehavior)
        {
            var addresses = new UriSchemeKeyedCollection(baseBaseAddresses);

            this.InitializeDescription(typeof(T), addresses);
        }
    }
}