This is an example project of using Ninject from a WCF REST Web Service based on the
"WCF REST Service Template 40(CS)" found here:
http://visualstudiogallery.msdn.microsoft.com/fbc7e5c1-a0d2-41bd-9d7b-e54c845394cd?SRC=VSIDE

NOTE - This example is based on the version of Ninject that is currently under development.  It will not work 
with the stable 2.2 version without changes.  Until 2.4 is released, you will need to get compatible versions of 
each Ninject library from the teamcity site (http://teamcity.codebetter.com/project.html?projectId=project3&tab=projectOverview)
or build from source.

Steps followed:

1) Create new project using the WCF REST Service Template 40(CS)
2) Add dependencies on Ninject.Extensions.Wcf, Ninject and Ninject.Web.Common.  
3) Delete all methods from Service1.cs except for GetCollection() (we only need to implement one for this example)
4) Add interface IRepository.cs and add the method GetCollection()
5) Create class Repository.cs that inherits from IRepository and and move code from Service1.GetCollection() to it
6) Add ServiceModule.cs and inherit from NinjectModule, Bind IRepository to Repository in the overriden Load method
7) Modify Global.asax.cs to inherit from NinjectHttpApplication.
  8) Remove Application_Started method since the startup logic is managed by NinjectHttpApplication
  9) Implement CreateKernel method to returnt he kernel with your bindings (via ServiceModule)
  10) Call RegisterRoutes from OnApplicationStarted()

