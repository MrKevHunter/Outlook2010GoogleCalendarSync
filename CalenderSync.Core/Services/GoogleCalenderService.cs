using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;
using CalendarSync.Core.Properties;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;

namespace CalendarSync.Core.Services
{
	public class GoogleCalendarService : ICalendarService
	{
		private const string GOOGLE_CALENDAR_URI = "http://www.google.com/calendar/feeds/default/private/full";

		#region ICalendarService Members

		public IEnumerable<CalendarItem> GetItems(int monthsPast, int monthsFuture)
		{
			CalendarService service = GetService();

			var query = new EventQuery
			            	{
			            		Uri = new Uri(GOOGLE_CALENDAR_URI),
			            		StartTime = DateTime.Now.AddMonths(monthsPast*-1),
			            		EndTime = DateTime.Now.AddMonths(monthsFuture)
			            	};


			EventFeed calFeed = service.Query(query);

			return calFeed.Entries.Select(item => new GoogleCalendarItem((EventEntry) item));
		}

		public void AddItems(IEnumerable<CalendarItem> itemsToAdd)
		{
			foreach (CalendarItem calendarItem in itemsToAdd)
			{
				AddItem(calendarItem);
			}
		}

		#endregion

		private CalendarService GetService()
		{
			return new CalendarService("CalendarSyncApp")
			       	{Credentials = new GDataCredentials(Settings.Default.GoogleUserName, Settings.Default.GooglePassword)};
		}

		private void AddItem(CalendarItem calendarItem)
		{
			var entry = new EventEntry(calendarItem.Title);
			var w = new Where {ValueString = calendarItem.Location};
			var eventTime = new When(calendarItem.Start, calendarItem.End);
			entry.Times.Add(eventTime);
			entry.Locations.Add(w);

			CalendarService calendarService = GetService();
			calendarService.Insert(new Uri(GOOGLE_CALENDAR_URI), entry);
		}
	}
}