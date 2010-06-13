using System;
using CalendarSync.Core.Domain;

namespace CalendarSync.Core.Services
{
	public class AppointmentSyncEventArgs : EventArgs
	{
		public CalendarItem Item { get; private set; }

		public CalendarType CalendarDestination { get; private set;}

		public AppointmentSyncEventArgs(CalendarItem item,CalendarType calendarDestination)
		{
			Item = item;
			CalendarDestination = calendarDestination;
		}
	}
}