using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Services;

namespace CalendarSync.Ui
{
	/// <summary>
	/// Interaction logic for AppointmentSyncProgress.xaml
	/// </summary>
	public partial class AppointmentSyncProgress : Window
	{
		private readonly IAppointmentSyncEventAggregator _appointmentSyncEventAggregator;

		public AppointmentSyncProgress(IAppointmentSyncEventAggregator appointmentSyncEventAggregator)
		{
			_appointmentSyncEventAggregator = appointmentSyncEventAggregator;
			InitializeComponent();
			_appointmentSyncEventAggregator.AppointmentSync+=AppointmentSyncEventAggregatorAppointmentSync;
		}

		private void AppointmentSyncEventAggregatorAppointmentSync(object sender, AppointmentSyncEventArgs e)
		{
			lvwItems.Items.Add(e.Item);
		}
	}
}
