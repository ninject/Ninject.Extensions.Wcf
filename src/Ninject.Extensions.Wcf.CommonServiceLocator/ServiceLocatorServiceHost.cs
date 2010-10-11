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

using System;
using System.ServiceModel;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    /// Service locaotr service host
    /// </summary>
    public class ServiceLocatorServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        public ServiceLocatorServiceHost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public ServiceLocatorServiceHost( TypeCode serviceType )
            : base( serviceType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="singletonInstance">The singleton instance.</param>
        public ServiceLocatorServiceHost( object singletonInstance )
            : base( singletonInstance )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public ServiceLocatorServiceHost( Type serviceType, params Uri[] baseAddresses )
            : base( serviceType, baseAddresses )
        {
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add( new ServiceLocatorServiceBehavior() );
            base.OnOpening();
        }
    }
}