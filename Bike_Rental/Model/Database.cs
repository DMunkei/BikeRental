using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Bike_Rental
{
	class Database
	{
		#region Members
		private SQLiteConnection _dbConnection;
		#endregion
		#region Properties
		public SQLiteConnection DbConnection
		{
			get
			{
				return _dbConnection;
			}

			set
			{
				_dbConnection = value;
			}
		}
		#endregion
		#region Constructors
		public Database()
		{
			CreateClientTable();
			CreateBikeTable();

        }
		#endregion
		#region Methods
		private void ConnectToDB()
		{
			DbConnection = new SQLiteConnection("Data Source=BikeStations.sqlite;Version=3;");
			DbConnection.Open();
		}
		#region Create Scripts
		private void CreateClientTable()
		{
            if (!File.Exists("BikeStations.sqlite"))
            {
			    DbConnection = new SQLiteConnection("Data Source=BikeStations.sqlite;Version=3;");
			    DbConnection.Open();
			    string query = "CREATE TABLE IF NOT EXISTS client (clientID INTEGER NOT NULL,name varchar,family_Name varchar,username varchar(10) PRIMARY KEY,password varchar(10))";
			    SQLiteCommand command = new SQLiteCommand(query, DbConnection);
                command.ExecuteNonQuery();

                createTestingUsers();

			    this.DbConnection.Close();
                DbConnection.Dispose();
            }
		}
		private void CreateBikeTable()
		{
            int i = 0
            if (!File.Exists("BikeStations.sqlite"))
            {
                DbConnection = new SQLiteConnection("Data Source=BikeStations.sqlite;Version=3;");
			    DbConnection.Open();
			    string query = "CREATE TABLE IF NOT EXISTS Bike (BikeID INTEGER PRIMARY KEY,Standort INTEGER, Bike_Type varchar,Requires_Maintainence INTEGER)";
			    SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			    command.ExecuteNonQuery();


                while (i < 5000)
                {
                    if(i< 1900)
                    {
                        Random rnd = new Random();
                        int bikeStationNumber = rnd.Next(1, 30);
                        InsertIntoBikeTable(i, "E-Bike", bikeStationNumber, 0);
                    }
                    else if (i < 2800)
                    {
                        Random rnd = new Random();
                        int bikeStationNumber = rnd.Next(1, 30);
                        InsertIntoBikeTable(i, "Tourren Fahrrad", bikeStationNumber, 0);
                    }
                    else
                    {
                        Random rnd = new Random();
                        int bikeStationNumber = rnd.Next(1, 30);
                        InsertIntoBikeTable(i, "Lasten Fahrrad", bikeStationNumber, 0);
                    }
                }

			    this.DbConnection.Close();
                DbConnection.Dispose();
            }
        }
		#endregion
		public void InsertIntoClientTable(int clientID,string name,string famName,string username,string password)
		{
			ConnectToDB();
			string query = String.Format("INSERT INTO client (clientID,name,family_Name,username, password) VALUES({0},'{1}','{2}','{3}','{4}')", clientID, name,famName,username,password);
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			command.ExecuteNonQuery();
			this.DbConnection.Close();
		}
		public int GetCurrentClientID(string username,string password)
		{
			string temp;
			int clientID=-1;
			ConnectToDB();
			string query = String.Format("SELECT * FROM client Where username='{0}' AND password='{1}';",username,password);
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			SQLiteDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				temp = reader["clientID"].ToString();
				clientID = Convert.ToInt16(temp);
			}
			return clientID;
		}



        public void InsertIntoBikeTable(int bikeID,string bikeType,int standortNumber, int requiresMaintainance)
        {
            ConnectToDB();
            string query = String.Format("INSERT INTO bike(bikeID,bike_Type,standort,Requires_Maintainence) VALUES('{0}','{1}','{2}','{3}','{4}'", bikeID, bikeType, standortNumber, requiresMaintainance);
            SQLiteCommand command = new SQLiteCommand(query, DbConnection);
            command.ExecuteNonQuery();
            this.DbConnection.Close();
            DbConnection.Dispose();
        }


        private void createTestingUsers()
        {
            string passLogin = "test123";
            string password1 = Encryptor.MD5Hash(passLogin);

            InsertIntoClientTable(1, "bla", "blob", "admin", password1);
            InsertIntoClientTable(2, "bla", "blob", "mechanic", password1);
            InsertIntoClientTable(3, "bla", "blob", "client", password1);

        }








        public bool CheckCredentials(string username, string password)
		{
			bool foundUser = false;
			string dummyString = ""; // Using this just to fulfill the inital SQLiteC
			ConnectToDB();
			SQLiteCommand command = new SQLiteCommand(dummyString, DbConnection);
			SQLiteDataReader reader;
			string query = String.Format("SELECT * FROM client WHERE username='{0}' AND password='{1}';", username, password);
			command = new SQLiteCommand(query, DbConnection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				Console.WriteLine((string)reader["username"]);
				Console.WriteLine((string)reader["password"]);
				foundUser = true;
				return foundUser;
			}
			return foundUser;
		}
		//Checks if the username exists in the DB
		public bool usernameExists(string username)
		{
			if (String.IsNullOrEmpty(username))
			{
				return false;
			}
			ConnectToDB();
			string query = $"SELECT * FROM client;";
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			foreach (var item in reader)
			{
				if(username == (string)reader["username"])
				{
					this.DbConnection.Close();
					return true;
				}
			}
			this.DbConnection.Close();
			return false;
		}
		public List<Person> PopulatePersonsList(List<Person> targetList)
		{

			ConnectToDB();
			string query = $"SELECT * FROM client;";
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				targetList.Add(new Client((string)reader["name"], (string)reader["family_Name"], (string)reader["username"], (string)reader["password"]));
			}
			return targetList;
		}

		private List<BikeStation> PopulateBikeStations(List<BikeStation> targetList)
		{
			ConnectToDB();
			//string query = String.Format("INSERT INTO Bike")




			return targetList;
		}
		#endregion
	}
}
