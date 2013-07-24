//-------------------------------------------------------------------------------
// <copyright file="TimeWebService.svc.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Cedric Bertolasio
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

namespace WcfTimeService.TimeWebService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    
    /// <summary>
    /// Time web service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextModeDefinition.Mode)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TimeWebService : ITimeWebService, IDisposable
    {
        /// <summary>
        /// The system clock to get the current time.
        /// </summary>
        private readonly ISystemClock systemClock;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWebService"/> class.
        /// </summary>
        /// <param name="systemClock">The system clock.</param>
        public TimeWebService(ISystemClock systemClock)
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

        /// <summary>
        /// Adds some months to the current time.
        /// </summary>
        /// <param name="months">The months to add.</param>
        /// <returns>
        /// The current date time plus the given months.
        /// </returns>
        public DateTime AddMonths(int months)
        {
            return this.systemClock.Now.AddMonths(months);
        }

        public void Dispose()
        {
        }
    }
}
