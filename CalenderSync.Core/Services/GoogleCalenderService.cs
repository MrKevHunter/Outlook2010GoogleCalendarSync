using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
		private readonly int _monthsPast;
		private readonly int _monthsFuture;
		private const string GOOGLE_CALENDAR_URI = "http://www.google.com/calendar/feeds/default/private/full";

		public GoogleCalendarService(int monthsPast,int monthsFuture)
		{
			_monthsPast = monthsPast;
			_monthsFuture = monthsFuture;
		}

		#region ICalendarService Members

		public IEnumerable<CalendarItem> GetItems()
		{
			CalendarService service = GetService();

			var query = new EventQuery
			            	{
			            		Uri = new Uri(GOOGLE_CALENDAR_URI),
									StartTime = DateTime.Now.AddMonths(_monthsPast * -1),
									EndTime = DateTime.Now.AddMonths(_monthsFuture)
			            	};

			SetProxy(service);
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
			       	{
			       		Credentials =
			       			new GDataCredentials(Settings.Default.GoogleUsername,
			       			                     EncryptionService.ToInsecureString(
			       			                     	EncryptionService.DecryptString(Settings.Default.GooglePassword)))
			       	};
		}

		private void AddItem(CalendarItem calendarItem)
		{
			var entry = new EventEntry(calendarItem.Title);
			var w = new Where {ValueString = calendarItem.Location};
			var eventTime = new When(calendarItem.Start, calendarItem.End);
			entry.Times.Add(eventTime);
			entry.Locations.Add(w);
			
			CalendarService calendarService = GetService();
			SetProxy(calendarService);
			calendarService.Insert(new Uri(GOOGLE_CALENDAR_URI), entry);
		}

		private void SetProxy(CalendarService service)
		{
			var f = (GDataRequestFactory)service.RequestFactory;
			IWebProxy iProxy = WebRequest.DefaultWebProxy;
			var myProxy = new WebProxy(iProxy.GetProxy(new Uri(GOOGLE_CALENDAR_URI)))
			{
				Credentials = CredentialCache.DefaultCredentials,
				UseDefaultCredentials = true
			};
			// potentially, setup credentials on the proxy here
			f.Proxy = myProxy;
		}
	}
}