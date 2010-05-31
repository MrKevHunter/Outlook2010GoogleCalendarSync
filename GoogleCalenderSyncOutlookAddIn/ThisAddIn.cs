using System;
using CalendarSync.Core.Services;
using Office = Microsoft.Office.Core;

namespace GoogleCalendarSyncOutlookAddIn
{
	public partial class ThisAddIn
	{
		private void ThisAddIn_Startup(object sender, EventArgs e)
		{
			Console.WriteLine("Syncing Items");
			var syncService = new CalendarSyncService(new GoogleCalendarService(),
			                                          new OutlookCalendarService());
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