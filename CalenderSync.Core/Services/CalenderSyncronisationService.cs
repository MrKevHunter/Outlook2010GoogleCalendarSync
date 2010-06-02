using System.Linq;
using CalendarSync.Core.Contracts;

namespace CalendarSync.Core.Services
{
	public class CalendarSyncService : ICalendarSyncService
	{

		private int MonthsHistoryToSync
		{
			get
			{
				return 0;
			}
		}


		public int MonthsFutureToSync 
		{ 
			get { return 0; }
		}


		private const int MONTHS_PAST = 2;
		private const int MONTHS_FUTURE = 3;
		private readonly ICalendarService _googleCalendarService;
		private readonly ICalendarService _outlookCalendarService;

		public CalendarSyncService(ICalendarService googleCalendarService, ICalendarService outlookCalendarService)
		{
			_googleCalendarService = googleCalendarService;
			_outlookCalendarService = outlookCalendarService;
		}

		public void Sync()
		{
			var googleItems = _googleCalendarService.GetItems(MonthsHistoryToSync, MONTHS_FUTURE);
			var outlookItems = _outlookCalendarService.GetItems(MonthsHistoryToSync, MONTHS_FUTURE);
			var itemsMissingInOutlook = googleItems.Except(outlookItems);
			var itemsMissingInGoogle = outlookItems.Except(googleItems);
			_outlookCalendarService.AddItems(itemsMissingInOutlook);
			_googleCalendarService.AddItems(itemsMissingInGoogle);
		}
	}
}