#region License

//
// Copyright © 2009 Ian Davis <ian.f.davis@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using System.ServiceModel;
using System.ServiceProcess;
using Ninject.Extensions.Wcf;
using WcfTimeService;

#endregion

namespace WindowsTimeService
{
    public partial class WindowsTimeService : ServiceBase
    {
        private NinjectServiceHost _host;

        public WindowsTimeService()
        {
            InitializeComponent();
        }

        internal void Start( string[] args )
        {
            OnStart( args );
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command
        /// is sent to the service by the Service Control Manager (SCM) or when
        /// the operating system starts (for a service that starts
        /// automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart( string[] args )
        {
            var service = new TimeService();
            _host = new NinjectServiceHost( service );
            _host.AddServiceEndpoint( typeof (ITimeService), new NetTcpBinding(), "net.tcp://localhost/TimeService" );
            _host.Open();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is
        /// sent to the service by the Service Control Manager (SCM). Specifies
        /// actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            _host.Close();
        }
    }
}