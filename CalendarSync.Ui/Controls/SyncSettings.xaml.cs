using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalendarSync.Core.Contracts;
using CalendarSync.Core.Domain;

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
			return new ConfigSettings(txtUserName.Text, pwdPassword.Password, sldFuture.SliderValue, sldHistory.SliderValue);
			
		}

		private class ConfigSettings : ISettings
		{
			public ConfigSettings(string userName, string passWord, int monthsInFuture, int monthsInPast)
			{
				UserName = userName;
				PassWord = passWord;
				MonthsInFuture = monthsInFuture;
				MonthsInPast = monthsInPast;
			}

			public string UserName { get; private set; }
			public string PassWord { get; private set; }
			public int MonthsInFuture { get; private set; }
			public int MonthsInPast { get; private set; }
		}
	}
}
