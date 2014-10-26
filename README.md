Modifed this extension to support WebServiceHost as well as ServiceHost.

You can use NinjectWebServiceHostFactory or NinjectServiceHostFactory.

In the original version of this extension, you could use Ninject with WCF services that use bindings like wsHttpBinding and basicHttpBinding.

The changes in this version of the extension allow you to use  Ninject to buildup WCF Rest services that rely on the WebHttpBinding.

