using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;
using CalendarSync.Core.Services;
using StructureMap;

namespace CalendarSync.Core.IocConfig
{
	public class StructureMapConfig
	{
		private static Container _container;

		public static Container Container
		{
			get
			{
				if (_container == null)
				{
					Configure();
				}
				return _container;
			}
		}

		public static void Configure()
		{
			_container = new Container(registry => registry.Scan(x =>
			                                                     	{
			                                                     		x.TheCallingAssembly();
			                                                     		x.Assembly("CalendarSync.Core");
			                                                     		x.WithDefaultConventions();
			                                                     	}));
			_container.Configure(
				x =>
					{
						x.For<ICalendarSyncService>().Use<CalendarSyncService>()
							.Ctor<ICalendarService>("googleCalendarService").Is(y => y.GetInstance<ICalendarService>("GoogleCalendarService"))
							.Ctor<ICalendarService>("outlookCalendarService").Is(z => z.GetInstance<ICalendarService>("OutlookCalendarService"));


						x.For<ICalendarService>().Use<GoogleCalendarService>().Named("GoogleCalendarService")
							.Ctor<int>("monthsPast").Is(Settings.Default.MonthsInThePast)
							.Ctor<int>("monthsFuture").Is(Settings.Default.MonthsInTheFuture);

						x.For<ICalendarService>().Use<OutlookCalendarService>().Named("OutlookCalendarService")
							.Ctor<int>("monthsPast").Is(Settings.Default.MonthsInThePast)
							.Ctor<int>("monthsFuture").Is(Settings.Default.MonthsInTheFuture);
					});
		}
	}
}