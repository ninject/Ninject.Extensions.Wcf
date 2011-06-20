//-------------------------------------------------------------------------------
// <copyright file="BookStoreDataService.svc.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Remo Gloor (remo.gloor@gmail.com)
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

namespace WcfTimeService.DataSevice
{
    using System.Data.Services;
    using System.Data.Services.Common;

    using log4net;

    /// <summary>
    /// The book store data service.
    /// </summary>
    public class BookStoreDataService : DataService<BookStoreEntities>
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreDataService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BookStoreDataService(ILog logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Initializes the service.
        /// </summary>
        /// <param name="config">The configüration.</param>
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Books", EntitySetRights.AllRead | EntitySetRights.AllWrite);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
        
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void HandleException(HandleExceptionArgs args)
        {
            this.logger.Error(args.Exception);
            base.HandleException(args);
        }

        /// <summary>
        /// Called when processing of a request is started.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            this.logger.Info(args.OperationContext.RequestHeaders.ToString());
            base.OnStartProcessingRequest(args);
        }
    }
}
