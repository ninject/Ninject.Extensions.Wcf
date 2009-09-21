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
using System.Threading;
using TimeService.Client.Services.Time;

#endregion

namespace TimeService.Client
{
    internal class Program
    {
        private const int QUERIES = 5;
        private const int SLEEP = 1 * 1000;
        private static bool useSelfHosted = true;

        private static void Main()
        {
            TimeServiceClient client = GetTimeService( useSelfHosted );
            Query( client );
            client.Close();
        }

        private static TimeServiceClient GetTimeService( bool selfHosted )
        {
            if ( selfHosted )
            {
                return new TimeServiceClient( new NetTcpBinding(),
                                              new EndpointAddress( "net.tcp://localhost/TimeService" ) );
            }
            return new TimeServiceClient();
        }

        private static void Query( ITimeService service )
        {
            for ( int i = 0; i < QUERIES; i++ )
            {
                Console.WriteLine( "Server time:\t{0}", service.WhatTimeIsIt() );
                Thread.Sleep( SLEEP );
            }
        }
    }
}