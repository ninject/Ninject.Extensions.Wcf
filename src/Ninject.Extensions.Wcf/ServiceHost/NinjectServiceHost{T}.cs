// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectServiceHost{T}.cs" company="Ninject Project Contributors">
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

    /// <summary>
    /// A service host that uses Ninject to create the service instances.
    /// </summary>
    /// <typeparam name="T">The type of the service</typeparam>
    public class NinjectServiceHost<T> : NinjectAbstractServiceHost<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost{T}"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        /// <param name="instance">The instance.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, T instance)
            : base(serviceBehavior, instance, new Uri[0])
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost{T}"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior)
            : base(serviceBehavior, new Uri[0])
        {
        }
    }
}