//-------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Ninject Project Contributors">
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

namespace TimeService.Client
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Threading;
    using TimeService.Client.Services.Time;

    using WcfTimeService.TimeWebService;

    /// <summary>
    /// The application main class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Number of queries performed.
        /// </summary>
        private const int QUERIES = 500;

        /// <summary>
        /// Time between the queries.
        /// </summary>
        private const int SLEEP = 1 * 1000;

        /// <summary>
        /// If true the enpoint is set to the selfhosted service.
        /// </summary>
        private const bool UseSelfHosted = true;

        /// <summary>
        /// Main method of the application
        /// </summary>
        private static void Main()
        {
            TimeServiceClient client = GetTimeService(UseSelfHosted);
            var webServiceClient = CreateTimeWebService(UseSelfHosted);
            Query(client, webServiceClient);
            client.Close();
        }

        /// <summary>
        /// Gets a client for the time service.
        /// </summary>
        /// <param name="selfHosted">if set to <c>true</c> the endpoint is set to the selfhosted service.</param>
        /// <returns>The newly created client.</returns>
        private static TimeServiceClient GetTimeService(bool selfHosted)
        {
            if (selfHosted)
            {
                return new TimeServiceClient(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost/TimeService"));
            }

            return new TimeServiceClient();
        }

        /// <summary>
        /// Creates a client for the time web service.
        /// </summary>
        /// <param name="selfHosted">if set to <c>true</c> [self hosted].</param>
        /// <returns>The newly created client.</returns>
        private static ITimeWebService CreateTimeWebService(bool selfHosted)
        {
            var address = selfHosted ? "http://localhost:8887/TimeWebService" : "http://localhost:51423/TimeWebService/TimeWebService.svc";
            var channelFactory = new ChannelFactory<ITimeWebService>(new WebHttpBinding(), address);
            channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            return channelFactory.CreateChannel();
        }

        /// <summary>
        /// Queries the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="webServiceClient">The web service client.</param>
        private static void Query(ITimeService service, ITimeWebService webServiceClient)
        {
            for (int i = 0; i < QUERIES; i++)
            {
                Console.WriteLine("Server time (Service):    \t{0}", service.WhatTimeIsIt());
                Console.WriteLine("Server time (Web Service):\t{0}", webServiceClient.WhatTimeIsIt());
                Console.WriteLine("Server time + 1 Month:    \t{0}", webServiceClient.AddMonths(1));
                Thread.Sleep(SLEEP);
            }
        }
    }
}