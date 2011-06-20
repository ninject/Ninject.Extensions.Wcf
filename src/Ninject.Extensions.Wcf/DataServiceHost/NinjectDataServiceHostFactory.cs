//-------------------------------------------------------------------------------
// <copyright file="NinjectDataServiceHostFactory.cs" company="Ninject Project Contributors">
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

#if !MONO
namespace Ninject.Extensions.Wcf
{
    using System;
    using System.Data.Services;
    using System.ServiceModel;

    using Ninject.Parameters;

    /// <summary>
    /// The host factory for the specified ServiceHost
    /// </summary>
    public class NinjectDataServiceHostFactory : DataServiceHostFactory
    {
        /// <summary>
        /// The kernel that is used to create instances.
        /// </summary>
        private static IKernel kernelInstance;

        /// <summary>
        /// Sets the kernel on this instance.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void SetKernel(IKernel kernel)
        {
            kernelInstance = kernel;
        }

        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost"/> for a
        /// specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">
        /// Specifies the type of service to host.
        /// </param>
        /// <param name="baseAddresses">
        /// The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/>
        /// that contains the base addresses for the service hosted.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.ServiceHost"/> for the type of
        /// service specified with a specific base address.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var baseAddressesArgument = new ConstructorArgument("baseAddresses", baseAddresses);
            var serviceTypeArgument = new ConstructorArgument("serviceType", serviceType);
            return kernelInstance.Get<NinjectDataServiceHost>(serviceTypeArgument, baseAddressesArgument);
        }
    }
}
#endif