//-------------------------------------------------------------------------------
// <copyright file="NinjectWcfHttpApplicationPlugin.cs" company="Ninject Project Contributors">
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
#if !MONO
    using System.Data.Services;
#endif
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Ninject.Components;
    using Ninject.Web.Common;

    /// <summary>
    /// The <see cref="INinjectHttpApplicationPlugin"/> for WCF.
    /// </summary>
    public class NinjectWcfHttpApplicationPlugin : NinjectComponent, INinjectHttpApplicationPlugin
    {
        /// <summary>
        /// The kernel.
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectWcfHttpApplicationPlugin"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectWcfHttpApplicationPlugin(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets the request scope.
        /// </summary>
        /// <value>The request scope.</value>
        public object RequestScope
        {
            get
            {
                return OperationContext.Current;
            }
        }
        
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            BaseNinjectServiceHostFactory.SetKernel(this.kernel);
#if !MONO
            NinjectDataServiceHostFactory.SetKernel(this.kernel);
#endif
            this.RegisterCustomBehavior();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// Creates a kernel binding for a <c>ServiceHost</c>. If you wish to
        /// provide your own <c>ServiceHost</c> implementation, override this method
        /// and bind your implementation to the <c>ServiceHost</c> class.
        /// </summary>
        protected virtual void RegisterCustomBehavior()
        {
            if (!this.kernel.GetBindings(typeof(ServiceHost)).Any())
            {
                this.kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            }
        
            if (!this.kernel.GetBindings(typeof(WebServiceHost)).Any())
            {
                this.kernel.Bind<WebServiceHost>().To<NinjectWebServiceHost>();
            }

#if !MONO
            if (!this.kernel.GetBindings(typeof(DataServiceHost)).Any())
            {
                this.kernel.Bind<DataServiceHost>().To<NinjectDataServiceHost>();
            }
#endif
        }
    }
}