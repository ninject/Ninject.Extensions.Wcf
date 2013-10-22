//-------------------------------------------------------------------------------
// <copyright file="WcfDisposableStrategy.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
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

namespace Ninject.Extensions.Wcf
{
    using System.ServiceModel;

    using Ninject.Activation;
    using Ninject.Activation.Strategies;

    /// <summary>
    /// DisposableStrategy for Wcf.
    /// </summary>
    public class WcfDisposableStrategy : DisposableStrategy
    {
        /// <summary>
        /// Disposes the specified instance.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="reference">A reference to the instance being deactivated.</param>
        public override void Deactivate(IContext context, InstanceReference reference)
        {
            reference.IfInstanceIs<ICommunicationObject>(x =>
                {
                    if (x.State == CommunicationState.Faulted)
                    {
                        x.Abort();
                    }
                    else
                    {
                        try
                        {
                            x.Close();
                        }
                        catch
                        {
                            x.Abort();
                        }
                    }
                });

            base.Deactivate(context, reference);
        }
    }
}