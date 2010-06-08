using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;
using Microsoft.Office.Interop.Outlook;

namespace CalendarSync.Core.Services
{
	public class OutlookCalendarService : ICalendarService
	{
		#region ICalendarService Members

		private readonly int _monthsPast;
		private readonly int _monthsFuture;

		public OutlookCalendarService(int monthsPast, int monthsFuture)
		{
			_monthsPast = monthsPast;
			_monthsFuture = monthsFuture;
		}

		public IEnumerable<CalendarItem> GetItems()
		{
			Func<AppointmentItem, bool> predicate = appItem =>
																 appItem.Start > DateTime.Now.AddMonths(_monthsPast * -1) &&
																 appItem.End < DateTime.Now.AddMonths(_monthsFuture);

			Func<AppointmentItem, OutlookCalendarItem> selector = appItem => new OutlookCalendarItem(appItem);

			return GetCalendarFolder().Items.Cast<AppointmentItem>().Where(predicate).Select(selector);
		}

		public void AddItems(IEnumerable<CalendarItem> itemsToAdd)
		{
			foreach (var item in itemsToAdd)
			{
				AddItem(item);
			}
		}

		#endregion

		private MAPIFolder GetCalendarFolder()
		{
			var app = new Application();
			NameSpace nameSpace = app.GetNamespace("MAPI");
			return nameSpace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
		}

		private void AddItem(CalendarItem item)
		{
			AppointmentItem appointmentItem = GetAppointment(item);
			appointmentItem.Save();
		}

		private AppointmentItem GetAppointment(CalendarItem item)
		{
			AppointmentItem outlookItem = new Application().CreateItem(OlItemType.olAppointmentItem);
			outlookItem.Start = item.Start;
			outlookItem.End = item.End;
			outlookItem.Location = item.Location;
			outlookItem.Sensitivity = GetSensitivity(item);
			outlookItem.Subject = item.Title;
			return outlookItem;
		}

		private OlSensitivity GetSensitivity(CalendarItem item)
		{
			return item.IsPrivateItem ? OlSensitivity.olPrivate : OlSensitivity.olNormal;
		}
	}
}