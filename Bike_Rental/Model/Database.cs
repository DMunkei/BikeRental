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
		private string _query;
		private SQLiteDataReader _reader;
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
			CreateTables();
			//CreateBikeTable();

        }
		#endregion
		#region Methods
		private void ConnectToDB()
		{
			DbConnection = new SQLiteConnection("Data Source=BikeStations.sqlite;Version=3;");
			DbConnection.Open();
		}
		#region Create Scripts
		private void CreateTables()
		{
            if (!File.Exists("BikeStations.sqlite"))
            {
				ConnectToDB();
				_query = "CREATE TABLE IF NOT EXISTS client (clientID INTEGER NOT NULL,name varchar,family_Name varchar,username varchar(10) PRIMARY KEY,password varchar(10))";
				DoCommand(_query);


				createTestingUsers(); // Creates 3 types of customers. Just for testing purposes.



				CreateBikeTable();

				this.DbConnection.Close();
                DbConnection.Dispose();
            }
		}
		private void CreateBikeTable()
		{
			int i = 1;
			ConnectToDB();
			_query = "CREATE TABLE IF NOT EXISTS Bike (BikeID INTEGER PRIMARY KEY,Bike_Type varchar,Standort INTEGER,Requires_Maintainence INTEGER)";
			DoCommand(_query);
			//Creates all bikes for the database
			ConnectToDB();
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
				i++;
            }
			    //this.DbConnection.Close();
       //         DbConnection.Dispose();
        }
		#endregion
		public void InsertIntoClientTable(int clientID,string name,string famName,string username,string password)
		{
			ConnectToDB();
			_query = String.Format("INSERT INTO client (clientID,name,family_Name,username, password) VALUES({0},'{1}','{2}','{3}','{4}')", clientID, name,famName,username,password);
			DoCommand(_query);
			this.DbConnection.Close();
		}
		public int GetCurrentClientID(string username,string password)
		{
			string temp;
			int clientID=-1;
			ConnectToDB();
			_query = String.Format("SELECT * FROM client Where username='{0}' AND password='{1}';",username,password);
			_reader = ReadQuery(_query);
			while (_reader.Read())
			{
				temp = _reader["clientID"].ToString();
				clientID = Convert.ToInt16(temp);
			}
			return clientID;
		}
        public void InsertIntoBikeTable(int bikeID,string bikeType,int standortNumber, int requiresMaintainance)
        {
            //ConnectToDB();
            _query = String.Format("INSERT INTO bike (bikeID,bike_Type,standort,Requires_Maintainence) VALUES('{0}','{1}','{2}','{3}')", bikeID, bikeType, standortNumber, requiresMaintainance);
			DoCommand(_query);
            //this.DbConnection.Close();
            //DbConnection.Dispose();
        }

        private void createTestingUsers()
        {
            string passLogin = "test123";
            string password1 = Encryptor.MD5Hash(passLogin);

            InsertIntoClientTable(1, "Bob", "Ross", "admin", password1);
            InsertIntoClientTable(2, "Jacques", "Pepin", "techniker", password1);
            InsertIntoClientTable(3, "Mohammed", "Salah", "kunde", password1);

        }
        public bool CheckCredentials(string username, string password)
		{
			bool foundUser = false;
			string dummyString = ""; // Using this just to fulfill the inital SQLiteC
			ConnectToDB();
			SQLiteCommand command = new SQLiteCommand(dummyString, DbConnection);

			_query = String.Format("SELECT * FROM client WHERE username='{0}' AND password='{1}';", username, password);
			_reader = ReadQuery(_query);

			while (_reader.Read())
			{
				Console.WriteLine((string)_reader["username"]);
				Console.WriteLine((string)_reader["password"]);
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
			_query = $"SELECT * FROM client;";
			SQLiteCommand command = new SQLiteCommand(_query, DbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			foreach (var item in _reader)
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
			_query = $"SELECT * FROM client;";
			_reader = ReadQuery(_query);
			while (_reader.Read())
			{
				targetList.Add(new Client((string)_reader["name"], (string)_reader["family_Name"], (string)_reader["username"], (string)_reader["password"]));
			}
			return targetList;
		}

		private List<BikeStation> PopulateBikeStations(List<BikeStation> targetList)
		{
			ConnectToDB();
			_query = $"SELECT * FROM bike;";




			return targetList;
		}

		private void DoCommand(string query)
		{
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			command.ExecuteNonQuery();
		}
		private SQLiteDataReader ReadQuery(string query)
		{
			SQLiteCommand command = new SQLiteCommand(query, DbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			return reader;
		}
		#endregion
	}
}
