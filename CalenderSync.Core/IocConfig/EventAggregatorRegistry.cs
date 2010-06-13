using CalendarSync.Core.Contracts;
using CalendarSync.Core.Services;
using StructureMap.Configuration.DSL;

namespace CalendarSync.Core.IocConfig
{
	public class EventAggregatorRegistry : Registry
	{
		public EventAggregatorRegistry()
		{
			For<IAppointmentSyncEventAggregator>().Singleton().Use<AppointmentSyncEventAggregator>();
		}
	}
}