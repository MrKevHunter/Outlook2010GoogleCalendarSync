using System.Collections.Generic;
using CalendarSync.Core.Domain;

namespace CalendarSync.Core.Contracts
{
	public interface ICalendarService
	{
		IEnumerable<CalendarItem> GetItems(int monthsPast, int monthsFuture);
		void AddItems(IEnumerable<CalendarItem> itemsToAdd);
	}
}