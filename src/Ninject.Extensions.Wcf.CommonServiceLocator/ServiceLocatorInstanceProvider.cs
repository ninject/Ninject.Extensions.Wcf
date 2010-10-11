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
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.ServiceLocation;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    /// Service Instance provider 
    /// </summary>
    public class ServiceLocatorInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorInstanceProvider"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public ServiceLocatorInstanceProvider( Type serviceType )
        {
            _serviceType = serviceType;
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
            return GetInstance( instanceContext, null );
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
            return ServiceLocator.Current.GetInstance( _serviceType );
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