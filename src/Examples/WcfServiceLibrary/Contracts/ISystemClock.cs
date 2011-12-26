using System;

namespace WcfServiceLibrary.Contracts
{
	public interface ISystemClock
	{
		DateTime Time { get; }
	}
}