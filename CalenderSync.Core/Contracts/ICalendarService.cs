using System.Collections.Generic;
using CalendarSync.Core.Domain;

namespace CalendarSync.Core.Contracts
{
	public interface ICalendarService
	{
		IEnumerable<CalendarItem> GetItems();
		void AddItems(IEnumerable<CalendarItem> itemsToAdd);
	}
}