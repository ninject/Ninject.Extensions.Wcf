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
    using System.ServiceModel.Description;

    /// <summary>
    /// 
    /// </summary>
    public class NinjectServiceHost : ServiceHost
    {
        private readonly Func<IServiceBehavior> behaviorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="behaviorFactory">The behavior factory.</param>
        public NinjectServiceHost(Func<IServiceBehavior> behaviorFactory)
        {
            this.behaviorFactory = behaviorFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="behaviorFactory">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        public NinjectServiceHost(Func<IServiceBehavior> behaviorFactory, TypeCode serviceType)
            : base(serviceType)
        {
            this.behaviorFactory = behaviorFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="behaviorFactory">The behavior factory.</param>
        /// <param name="singletonInstance">The singleton instance.</param>
        public NinjectServiceHost(Func<IServiceBehavior> behaviorFactory, object singletonInstance)
            : base(singletonInstance)
        {
            this.behaviorFactory = behaviorFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="behaviorFactory">The behavior factory.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public NinjectServiceHost(Func<IServiceBehavior> behaviorFactory, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.behaviorFactory = behaviorFactory;
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(this.behaviorFactory());
            base.OnOpening();
        }
    }
}