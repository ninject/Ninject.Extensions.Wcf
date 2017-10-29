// -------------------------------------------------------------------------------------------------
// <copyright file="BaseNinjectBehaviorExtensionElement.cs" company="Ninject Project Contributors">
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
    using System.ServiceModel.Configuration;

    using Ninject;

    /// <summary>
    /// The base Ninject BehaviorExtensionElement
    /// </summary>
    public abstract class BaseNinjectBehaviorExtensionElement : BehaviorExtensionElement
    {
        /// <summary>
        /// The kernel that is used to create instances.
        /// </summary>
        private static IKernel kernelInstance;

        /// <summary>
        /// Sets the kernel on this instance.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        public static void SetKernel(IKernel kernel)
        {
            kernelInstance = kernel;
        }

        /// <summary>
        /// The generic Ninject BehaviorExtensionElement
        /// </summary>
        /// <typeparam name="T">The behavior.</typeparam>
        public class NinjectBehaviorExtensionElement<T> : BaseNinjectBehaviorExtensionElement
            where T : class
        {
            /// <summary>
            /// Gets the behavior type
            /// </summary>
            public override Type BehaviorType
            {
                get { return typeof(T); }
            }

            /// <summary>
            /// Create the behavior
            /// </summary>
            /// <returns>The behavior instance.</returns>
            protected override object CreateBehavior()
            {
                return kernelInstance.Get<T>();
            }
        }
    }
}