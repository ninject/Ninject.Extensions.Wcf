//-------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Chris Hafey (chafey@gmail.com)
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


namespace WcfRestService
{
    using System.ServiceModel.Activation;
    using System.Web.Routing;
    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Web.Common.WebHost;

    // We replace HttpApplication with NinjectHttpApplication so Ninject can handle the activation and deactivation of
    // services using the Ninjection kernel for reach request for us.  
    //public class Global : HttpApplication
    public class Global : NinjectHttpApplication
    {

        // NinjectHttpApplication needs to do some initialization and it does this by hooking the Application_Started
        // method for us.  When usiong NinjectHttpApplication, move any code you would put in Application_Started
        // to the OnApplicationStarted method below.
        /*
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }
         * */

        // OnApplicationStarted is a virtual method provided by NinjectHttpApplication so you can do startup logic that you
        // would normally do in Application_Started.  One nice side effect of this is that you can use the Ninject Kernel
        // to resolve services that might be needed during application startup.
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // We replace WebServiceHostFactory with NinjectWebServiceHostFactory so Ninject can handle creation of
            // the services using the Ninjection kernel for each inbound request.
            //RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
            RouteTable.Routes.Add(new ServiceRoute("Service1", new NinjectWebServiceHostFactory(), typeof(Service1)));
        }

        // Since Ninject depends on a Kernel with the appropriate bindings, NinjectHttpApplication gets this from us
        // via the abstract method CreateKernel.  
        protected override IKernel CreateKernel()
        {
            // The actual bindings are provided via ServiceModule.  Alternatively, we could call the StandardKernel overload that finds
            // NinjectModules based on paths to assemblies, etc.
            return new StandardKernel(new ServiceModule());
        }
    }
}
