using System.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;

namespace CalendarSync.Core.Services
{
	public class CalendarSyncService : ICalendarSyncService
	{

		private int MonthsHistoryToSync
		{
			get
			{
				return Settings.Default.MonthsInThePast;
			}
		}


		private int MonthsFutureToSync 
		{
			get
			{
				return Settings.Default.MonthsInTheFuture;
			}
		}


		private readonly ICalendarService _googleCalendarService;
		private readonly ICalendarService _outlookCalendarService;

		public CalendarSyncService(ICalendarService googleCalendarService, ICalendarService outlookCalendarService)
		{
			_googleCalendarService = googleCalendarService;
			_outlookCalendarService = outlookCalendarService;
		}

		public void Sync()
		{
			var googleItems = _googleCalendarService.GetItems(MonthsHistoryToSync, MonthsFutureToSync);
			var outlookItems = _outlookCalendarService.GetItems(MonthsHistoryToSync, MonthsFutureToSync);
			var itemsMissingInOutlook = googleItems.Except(outlookItems);
			var itemsMissingInGoogle = outlookItems.Except(googleItems);
			_outlookCalendarService.AddItems(itemsMissingInOutlook);
			_googleCalendarService.AddItems(itemsMissingInGoogle);
		}
	}
}