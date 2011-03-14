#region License

// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using System.ServiceModel;
using System.ServiceProcess;
using Ninject;
using Ninject.Extensions.Wcf;
using WcfTimeService;

#endregion

namespace WindowsTimeService
{
    public partial class WindowsTimeService : ServiceBase
    {
        private readonly ServiceHost timeServiceHost;

        public WindowsTimeService(ServiceHost timeServiceHost)
        {
            InitializeComponent();

            this.timeServiceHost = timeServiceHost;
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
                typeof(ITimeService), new NetTcpBinding(), "net.tcp://localhost/TimeService");

            this.timeServiceHost.Open();
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
        }
    }
}