namespace CalendarSync.AddIn
{
	partial class OutlookGoogleSyncRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public OutlookGoogleSyncRibbon()
			: base(Globals.Factory.GetRibbonFactory())
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tab1 = this.Factory.CreateRibbonTab();
			this.googleCalenderSyncRibbon = this.Factory.CreateRibbonGroup();
			this.btnSettings = this.Factory.CreateRibbonButton();
			this.btnSync = this.Factory.CreateRibbonButton();
			this.tab1.SuspendLayout();
			this.googleCalenderSyncRibbon.SuspendLayout();
			// 
			// tab1
			// 
			this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tab1.Groups.Add(this.googleCalenderSyncRibbon);
			this.tab1.Label = "TabAddIns";
			this.tab1.Name = "tab1";
			// 
			// googleCalenderSyncRibbon
			// 
			this.googleCalenderSyncRibbon.Items.Add(this.btnSettings);
			this.googleCalenderSyncRibbon.Items.Add(this.btnSync);
			this.googleCalenderSyncRibbon.Label = "Google Calendar Sync";
			this.googleCalenderSyncRibbon.Name = "googleCalenderSyncRibbon";
			// 
			// btnSettings
			// 
			this.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnSettings.Image = global::CalendarSync.AddIn.Properties.Resources.Configuration_icon_by_obsilion;
			this.btnSettings.Label = "Settings";
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.ShowImage = true;
			this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnSettingsClick);
			// 
			// btnSync
			// 
			this.btnSync.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnSync.Image = global::CalendarSync.AddIn.Properties.Resources._30_Sync_icon;
			this.btnSync.Label = "Sync";
			this.btnSync.Name = "btnSync";
			this.btnSync.ShowImage = true;
			this.btnSync.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSync_Click);
			// 
			// OutlookGoogleSyncRibbon
			// 
			this.Name = "OutlookGoogleSyncRibbon";
			this.RibbonType = "Microsoft.Outlook.Explorer";
			this.Tabs.Add(this.tab1);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.OutlookGoogleSyncRibbon_Load);
			this.tab1.ResumeLayout(false);
			this.tab1.PerformLayout();
			this.googleCalenderSyncRibbon.ResumeLayout(false);
			this.googleCalenderSyncRibbon.PerformLayout();

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup googleCalenderSyncRibbon;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSync;
	}

	partial class ThisRibbonCollection
	{
		internal OutlookGoogleSyncRibbon OutlookGoogleSyncRibbon
		{
			get
			{
				return this.GetRibbon<OutlookGoogleSyncRibbon>();
			}
		}
	}
}
