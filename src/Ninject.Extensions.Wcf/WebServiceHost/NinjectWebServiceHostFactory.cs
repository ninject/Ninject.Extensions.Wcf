//-------------------------------------------------------------------------------
// <copyright file="NinjectWebServiceHostFactory.cs" company="Ninject Project Contributors">
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

    /// <summary>
    /// The host factory for NinjectWebServiceHosts
    /// </summary>
    [Obsolete("Use NinjectServiceHostFactory and configure the Endpoint as REST service.")]
    public class NinjectWebServiceHostFactory : BaseNinjectServiceHostFactory
    {
        /// <summary>
        /// Gets the type of the service host.
        /// </summary>
        /// <value>The type of the service host.</value>
        protected override Type ServiceHostType
        {
            get
            {
                return typeof(NinjectIISHostingWebServiceHost<>);
            }
        }
    }
}
