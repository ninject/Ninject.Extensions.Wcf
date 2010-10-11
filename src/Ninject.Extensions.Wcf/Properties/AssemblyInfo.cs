#region Using Directives

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

#endregion

[assembly : AssemblyTitle( "Ninject Wcf Integration Library" )]
[assembly : Guid( "b7e542d4-a9c6-43e2-af7b-0852c726ce43" )]

#if !NO_PARTIAL_TRUST

[assembly : AllowPartiallyTrustedCallers]
#endif