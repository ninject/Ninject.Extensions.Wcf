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
using System.Web;
using Ninject;
using Ninject.Extensions.Wcf;

#endregion

namespace WcfTimeService
{
    public class Global : HttpApplication
    {
        protected void Application_Start( object sender, EventArgs e )
        {
            IKernel kernel = new StandardKernel( new ServiceModule() );
            KernelContainer.Kernel = kernel;
        }

        protected void Session_Start( object sender, EventArgs e )
        {
        }

        protected void Application_BeginRequest( object sender, EventArgs e )
        {
        }

        protected void Application_AuthenticateRequest( object sender, EventArgs e )
        {
        }

        protected void Application_Error( object sender, EventArgs e )
        {
        }

        protected void Session_End( object sender, EventArgs e )
        {
        }

        protected void Application_End( object sender, EventArgs e )
        {
        }
    }
}