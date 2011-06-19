//-------------------------------------------------------------------------------
// <copyright file="NinjectWebServiceHost{T}.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Remo Gloor (remo.gloor@gmail.com)
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
    using System.ServiceModel;
    using System.ServiceModel.Description;

    /// <summary>
    /// A service host that uses Ninject to create the service instances.
    /// </summary>
    /// <typeparam name="T">The type of the service</typeparam>
    public class NinjectWebServiceHost<T> : NinjectWebServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the NinjectWebServiceHost class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        /// <param name="instance">The instance.</param>
        public NinjectWebServiceHost(IServiceBehavior serviceBehavior, T instance)
            : base(serviceBehavior)
        {
            var addresses = new UriSchemeKeyedCollection();

            if (ServiceTypeHelper.IsSingletonService(instance))
            {
                this.InitializeDescription(instance, addresses);
            }
            else
            {
                this.InitializeDescription(typeof(T), addresses);
            }
        }
    }
}