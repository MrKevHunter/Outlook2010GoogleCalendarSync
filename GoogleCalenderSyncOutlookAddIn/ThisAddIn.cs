using System;
using System.Diagnostics;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.IocConfig;

namespace GoogleCalendarSyncOutlookAddIn
{
	public partial class ThisAddIn
	{
		private void ThisAddIn_Startup(object sender, EventArgs e)
		{
			Trace.WriteLine("Syncing Items");
			var syncService = StructureMapConfig.Container.GetInstance<ICalendarSyncService>();
			syncService.Sync();
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