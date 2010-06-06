using System;
using System.Configuration;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;

namespace CalendarSync.Core.Domain
{
	public class SyncConfiguration : ISyncConfiguration
	{
		public bool HasDefaultSettings
		{
			get {return Settings.Default.GoogleUserName == "Default"; }
			
		}

		public void UpdateSettings(Func<ISettings> getSettings)
		{
			ISettings values = getSettings();
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			config.AppSettings.Settings["GoogleUserName"].Value = values.UserName;
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");  
		}
	}

	public interface ISettings
	{
		string UserName { get;}
		string PassWord { get;}
		int MonthsInFuture { get;}
		int MonthsInPast { get;}
	}
}