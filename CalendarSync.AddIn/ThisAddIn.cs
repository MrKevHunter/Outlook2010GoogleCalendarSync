using System;
using System.Diagnostics;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.IocConfig;
using CalendarSync.Ui;
using Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace CalendarSync.AddIn
{
	public partial class ThisAddIn
	{

		// not how i would usually use Ioc but can't really do Ctor injection here

		private ICalendarSyncService CalendarSyncService
		{
			get { return StructureMapConfig.Container.GetInstance<ICalendarSyncService>(); }
		}

		private ISyncConfiguration SyncConfiguration
		{
			get { return StructureMapConfig.Container.GetInstance<ISyncConfiguration>(); }
		}

		private IAppointmentSyncEventAggregator AppointmentSyncEventAggregator
		{
			get { return StructureMapConfig.Container.GetInstance<IAppointmentSyncEventAggregator>();}

		}

		private void ThisAddIn_Startup(object sender, EventArgs e)
		{

			if (SyncConfiguration.HasDefaultSettings)
			{
				SyncConfiguration.UpdateSettings(GetSettings);
			}
			AppointmentSyncProgress window = new AppointmentSyncProgress(AppointmentSyncEventAggregator);
			window.Show();
			CalendarSyncService.Sync();
//			window.Close();
		}

		public static ISettings GetSettings()
		{
			var window = new MainWindow();
			if (window.ShowDialog() == true)
			{
				return window.ConfigSettings;
			}
			return null;
		}


		private void ThisAddIn_Shutdown(object sender, EventArgs e)
		{
		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			Startup += ThisAddIn_Startup;
			Shutdown += ThisAddIn_Shutdown;
		}

		#endregion
	}
}