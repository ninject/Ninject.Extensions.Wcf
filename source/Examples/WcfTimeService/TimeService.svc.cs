#region License

//
// Copyright © 2009 Ian Davis <ian.f.davis@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using System;
using System.ServiceModel;
using WindowsTimeService;

#endregion

namespace WcfTimeService
{
    /// <summary>
    /// When self-hosting and injecting the service instance, the InstanceContextMode must be set to Single.
    /// If you are using the IIS hosting, you must remove this attribute.
    /// </summary>
    [ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
    public class TimeService : ITimeService
    {
        private readonly ISystemClock _systemClock;

        public TimeService()
            : this( new SystemClock() )
        {
        }

        public TimeService( ISystemClock systemClock )
        {
            _systemClock = systemClock;
        }

        #region Implementation of ITimeService

        public DateTime WhatTimeIsIt()
        {
            return _systemClock.Now;
        }

        #endregion
    }
}