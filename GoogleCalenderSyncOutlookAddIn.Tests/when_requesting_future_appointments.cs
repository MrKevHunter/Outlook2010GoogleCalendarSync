using System.Collections.Generic;
using System.Linq;
using CalendarSync.Core.Domain;
using CalendarSync.Core.Services;
using Machine.Specifications;

namespace GoogleCalendarSyncOutlookAddIn.Tests
{
	[Subject(typeof (OutlookCalendarService))]
	public class with_outlook_calendar_service
	{
		protected static OutlookCalendarService _sut;
		private Establish context = () => { _sut = new OutlookCalendarService(); };
	}

	[Subject(typeof (OutlookCalendarService))]
	public class When_requesting_appointments_from_outlook : with_outlook_calendar_service
	{
		private static IEnumerable<CalendarItem> _futureEvents;
		private Because of = () => { _futureEvents = _sut.GetItems(1, 3); };

		private It should_be_able_to_give_me_a_list_of_the_future_appointments =
			() => _futureEvents.Count().ShouldBeGreaterThan(0);
	}

	[Subject(typeof (GoogleCalendarService))]
	public class with_google_calendar_service
	{
		protected static GoogleCalendarService _sut;
		private Establish context = () => { _sut = new GoogleCalendarService(); };
	}

	[Subject(typeof (GoogleCalendarService))]
	public class When_requesting_appointments_from_google : with_google_calendar_service
	{
		private static IEnumerable<CalendarItem> events;
		private Because of = () => { events = _sut.GetItems(1, 3); };
		private It should_be_able_to_give_me_a_list_of_the_future_appointments = () => events.Count().ShouldBeGreaterThan(0);
	}
}