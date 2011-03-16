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

    /// <summary>
    /// Provider for the current time
    /// </summary>
    public interface ISystemClock
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <value>The current time.</value>
        DateTime Now { get; }
    }
}