// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectIISHostingWebServiceHost.cs" company="Ninject Project Contributors">
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
    /// A WebServiceHost for hosting on IIS.
    /// </summary>
    /// <typeparam name="T">The type of the web service</typeparam>
    internal class NinjectIISHostingWebServiceHost<T> : NinjectAbstractWebServiceHost<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectIISHostingWebServiceHost{T}"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The service behavior.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public NinjectIISHostingWebServiceHost(IServiceBehavior serviceBehavior, T instance, Uri[] baseAddresses)
            : base(serviceBehavior, instance, baseAddresses)
        {
        }
    }
}