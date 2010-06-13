using System.Collections.Generic;
using System.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;

namespace CalendarSync.Core.Services
{
	public class CalendarSyncService : ICalendarSyncService
	{
		private readonly ICalendarService _googleCalendarService;
		private readonly ICalendarService _outlookCalendarService;

		public CalendarSyncService(ICalendarService googleCalendarService, ICalendarService outlookCalendarService)
		{
			_googleCalendarService = googleCalendarService;
			_outlookCalendarService = outlookCalendarService;
		}

		#region ICalendarSyncService Members

		public void Sync()
		{
			var itemsMissingInOutlook = GetMissingAppointments(sourceCalendar:_googleCalendarService,destinationCalendar:_outlookCalendarService).ToList();

			var itemsMissingInGoogle = GetMissingAppointments(sourceCalendar: _outlookCalendarService,destinationCalendar: _googleCalendarService).ToList();

			_outlookCalendarService.AddItems(itemsMissingInOutlook);
			_googleCalendarService.AddItems(itemsMissingInGoogle);
		}

		private IEnumerable<CalendarItem> GetMissingAppointments(ICalendarService sourceCalendar, ICalendarService destinationCalendar)
		{
			return sourceCalendar.GetItems().Except(destinationCalendar.GetItems());
		}

		#endregion
	}
}