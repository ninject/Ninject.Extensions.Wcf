// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    /// <summary>
    /// A service host that uses Ninject to create the service instances.
    /// </summary>
    public class NinjectServiceHost : ServiceHost
    {
        /// <summary>
        /// The service behavior.
        /// </summary>
        private readonly IServiceBehavior serviceBehavior;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, TypeCode serviceType)
            : base(serviceType)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="singletonInstance">The singleton instance.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, object singletonInstance)
            : base(singletonInstance)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceBehavior">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public NinjectServiceHost(IServiceBehavior serviceBehavior, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.serviceBehavior = serviceBehavior;
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(this.serviceBehavior);
            base.OnOpening();
        }
    }
}