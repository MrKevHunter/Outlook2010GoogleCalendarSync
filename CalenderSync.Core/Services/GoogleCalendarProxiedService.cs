using System;
using System.Net;
using Google.GData.Calendar;
using Google.GData.Client;

namespace CalendarSync.Core.Services
{
	public class GoogleCalendarProxiedService : GoogleCalendarService
	{
		public GoogleCalendarProxiedService(int monthsPast, int monthsFuture) : base(monthsPast, monthsFuture)
		{
		}

		protected override CalendarService Service
		{
			get
			{
				SetProxy(base.Service);
				return base.Service;
			}
		}

		private void SetProxy(CalendarService service)
		{
			var f = (GDataRequestFactory) service.RequestFactory;
			IWebProxy iProxy = WebRequest.DefaultWebProxy;
			var myProxy = new WebProxy(iProxy.GetProxy(new Uri(GOOGLE_CALENDAR_URI)))
			              	{
			              		Credentials = CredentialCache.DefaultCredentials,
			              		UseDefaultCredentials = true
			              	};
			f.Proxy = myProxy;
		}
	}
}