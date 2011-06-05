using System;

namespace WcfTimeService
{
    public interface IMyTimeZone
    {
        int Offset { get; set; }
    }
}
