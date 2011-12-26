//-------------------------------------------------------------------------------
// <copyright file="TimeService.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Morten Nilsen (morten@runsafe.no)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace WcfServiceLibrary.ServiceLayer
{
    using System;
    using WcfServiceLibrary.Contracts;

    /// <summary>
    /// A service that provides the current time.
    /// </summary>
    public class TimeService : ITimeService
    {
        /// <summary>
        /// The system time provider.
        /// </summary>
        private readonly ISystemClock clock;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeService"/> class.
        /// </summary>
        /// <param name="systemClock">The system clock.</param>
        public TimeService(ISystemClock systemClock)
        {
            this.clock = systemClock;
        }

        /// <summary>
        /// Returns the current time.
        /// </summary>
        /// <returns>The current time.</returns>
        public DateTime WhatTimeIsIt()
        {
            return this.clock.Time;
        }
    }
}
