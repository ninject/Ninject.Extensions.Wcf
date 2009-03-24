#region License

//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2009, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using System;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    /// A static container for the WCF services's kernel.
    /// </summary>
    public static class KernelContainer
    {
        #region Fields

        private static IKernel _kernel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the kernel that is used in the application.
        /// </summary>
        public static IKernel Kernel
        {
            get { return _kernel; }
            set
            {
                if ( _kernel != null )
                {
                    throw new NotSupportedException( "The static container already has a kernel associated with it!" );
                }

                _kernel = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Injects the specified instance by using the container's kernel.
        /// </summary>
        /// <param name="instance">The instance to inject.</param>
        public static void Inject( object instance )
        {
            if ( _kernel == null )
            {
                throw new InvalidOperationException( String.Format(
                                                         "The type {0} requested an injection, but no kernel has been registered for the web application.\r\n" +
                                                         "Please ensure that your project defines a NinjectHttpApplication.",
                                                         instance.GetType() ) );
            }

            _kernel.Inject( instance );
        }

        #endregion
    }
}