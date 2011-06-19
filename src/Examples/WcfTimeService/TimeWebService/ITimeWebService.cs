//-------------------------------------------------------------------------------
// <copyright file="ITimeWebService.cs" company="Ninject Project Contributors">
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
    using System.ServiceModel.Web;

    /// <summary>
    /// Time web service
    /// </summary>
    [ServiceContract]
    public interface ITimeWebService
    {
        /// <summary>
        /// Returns the current time
        /// </summary>
        /// <returns>The current time.</returns>
        [WebGet(UriTemplate = "")]
        [OperationContract]
        DateTime WhatTimeIsIt();

        /// <summary>
        /// Adds some months to the current time.
        /// </summary>
        /// <param name="months">The months to add.</param>
        /// <returns>The current date time plus the given months.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        DateTime AddMonths(int months);
    }
}
