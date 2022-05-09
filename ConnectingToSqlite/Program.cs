using System.Data.SQLite;
using System;

namespace ConnectingToSqlite
{
    class Program
    {
        public static void Main(string[] args)
        {
            Db dbObj = new();
            SQLiteCommand cmd = new(dbObj.dbConnect);
            //List<ConcertModel> concerts = new List<ConcertModel>();

            dbObj.OpenConnection();

            CreateTable(dbObj.dbConnect);
            //Console.WriteLine("Table Created");
            //InsertData(cmd);
            //Console.WriteLine("Data Inserted");
            RetriveDb(cmd);

            Console.Write("Enter Ticket Id : ");
            var id = Console.ReadLine();

            if (id != null)
            {
                var ticketId = int.Parse(id);
                BookingConcertTicket(ticketId, cmd);
                Console.ReadKey();
            }

            dbObj.CloseConnection();
        }

        public static void BookingConcertTicket(int id, SQLiteCommand cmd)
        {
            cmd.CommandText = $"select * from ConcertTickets where Id = {id}";
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            var getStatus = reader.GetByte(2);
            if (getStatus != 0) {
                Console.WriteLine("Unavailable");
	        }
            else
            { 
                reader.DisposeAsync();
                Console.WriteLine("Ticket is available.");
                Console.Write("Enter your name: ");
                var name = Console.ReadLine();

                cmd.CommandText = "UPDATE ConcertTickets "
                    + $"SET StatusId = 1, ReservedBy = '{name}', ReservedDate = datetime('now') "
                    + $"WHERE Id = {id}";
                try 
		        {
                    cmd.ExecuteNonQuery();
		        }
                catch (SQLiteException err)
                {
                    throw err;
		        }
                Console.WriteLine($"Ticket Id: {id} is booked");
	        }
	    }
        public static void CreateTable(SQLiteConnection conn)
        {
            string createConcertQuery = "CREATE TABLE IF NOT EXISTS Concert( Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Title VARCHAR(100) NOT NULL, ShowDate DATETIME NOT NULL, Location VARCHAR(100) NOT NULL)";
            string createConcerTicketsQuery = "CREATE TABLE IF NOT EXISTS ConcertTickets(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ConcertId INTEGER NOT NULL, StatusId SMALLINT NOT NULL, ReservedBy VARCHAR(50), ReservedDate DATETIME, FOREIGN KEY(ConcertId) REFERENCES Concert(Id))";

            SQLiteCommand createConcert = new SQLiteCommand(createConcertQuery, conn);
            SQLiteCommand createConcertTickets = new SQLiteCommand(createConcerTicketsQuery, conn);
            createConcert.ExecuteNonQuery();
            createConcertTickets.ExecuteNonQuery(); ;
        }
        public static void InsertData(SQLiteCommand cmd)
        {
            //Insert Concert
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('Body Slam', '2121/3/18 06:03:15', 'Bangkok')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('Mirrr', '2022/1/18 06:03:15', 'Central')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('YENTED', '2022/2/18 06:03:15', 'The Mall')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('Justin Bieber', '2022/3/18 06:03:15', 'New York')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('Nirvana', '2022/4/18 06:03:15', 'Boston')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Concert (Title, ShowDate, Location) VALUES('Eminem', '2022/5/18 06:03:15', 'EmpireState')";
            cmd.ExecuteNonQuery();

            //Insert ConcertTickets
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(1, 0, '', '')";
            cmd.ExecuteNonQuery(); ;
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(2, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(3, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(4, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(5, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(6, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(1, 0, '', '')";
            cmd.ExecuteNonQuery(); ;
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(2, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(3, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(4, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(5, 0, '', '')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO ConcertTickets (ConcertId, StatusId, ReservedBy, ReservedDate) VALUES(6, 0, '', '')";
            cmd.ExecuteNonQuery();
        }
        public static void RetriveDb(SQLiteCommand cmd)
        {
            cmd.CommandText = "SELECT ConcertTickets.Id, ConcertId, Title, Showdate, Location, StatusId, ReservedBy, ReservedDate FROM Concert INNER JOIN ConcertTickets ON Concert.Id = ConcertTickets.ConcertId";
            SQLiteDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Id | ConcertId | Title | ShowDate | Location | StatusID | ReservedBy | ReservedDate ");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetInt32(1)} | {reader.GetString(2)} | {reader.GetString(3)} | {reader.GetString(4)} | {reader.GetByte(5)} | {reader.GetString(6)} | {reader.GetString(7)}");
            }
            reader.DisposeAsync();
        }
    }
}

