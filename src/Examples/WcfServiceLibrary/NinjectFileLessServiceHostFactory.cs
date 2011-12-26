//-------------------------------------------------------------------------------
// <copyright file="NinjectFileLessServiceHostFactory.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Morten Nilsen (morten@runsafe.no)
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

namespace WcfServiceLibrary
{
    using System.ServiceModel;
    using Ninject;
    using Ninject.Extensions.Wcf;

    /// <summary>
    /// The ninject service host factory for hosting svc less services.
    /// </summary>
    public class NinjectFileLessServiceHostFactory : NinjectServiceHostFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFileLessServiceHostFactory"/> class.
        /// </summary>
        public NinjectFileLessServiceHostFactory()
        {
            var kernel = new StandardKernel(new ServiceModule());
            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            SetKernel(kernel);
        }
    }
}
