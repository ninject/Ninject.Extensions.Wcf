//-------------------------------------------------------------------------------
// <copyright file="WindowsTimeService.cs" company="Ninject Project Contributors">
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

namespace WindowsTimeService
{
    using System;
    using System.Reflection;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceProcess;

    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Extensions.Wcf.SelfHost;
    using Ninject.Web.Common.SelfHost;

    using WcfTimeService.TimeService;
    using WcfTimeService.TimeWebService;

    /// <summary>
    /// The service as self hosting.
    /// </summary>
    public partial class WindowsTimeService : ServiceBase
    {
        private NinjectSelfHostBootstrapper selfHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsTimeService"/> class.
        /// </summary>
        public WindowsTimeService()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// User for debugging to start the service manually.
        /// </summary>
        /// <param name="args">The arguments.</param>
        internal void Start(string[] args)
        {
            this.OnStart(args);
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command
        /// is sent to the service by the Service Control Manager (SCM) or when
        /// the operating system starts (for a service that starts
        /// automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            var timeServiceComfiguration = NinjectWcfConfiguration.Create<TimeService, NinjectServiceSelfHostFactory>(
                this.ConfigureTimeServiceHost, 
                new [] { new Uri("http://localhost:8889/TimeService") });
            var timeWebServiceComfiguration = NinjectWcfConfiguration.Create<TimeWebService, NinjectWebServiceSelfHostFactory>(this.ConfigureTimeWebServiceHost);

            this.selfHost = new NinjectSelfHostBootstrapper(
                CreateKernel, 
                timeServiceComfiguration,
                timeWebServiceComfiguration);
            this.selfHost.Start();
        }

        private void ConfigureTimeServiceHost(ServiceHost host)
        {
            host.AddServiceEndpoint(typeof(ITimeService), new NetTcpBinding(), "net.tcp://localhost/TimeService");
            host.AddServiceEndpoint(typeof(ITimeService), new BasicHttpBinding(), "");
            AddMetadataExchange(host);
        }

        private static void AddMetadataExchange(ServiceHost host)
        {
            host.AddServiceEndpoint(typeof(ITimeService), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            ServiceMetadataBehavior serviceMetadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>()
                                                              ?? new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = true;
            serviceMetadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(serviceMetadataBehavior);
        }

        private void ConfigureTimeWebServiceHost(ServiceHost host)
        {
            host.AddServiceEndpoint(typeof(ITimeWebService), new WebHttpBinding(), "http://localhost:8887/TimeWebService");
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is
        /// sent to the service by the Service Control Manager (SCM). Specifies
        /// actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            this.selfHost.Dispose();
        }

        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>the newly created kernel.</returns>
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}