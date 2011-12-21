using System;
using WcfServiceLibrary.Contracts;

namespace WcfServiceLibrary.ServiceLayer
{
	public class TimeService : ITimeService
	{
		public TimeService(ISystemClock systemClock)
		{
			clock = systemClock;
		}

		public DateTime WhatTimeIsIt()
		{
			return clock.Time;
		}

		private readonly ISystemClock clock;
	}
}
