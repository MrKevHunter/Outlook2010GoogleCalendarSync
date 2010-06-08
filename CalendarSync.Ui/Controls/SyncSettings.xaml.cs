using System.Windows.Controls;
using CalendarSync.Core.Contracts;

namespace CalendarSync.Ui.Controls
{
	/// <summary>
	/// Interaction logic for SyncSettings.xaml
	/// </summary>
	public partial class SyncSettings : UserControl
	{
		public SyncSettings()
		{
			InitializeComponent();
		}


		public ISettings GetSettings()
		{
			return new ConfigSettings(txtUsername.Text, pwdPassword.Password, sldFuture.SliderValue, sldHistory.SliderValue,chkUseProxy.IsChecked.Value);
		}

		#region Nested type: ConfigSettings

		private class ConfigSettings : ISettings
		{
			public ConfigSettings(string userName, string passWord, int monthsInFuture, int monthsInPast,bool useProxy)
			{
				Username = userName;
				Password = passWord;
				MonthsInFuture = monthsInFuture;
				MonthsInPast = monthsInPast;
				UseProxy = useProxy;
			}

			#region ISettings Members

			public string Username { get; private set; }
			public string Password { get; private set; }
			public int MonthsInFuture { get; private set; }
			public int MonthsInPast { get; private set; }
			public bool UseProxy { get; private set; }

			#endregion
		}

		#endregion
	}
}