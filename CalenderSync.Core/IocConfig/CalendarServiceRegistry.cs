using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;
using CalendarSync.Core.Services;
using StructureMap.Configuration.DSL;

namespace CalendarSync.Core.IocConfig
{
	public class CalendarServiceRegistry : Registry
	{
		public CalendarServiceRegistry()
		{
			For<ICalendarSyncService>().Use<CalendarSyncService>()
				.Ctor<ICalendarService>("googleCalendarService").Is(y => y.GetInstance<ICalendarService>("GoogleCalendarService"))
				.Ctor<ICalendarService>("outlookCalendarService").Is(z => z.GetInstance<ICalendarService>("OutlookCalendarService"));

			if (Settings.Default.UseProxyServer)
			{
				For<ICalendarService>().Use<GoogleCalendarProxiedService>().Named("GoogleCalendarService")
					.Ctor<int>("monthsPast").Is(Settings.Default.MonthsInThePast)
					.Ctor<int>("monthsFuture").Is(Settings.Default.MonthsInTheFuture);
			}
			else
			{
				For<ICalendarService>().Use<GoogleCalendarService>().Named("GoogleCalendarService")
					.Ctor<int>("monthsPast").Is(Settings.Default.MonthsInThePast)
					.Ctor<int>("monthsFuture").Is(Settings.Default.MonthsInTheFuture);
			}

			For<ICalendarService>().Use<OutlookCalendarService>().Named("OutlookCalendarService")
				.Ctor<int>("monthsPast").Is(Settings.Default.MonthsInThePast)
				.Ctor<int>("monthsFuture").Is(Settings.Default.MonthsInTheFuture);
		}
	}
}