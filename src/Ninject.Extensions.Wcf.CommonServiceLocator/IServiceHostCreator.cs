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

    /// <summary>
    /// Creator for service hosts
    /// </summary>
    public interface IServiceHostCreator
    {
        /// <summary>
        /// Creates a <c>ServiceHost</c> with the specified configuration.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <returns>A new or existing service host reference for the specified type of service.</returns>
        ServiceHost Create(Type serviceType, Uri[] baseAddresses);
    }
}