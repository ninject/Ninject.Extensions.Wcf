// -------------------------------------------------------------------------------------------------
// <copyright file="ServiceTypeHelper.cs" company="Ninject Project Contributors">
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
    using System.Linq;
    using System.ServiceModel;

    /// <summary>
    /// Helper class to decide if a service is a singleton.
    /// </summary>
    internal static class ServiceTypeHelper
    {
        /// <summary>
        /// Determines whether the given service is a singleton service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>
        ///     <c>true</c> if the service is a singleton; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSingletonService(object service)
        {
            var serviceBehaviorAttribute =
                service.GetType().GetCustomAttributes(typeof(ServiceBehaviorAttribute), true)
                .Cast<ServiceBehaviorAttribute>()
                .SingleOrDefault();
            return serviceBehaviorAttribute != null && serviceBehaviorAttribute.InstanceContextMode == InstanceContextMode.Single;
        }
    }
}