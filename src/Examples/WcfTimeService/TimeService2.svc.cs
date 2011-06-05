using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace WcfTimeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TimeService2 : ITimeService2
    {

        private readonly IMyTimeZone myTimeZone;
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public DateTime AddMonths(int months)
        {
            return DateTime.Now.AddMonths(months + myTimeZone.Offset);
        }

        public TimeService2(IMyTimeZone myTimeZone)
        {
            this.myTimeZone = myTimeZone;
        }
    }
}
