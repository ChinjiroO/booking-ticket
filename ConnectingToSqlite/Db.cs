using System.Data.SQLite;
using System.IO;
 
namespace ConnectingToSqlite
{
	public class Db
	{
		public SQLiteConnection dbConnect;

		public Db()
		{
			dbConnect = new SQLiteConnection("Data Source=db.sqlite3");
			if(!File.Exists("./db.sqlite3"))
			{
				SQLiteConnection.CreateFile("db.sqlite3");
				System.Console.WriteLine("db.sqlite3 Created");
            }
		}

		public void OpenConnection()
		{
			if (dbConnect.State != System.Data.ConnectionState.Open)
			{ 
				dbConnect.Open();
			}
		}

		public void CloseConnection()
		{
			if (dbConnect.State != System.Data.ConnectionState.Closed)
			{
				dbConnect.Close();
			}
		}
	}
}

