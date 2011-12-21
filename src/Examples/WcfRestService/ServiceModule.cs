//-------------------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Chris Hafey (chafey@gmail.com)
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

namespace WcfRestService
{
	using Ninject.Extensions.Wcf;
	using Ninject.Web.Common;
	
	public class ServiceModule : WcfModule
	{
		public override void Load()
		{
			// Binding services InRequestScope allows a single instance to be shared for all requests to the Ninject kernel for
			// instances of that type in a given WCF REST Request.  Other options include:
			//	 InTransientScope() - If you dont' want instances to be shared for a given WCF REST Request
 			//   InSingletonScope() - If you want instances shared between all WCF REST Requests.  You of course need to handle thread safety in this case
			// You probably don't want to use InThreadScope() since IIS can re-use the same thread for multiple requests
			this.Bind<IRepository>().To<Repository>().InRequestScope();
		}
	}
}