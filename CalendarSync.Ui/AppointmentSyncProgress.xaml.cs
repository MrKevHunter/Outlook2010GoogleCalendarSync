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

			dataGrid1.Columns.Add(new DataGridTextColumn());
			((DataGridTextColumn)dataGrid1.Columns[0]).Binding = new Binding("Item.Title");
			dataGrid1.Columns[0].Header = "Title";

			dataGrid1.Columns.Add(new DataGridTextColumn());
			((DataGridTextColumn)dataGrid1.Columns[1]).Binding = new Binding("Item.Start");
			dataGrid1.Columns[1].Header = "Start Date";

			dataGrid1.Columns.Add(new DataGridTextColumn());
			((DataGridTextColumn)dataGrid1.Columns[2]).Binding = new Binding("Item.End");
			dataGrid1.Columns[2].Header = "End Date";

			dataGrid1.Columns.Add(new DataGridTextColumn());
			((DataGridTextColumn)dataGrid1.Columns[3]).Binding = new Binding("CalendarDestination");
			dataGrid1.Columns[3].Header = "Calendar Destination";
		}

		private void AppointmentSyncEventAggregatorAppointmentSync(object sender, AppointmentSyncEventArgs e)
		{
			dataGrid1.Items.Add(e);
			
		}
	}
}
