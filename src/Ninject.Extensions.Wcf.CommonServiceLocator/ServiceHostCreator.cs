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
    /// 
    /// </summary>
    public class ServiceHostCreator : IServiceHostCreator
    {
        /// <summary>
        /// Creator function that users can override to change the default functionality and 
        /// provide alternate <c>ServiceHost</c> implementations.
        /// </summary>
        public static Func<Type, Uri[], ServiceHost> Creator =
            ( serviceType, baseAddresses ) => new ServiceLocatorServiceHost( serviceType, baseAddresses );

        #region Implementation of IServiceHostCreator

        /// <summary>
        /// Creates a <c>ServiceHost</c> with the specified configuration.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <returns>A new or existing service host reference for the specified type of service.</returns>
        public ServiceHost Create( Type serviceType, Uri[] baseAddresses )
        {
            return Creator( serviceType, baseAddresses );
        }

        #endregion
    }
}