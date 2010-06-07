using Google.GData.Calendar;

namespace CalendarSync.Core.Domain
{
	public class GoogleCalendarItem : CalendarItem
	{
		private readonly EventEntry _entry;

		public GoogleCalendarItem(EventEntry entry)
		{
			_entry = entry;

			Start = _entry.Times[0].StartTime;
			End = _entry.Times[0].EndTime;
			Title = _entry.Title.Text;
			IsPrivateItem = _entry.EventVisibility != EventEntry.Visibility.PUBLIC && _entry.EventVisibility !=EventEntry.Visibility.DEFAULT;
			Location = _entry.Locations[0].ValueString;

		}
	}
}