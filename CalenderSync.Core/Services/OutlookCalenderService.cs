using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;
using CalenderSync.Core.Domain;
using Microsoft.Office.Interop.Outlook;

namespace CalendarSync.Core.Services
{
	public class OutlookCalendarService : ICalendarService
	{
		#region ICalendarService Members

		public IEnumerable<CalendarItem> GetItems(int monthsPast, int monthsFuture)
		{
			MAPIFolder defaultFolder = GetCalendarFolder();
			return
				defaultFolder.Items.Cast<AppointmentItem>().Where(
					appItem =>
					appItem.Start > DateTime.Now.AddMonths(monthsPast*-1) || appItem.End < DateTime.Now.AddMonths(monthsFuture)).Select
					(appItem => new OutlookCalendarItem(appItem));
		}

		public void AddItems(IEnumerable<CalendarItem> itemsToAdd)
		{
			foreach (CalendarItem item in itemsToAdd)
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
			MAPIFolder defaultFolder = GetCalendarFolder();
			var appointmentItem = GetAppointment(item);
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
			if (item.IsPrivateItem)
				return OlSensitivity.olPrivate;

			return OlSensitivity.olNormal;
		}
	}
}