using System;
using CalendarSync.Core.Contracts;

namespace CalendarSync.Core.Services
{
	public class AppointmentSyncEventAggregator : IAppointmentSyncEventAggregator
	{
		public event EventHandler<AppointmentSyncEventArgs> AppointmentSync;

		public void InvokeAppointmentSync(AppointmentSyncEventArgs e)
		{
			EventHandler<AppointmentSyncEventArgs> handler = AppointmentSync;
			if (handler != null) handler(this, e);
		}
	}
}