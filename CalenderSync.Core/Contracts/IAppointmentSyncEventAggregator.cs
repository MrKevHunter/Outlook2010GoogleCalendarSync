using System;
using CalendarSync.Core.Services;

namespace CalendarSync.Core.Contracts
{
	public interface IAppointmentSyncEventAggregator
	{
		event EventHandler<AppointmentSyncEventArgs> AppointmentSync;
		void InvokeAppointmentSync(AppointmentSyncEventArgs e);
	}
}