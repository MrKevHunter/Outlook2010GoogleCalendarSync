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
		protected const string GOOGLE_CALENDAR_URI = "http://www.google.com/calendar/feeds/default/private/full";
		private readonly int _monthsFuture;
		private readonly int _monthsPast;
		private CalendarService _calendarService;


		public GoogleCalendarService(int monthsPast, int monthsFuture)
		{
			_monthsPast = monthsPast;
			_monthsFuture = monthsFuture;
		}

		protected virtual CalendarService Service
		{
			get
			{
				if (_calendarService == null)
				{
					_calendarService = new CalendarService("CalendarSyncApp")
					                   	{
					                   		Credentials =
					                   			new GDataCredentials(Settings.Default.GoogleUsername,
					                   			                     EncryptionService.ToInsecureString(
					                   			                     	EncryptionService.DecryptString(Settings.Default.GooglePassword)))
					                   	};
				}

				return _calendarService;
			}
		}

		#region ICalendarService Members

		public IEnumerable<CalendarItem> GetItems()
		{
			var query = new EventQuery
			            	{
			            		Uri = new Uri(GOOGLE_CALENDAR_URI),
			            		StartTime = DateTime.Now.AddMonths(_monthsPast*-1),
			            		EndTime = DateTime.Now.AddMonths(_monthsFuture)
			            	};

			EventFeed calFeed = Service.Query(query);

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

		private void AddItem(CalendarItem calendarItem)
		{
			var entry = new EventEntry(calendarItem.Title);
			var w = new Where {ValueString = calendarItem.Location};
			var eventTime = new When(calendarItem.Start, calendarItem.End);
			entry.Times.Add(eventTime);
			entry.Locations.Add(w);

			CalendarService calendarService = Service;

			calendarService.Insert(new Uri(GOOGLE_CALENDAR_URI), entry);
		}
	}
}