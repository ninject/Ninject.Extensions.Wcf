using System;
using WcfServiceLibrary.Contracts;

namespace WcfServiceLibrary.BusinessLayer
{
	public class SystemClock : ISystemClock
	{
		public DateTime Time
		{
			get
			{
				return DateTime.Now;
			}
		}
	}
}
