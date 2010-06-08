using System;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Properties;
using CalendarSync.Core.Services;

namespace CalendarSync.Core.Domain
{
	public class SyncConfiguration : ISyncConfiguration
	{
		#region ISyncConfiguration Members

		public bool HasDefaultSettings
		{
			get { return Settings.Default.GoogleUsername == "Username"; }
		}

		public void UpdateSettings(Func<ISettings> getSettings)
		{
			ISettings values = getSettings();
			if (values == null)
			{
				return;
			}
			Settings.Default.GoogleUsername = values.Username;
			Settings.Default.GooglePassword = EncryptionService.EncryptString(EncryptionService.ToSecureString(values.Password));
			Settings.Default.MonthsInTheFuture = values.MonthsInFuture;
			Settings.Default.MonthsInThePast = values.MonthsInPast;
			Settings.Default.UseProxyServer = values.UseProxy;
			Settings.Default.Save();
		}

		#endregion
	}
}