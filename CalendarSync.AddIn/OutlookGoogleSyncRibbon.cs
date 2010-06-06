using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;
using CalendarSync.Core.IocConfig;
using Microsoft.Office.Tools.Ribbon;

namespace CalendarSync.AddIn
{
	public partial class OutlookGoogleSyncRibbon
	{
		private void OutlookGoogleSyncRibbon_Load(object sender, RibbonUIEventArgs e)
		{

		}

		private void BtnSettingsClick(object sender, RibbonControlEventArgs e)
		{
			var syncConfiguration = StructureMapConfig.Container.GetInstance<ISyncConfiguration>();
			syncConfiguration.UpdateSettings(ThisAddIn.GetSettings);
		}

		private void btnSync_Click(object sender, RibbonControlEventArgs e)
		{
			StructureMapConfig.Container.GetInstance<ICalendarSyncService>().Sync();
		}


	}
}
