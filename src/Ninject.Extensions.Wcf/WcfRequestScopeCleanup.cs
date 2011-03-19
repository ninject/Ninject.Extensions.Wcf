//-------------------------------------------------------------------------------
// <copyright file="WcfRequestScopeCleanup.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using Ninject.Activation.Caching;
    using Ninject.Infrastructure.Language;

    /// <summary>
    /// Cleans up the ninject cache from the OperationContext.Current after each 
    /// </summary>
    public class WcfRequestScopeCleanup : GlobalKernelRegistry, IDispatchMessageInspector
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly bool releaseScopeAtRequestEnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfRequestScopeCleanup"/> class.
        /// </summary>
        /// <param name="releaseScopeAtRequestEnd">if set to <c>true</c> release scope at request end.</param>
        public WcfRequestScopeCleanup(bool releaseScopeAtRequestEnd)
        {
            this.releaseScopeAtRequestEnd = releaseScopeAtRequestEnd;
        }

        /// <summary>
        /// Called after an inbound message has been received but before the message is dispatched to the intended operation.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="channel">The incoming channel.</param>
        /// <param name="instanceContext">The current service instance.</param>
        /// <returns>
        /// The object used to correlate state. This object is passed back in the <see cref="M:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply(System.ServiceModel.Channels.Message@,System.Object)"/> method.
        /// </returns>
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }

        /// <summary>
        /// Called after the operation has returned but before the reply message is sent.
        /// </summary>
        /// <param name="reply">The reply message. This value is null if the operation is one way.</param>
        /// <param name="correlationState">The correlation object returned from the <see cref="M:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest(System.ServiceModel.Channels.Message@,System.ServiceModel.IClientChannel,System.ServiceModel.InstanceContext)"/> method.</param>
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (this.releaseScopeAtRequestEnd)
            {
                var context = OperationContext.Current;
                Kernels.Select(kernel => kernel.Components.Get<ICache>()).Map(cache => cache.Clear(context));
            }
        }
    }
}