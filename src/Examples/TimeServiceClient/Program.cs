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
using System.Threading;
using TimeService.Client.Services.Time;

#endregion

namespace TimeService.Client
{
    internal class Program
    {
        private const int QUERIES = 5;
        private const int SLEEP = 1 * 1000;
        private static bool useSelfHosted = false;

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