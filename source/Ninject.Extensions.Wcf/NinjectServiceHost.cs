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

#endregion

namespace Ninject.Extensions.Wcf
{
    public class NinjectServiceHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        public NinjectServiceHost()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public NinjectServiceHost( TypeCode serviceType )
            : base( serviceType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="singletonInstance">The singleton instance.</param>
        public NinjectServiceHost( object singletonInstance )
            : base( singletonInstance )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        public NinjectServiceHost( Type serviceType, Uri[] baseAddresses )
            : base( serviceType, baseAddresses )
        {
        }

        /// <summary>
        /// Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add( new NinjectServiceBehavior() );
            base.OnOpening();
        }
    }
}