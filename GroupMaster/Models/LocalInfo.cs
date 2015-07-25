using System;
using SQLite;

namespace GroupMaster
{
	public class LocalInfo
	{
		public LocalInfo ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string UserName { get; set; }

		public string Passcode { get; set; }

		public bool Active { get; set; }
	}
}