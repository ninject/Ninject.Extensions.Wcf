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
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using Syntax;

    /// <summary>
    /// 
    /// </summary>
    public class NinjectInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        private readonly IResolutionRoot resolutionRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="resolutionRoot">The resolution root.</param>
        public NinjectInstanceProvider( Type serviceType, IResolutionRoot resolutionRoot )
        {
            _serviceType = serviceType;
            this.resolutionRoot = resolutionRoot;
        }

        #region Implementation of IInstanceProvider

        /// <summary>
        /// Returns a service object given the specified <see
        /// cref="T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>
        /// A user-defined service object.
        /// </returns>
        /// <param name="instanceContext">
        /// The current <see cref="T:System.ServiceModel.InstanceContext" />
        /// object.
        /// </param>
        public object GetInstance( InstanceContext instanceContext )
        {
            return this.GetInstance( instanceContext, null );
        }

        /// <summary>
        /// Returns a service object given the specified <see
        /// cref="T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>
        /// The service object.
        /// </returns>
        /// <param name="instanceContext">
        /// The current <see cref="T:System.ServiceModel.InstanceContext" />
        /// object.
        /// </param>
        /// <param name="message">
        /// The message that triggered the creation of a service object.
        /// </param>
        public object GetInstance( InstanceContext instanceContext, Message message )
        {
            return this.resolutionRoot.Get( _serviceType );
        }

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext" />
        /// object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">
        /// The service's instance context.
        /// </param>
        /// <param name="instance">
        /// The service object to be recycled.
        /// </param>
        public void ReleaseInstance( InstanceContext instanceContext, object instance )
        {
        }

        #endregion
    }
}