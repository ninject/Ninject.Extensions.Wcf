using System;

namespace WcfTimeService
{
    public class MyTimeZoneImplementer : IMyTimeZone
    {
        public MyTimeZoneImplementer()
        {
            Offset = 6;
        }

        public int Offset { get; set; }
    }
}
