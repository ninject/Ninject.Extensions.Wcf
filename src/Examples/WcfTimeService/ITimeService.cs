// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

namespace WcfTimeService
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// A service that provides the current time
    /// </summary>
    [ServiceContract]
    public interface ITimeService
    {
        /// <summary>
        /// Returns the current time
        /// </summary>
        /// <returns>The current time.</returns>
        [OperationContract]
        DateTime WhatTimeIsIt();
    }
}