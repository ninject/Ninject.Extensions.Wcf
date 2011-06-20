//-------------------------------------------------------------------------------
// <copyright file="TimeService.svc.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Ian Davis (ian@innovatian.com)
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

namespace WcfTimeService.TimeService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    /// <summary>
    /// When self-hosting and injecting the service instance, the InstanceContextMode must be set to Single.
    /// If you are using the IIS hosting, you must remove this attribute.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextModeDefinition.Mode)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TimeService : ITimeService, IDisposable
    {
        /// <summary>
        /// The system clock to get the current time.
        /// </summary>
        private readonly ISystemClock systemClock;

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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}