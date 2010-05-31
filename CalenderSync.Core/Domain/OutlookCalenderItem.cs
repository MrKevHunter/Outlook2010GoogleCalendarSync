using CalendarSync.Core.Domain;
using Microsoft.Office.Interop.Outlook;

namespace CalenderSync.Core.Domain
{
	public class OutlookCalendarItem : CalendarItem
	{
		private readonly AppointmentItem _appointmentItem;

		public OutlookCalendarItem(AppointmentItem appointmentItem)
		{
			_appointmentItem = appointmentItem;
			Start = _appointmentItem.Start;
			End = _appointmentItem.End;
			Location = _appointmentItem.Location;
			IsPrivateItem = _appointmentItem.Sensitivity != OlSensitivity.olNormal;
			Title = _appointmentItem.Subject;

		}
	}
}