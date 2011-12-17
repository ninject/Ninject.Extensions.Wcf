//-------------------------------------------------------------------------------
// <copyright file="Service1.cs" company="Ninject Project Contributors">
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
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;

	// Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
	// NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
	// a single instance of the service to process all calls.	
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	// NOTE: If the service is renamed, remember to update the global.asax.cs file
	public class Service1
	{

		private readonly IRepository _repository;

		public Service1(IRepository repository)
		{
			_repository = repository;
		}

		[WebGet(UriTemplate = "")]
		public List<SampleItem> GetCollection()
		{
			// TODO: Replace the current implementation to return a collection of SampleItem instances
			return _repository.GetCollection();
		}

	}
}
