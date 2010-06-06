namespace CalendarSync.Core.Contracts
{
	public interface ISettings
	{
		string UserName { get;}
		string PassWord { get;}
		int MonthsInFuture { get;}
		int MonthsInPast { get;}
	}
}