using StructureMap;

namespace CalendarSync.Core.IocConfig
{
	public class StructureMapConfig
	{
		private static Container _container;

		public static Container Container
		{
			get
			{
				if (_container == null)
				{
					Configure();
				}
				return _container;
			}
		}

		public static void Configure()
		{
			_container = new Container(x =>
			                           	{
			                           		x.Scan(y =>
			                           		       	{
			                           		       		y.TheCallingAssembly();
			                           		       		y.Assembly("CalendarSync.Core");
			                           		       		y.WithDefaultConventions();
			                           		       		y.LookForRegistries();
			                           		       	});
														x.AddRegistry<CalendarServiceRegistry>();

			                           	});
		}
	}
}

