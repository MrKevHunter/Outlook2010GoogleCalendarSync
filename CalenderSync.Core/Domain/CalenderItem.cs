using System;

namespace CalendarSync.Core.Domain
{
	public abstract class CalendarItem : IEquatable<CalendarItem>
	{
		public string Title { get; protected set; }

		public DateTime Start { get; protected set; }

		public DateTime End { get; protected set; }

		public bool IsPrivateItem { get; protected set; }
		public string Location { get; protected set; }

		#region IEquatable<CalendarItem> Members

		public bool Equals(CalendarItem other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Title, Title) && other.Start.Equals(Start) && other.End.Equals(End) &&
			       other.IsPrivateItem.Equals(IsPrivateItem);
		}

		#endregion

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (CalendarItem)) return false;
			return Equals((CalendarItem) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = (Title != null ? Title.GetHashCode() : 0);
				result = (result*397) ^ Start.GetHashCode();
				result = (result*397) ^ End.GetHashCode();
				result = (result*397) ^ IsPrivateItem.GetHashCode();
				return result;
			}
		}

		public static bool operator ==(CalendarItem left, CalendarItem right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(CalendarItem left, CalendarItem right)
		{
			return !Equals(left, right);
		}
	}
}