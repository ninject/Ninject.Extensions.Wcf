#region License

// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.Web;
    using Ninject.Infrastructure;

    public abstract class NinjectWcfApplication : HttpApplication, IHaveKernel
    {
        private static IKernel _kernel;

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        public IKernel Kernel
        {
            get { return _kernel; }
        }

        /// <summary>
        /// Handles the Start event of the Application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Application_Start( object sender, EventArgs e )
        {
            lock ( this )
            {
                _kernel = CreateKernel();
                NinjectServiceHostFactory.SetKernel(_kernel);
                RegisterCustomBehavior();
                OnApplicationStarted();
            }
        }

        /// <summary>
        /// Handles the Start event of the Session.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Session_Start( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles the BeginRequest event of the Application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Application_BeginRequest( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles the AuthenticateRequest event of the Application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Application_AuthenticateRequest( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles the Error event of the Application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Application_Error( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles the End event of the Session.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Session_End( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles the End event of the Application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The System.EventArgs instance containing the event data.</param>
        protected virtual void Application_End( object sender, EventArgs e )
        {
            lock ( this )
            {
                if ( _kernel != null )
                {
                    _kernel.Dispose();
                    _kernel = null;
                }

                OnApplicationStopped();
            }
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected abstract IKernel CreateKernel();

        /// <summary>
        /// Creates a kernel binding for a <c>ServiceHost</c>. If you wish to
        /// provide your own <c>ServiceHost</c> implementation, override this method
        /// and bind your implementation to the <c>ServiceHost</c> class.
        /// </summary>
        protected virtual void RegisterCustomBehavior()
        {
            if (_kernel.GetBindings(typeof(ServiceHost)).Count() == 0)
            {
                _kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            }
        }

        /// <summary>
        /// Called when the application is started.
        /// </summary>
        protected virtual void OnApplicationStarted()
        {
        }

        /// <summary>
        /// Called when the application is stopped.
        /// </summary>
        protected virtual void OnApplicationStopped()
        {
        }
    }
}