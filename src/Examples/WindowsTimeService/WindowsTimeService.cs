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
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.ServiceProcess;

    using Ninject.Extensions.Wcf;

    using WcfTimeService.TimeService;
    using WcfTimeService.TimeWebService;

    /// <summary>
    /// The service as self hosting.
    /// </summary>
    public partial class WindowsTimeService : ServiceBase
    {
        /// <summary>
        /// The time service host.
        /// </summary>
        private readonly ServiceHost timeServiceHost;

        /// <summary>
        /// The time web service.
        /// </summary>
        private readonly WebServiceHost timeWebServiceHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsTimeService"/> class.
        /// </summary>
        /// <param name="timeServiceHost">The time service host.</param>
        /// <param name="timeWebServiceHost">The time web service host.</param>
        public WindowsTimeService(NinjectServiceHost<TimeService> timeServiceHost, NinjectWebServiceHost<TimeWebService> timeWebServiceHost)
        {
            this.InitializeComponent();

            this.timeServiceHost = timeServiceHost;
            this.timeWebServiceHost = timeWebServiceHost;
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
            this.timeServiceHost.AddServiceEndpoint(
                typeof(ITimeService),
                new NetTcpBinding(), 
                "net.tcp://localhost/TimeService");
            this.timeServiceHost.Open();

            this.timeWebServiceHost.AddServiceEndpoint(
                typeof(ITimeWebService),
                new WebHttpBinding(),
                "http://localhost:8887/TimeWebService");
            this.timeWebServiceHost.Open();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is
        /// sent to the service by the Service Control Manager (SCM). Specifies
        /// actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            if (this.timeServiceHost != null)
            {
                this.timeServiceHost.Close();
            }

            if (this.timeWebServiceHost != null)
            {
                this.timeWebServiceHost.Close();
            }
        }
    }
}