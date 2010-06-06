using System;
using System.Configuration;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;
using CalendarSync.Core.Services;

namespace CalendarSync.Core.Domain
{
	public class SyncConfiguration : ISyncConfiguration
	{
		public bool HasDefaultSettings
		{
			get
			{
				return Settings.Default.GoogleUserName == "UserName";
			}
			
		}

		public void UpdateSettings(Func<ISettings> getSettings)
		{
			ISettings values = getSettings();
			Settings.Default.GoogleUserName = values.UserName;
			Settings.Default.GooglePassword = EncryptionService.EncryptString(EncryptionService.ToSecureString(values.PassWord));
			Settings.Default.MonthsInTheFuture = values.MonthsInFuture;
			Settings.Default.MonthsInThePast = values.MonthsInPast;
			Settings.Default.Save();
		}
	}
}