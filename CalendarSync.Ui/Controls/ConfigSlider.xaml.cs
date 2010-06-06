using System.Windows.Controls;

namespace CalendarSync.Ui.Controls
{
	/// <summary>
	/// Interaction logic for ConfigSlider.xaml
	/// </summary>
	public partial class ConfigSlider : UserControl
	{
		public ConfigSlider()
		{
			InitializeComponent();
		}

		public int SliderValue
		{
			get { return (int) sld.Value; }
		}
	}
}