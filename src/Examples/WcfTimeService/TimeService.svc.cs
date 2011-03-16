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
    /// When self-hosting and injecting the service instance, the InstanceContextMode must be set to Single.
    /// If you are using the IIS hosting, you must remove this attribute.
    /// </summary>
    //// [ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
    public class TimeService : ITimeService
    {
        /// <summary>
        /// The system clock to get the current time.
        /// </summary>
        private readonly ISystemClock systemClock;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeService"/> class.
        /// </summary>
        public TimeService()
            : this(new SystemClock())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeService"/> class.
        /// </summary>
        /// <param name="systemClock">
        /// The system clock.
        /// </param>
        public TimeService(ISystemClock systemClock)
        {
            this.systemClock = systemClock;
        }

        /// <summary>
        /// Returns the current time
        /// </summary>
        /// <returns>The current time.</returns>
        public DateTime WhatTimeIsIt()
        {
            return this.systemClock.Now;
        }
    }
}