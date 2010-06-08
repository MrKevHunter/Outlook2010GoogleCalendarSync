namespace CalendarSync.Core.Contracts
{
	public interface ISettings
	{
		string Username { get;}
		string Password { get;}
		int MonthsInFuture { get;}
		int MonthsInPast { get;}
		bool UseProxy { get;}
	}
}