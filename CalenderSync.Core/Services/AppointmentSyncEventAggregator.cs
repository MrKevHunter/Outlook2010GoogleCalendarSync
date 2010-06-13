using System;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;

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

	public class AppointmentSyncEventArgs : EventArgs
	{
		public CalendarItem Item { get; private set; }

		public AppointmentSyncEventArgs(CalendarItem item)
		{
			Item = item;
		}
	}
}