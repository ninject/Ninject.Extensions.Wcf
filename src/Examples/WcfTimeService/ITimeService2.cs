using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WcfTimeService
{
    
    [ServiceContract]
    public interface ITimeService2
    {
        [WebGet(UriTemplate="")]
        [OperationContract]
        DateTime GetDate();

        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        DateTime AddMonths(int months);
    }
}
