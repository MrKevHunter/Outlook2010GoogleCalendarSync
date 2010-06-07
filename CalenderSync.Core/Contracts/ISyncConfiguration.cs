using System;

namespace CalendarSync.Core.Contracts
{
	public interface ISyncConfiguration
	{
		bool HasDefaultSettings { get; }
		void UpdateSettings(Func<ISettings> getSettings);
	}
}