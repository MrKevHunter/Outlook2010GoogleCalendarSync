using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;
using CalendarSync.Core.IocConfig;
using CalendarSync.Ui;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace CalendarSync.AddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
			  CalendarSyncService = StructureMapConfig.Container.GetInstance<ICalendarSyncService>();
			  SyncConfiguration = StructureMapConfig.Container.GetInstance<ISyncConfiguration>();

			  if (SyncConfiguration.HasDefaultSettings)
			  {
				  SyncConfiguration.UpdateSettings(GetSettings);
			  }

			  Trace.WriteLine("Syncing Items");

			  
			  CalendarSyncService.Sync();
        }

    	private ISettings GetSettings()
    	{
    		MainWindow window = new MainWindow();
			if(window.ShowDialog() == true)
			{
				return window.ConfigSettings;
			}
			else
			{
				throw new Exception("Argh");
			}
    	}

    	public ICalendarSyncService CalendarSyncService { get; set;}

		 public ISyncConfiguration SyncConfiguration { get; set;}


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
