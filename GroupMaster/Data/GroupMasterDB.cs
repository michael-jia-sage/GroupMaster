using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace GroupMaster
{
	public class GroupMasterDB 
	{
		static object locker = new object ();

		SQLiteConnection database;

		string DatabasePath {
			get { 
				var sqliteFilename = "GroupMaster.db3";
				#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
				#else
				#if __ANDROID__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				var path = Path.Combine(documentsPath, sqliteFilename);
				#else
				// WinPhone
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
				#endif
				#endif
				return path;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public GroupMasterDB()
		{
			database = new SQLiteConnection (DatabasePath);
			// create the tables
			database.CreateTable<LocalInfo>();
		}

		public IEnumerable<LocalInfo> GetLocalInfos ()
		{
			lock (locker) {
				return (from i in database.Table<LocalInfo>() select i).ToList();
			}
		}

		public LocalInfo GetActiveLocalInfo ()
		{
			lock (locker) {
				return database.Table<LocalInfo>().FirstOrDefault(x => x.Active);;
			}
		}

		public LocalInfo GetLocalInfo (int id) 
		{
			lock (locker) {
				return database.Table<LocalInfo>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveLocalInfo (LocalInfo item) 
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteLocalInfo(int id)
		{
			lock (locker) {
				return database.Delete<LocalInfo>(id);
			}
		}

		public int DeleteAllLocalInfos()
		{
			lock (locker) {
				return database.DeleteAll<LocalInfo>();
			}
		}
	}
}