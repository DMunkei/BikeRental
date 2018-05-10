/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          Database.cs
Einsatz:        Datenbank verbindung
Beschreibung:   Datenbank für die App
Funktionen:     -
*****************************************************************************/
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
				_query = "CREATE TABLE IF NOT EXISTS Person (personID INTEGER NOT NULL,name varchar,family_Name varchar,username varchar(20) PRIMARY KEY,password varchar(12),userType INTEGER)";
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
			_query = "CREATE TABLE IF NOT EXISTS Bike (BikeID INTEGER PRIMARY KEY,Bike_Type varchar,Standort INTEGER,Bike_In_Use INTEGER,Requires_Maintainence INTEGER)";
			DoCommand(_query);
			//Creates all bikes for the database
			ConnectToDB();
			while (i < 5000)
            {
                if(i< 1900)
                {
                    Random rnd = new Random();
                    int bikeStationNumber = rnd.Next(1, 30);
                    InsertIntoBikeTable(i, typeof(EBike).ToString(), bikeStationNumber,0, 0);
                }
                else if (i < 2800)
                {
                    Random rnd = new Random();
                    int bikeStationNumber = rnd.Next(1, 30);
                    InsertIntoBikeTable(i, typeof(TourBike).ToString(), bikeStationNumber,0, 0);
                }
                else if(i>2800)
                {
                    Random rnd = new Random();
                    int bikeStationNumber = rnd.Next(1, 30);
                    InsertIntoBikeTable(i, typeof(TourBike).ToString(), bikeStationNumber,0, 0);
                }
				i++;
            }
        }
		#endregion
		#region Insert Scripts
		public void InsertIntoBikeTable(int bikeID,string bikeType,int standortNumber, int bikeInUse, int requiresMaintainance)
        {
            _query = String.Format("INSERT INTO bike (bikeID,bike_Type,standort,Bike_In_Use,Requires_Maintainence) VALUES('{0}','{1}','{2}','{3}','{4}')", bikeID, bikeType, standortNumber, bikeInUse, requiresMaintainance);
			DoCommand(_query);
        }
		public void InsertIntoPersonTable(int personID,string name,string famName,string username,string password,int userType)
		{
			ConnectToDB();
			_query = String.Format("INSERT INTO Person (personID,name,family_Name,username, password,userType) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", personID, name,famName,username,password,userType);
			DoCommand(_query);
			this.DbConnection.Close();
		}
		#endregion
		public int GetCurrentPersonID(string username,string password)
		{
			string temp;
			int personID = -1;
			ConnectToDB();
			_query = String.Format("SELECT * FROM Person Where username='{0}' AND password='{1}';",username,password);
			_reader = ReadQuery(_query);
			while (_reader.Read())
			{
				temp = _reader["personID"].ToString();
				personID = Convert.ToInt16(temp);
			}
			return personID;
		}
		public int GetUserType(string username,string password)
		{
			string temp;
			int userType = -1;
			ConnectToDB();
			_query = String.Format("SELECT * FROM Person Where username='{0}' AND password='{1}';", username, password);
			_reader = ReadQuery(_query);
			while (_reader.Read())
			{
				temp = _reader["userType"].ToString();
				userType = Convert.ToInt16(temp);
			}
			return userType;
		}

        private void createTestingUsers()
        {
            string passLogin = "test123";
            string password = Encryptor.MD5Hash(passLogin);

            InsertIntoPersonTable(1, "Bob", "Ross", "admin", password,2);
            InsertIntoPersonTable(2, "Jacques", "Pepin", "techniker", password,0);
            InsertIntoPersonTable(3, "Mohammed", "Salah", "kunde1", password,1);
			InsertIntoPersonTable(4, "Cristiano", "Ronaldo", "kunde2", password, 1);
			InsertIntoPersonTable(5, "Leonel", "Messi", "kunde3", password, 1);
		}
        public bool CheckCredentials(string username, string password)
		{
			bool foundUser = false;
			string dummyString = ""; // Using this just to fulfill the inital SQLiteC
			ConnectToDB();
			SQLiteCommand command = new SQLiteCommand(dummyString, DbConnection);

			_query = String.Format("SELECT * FROM Person WHERE username='{0}' AND password='{1}';", username, password);
			_reader = ReadQuery(_query);

			while (_reader.Read())
			{
				//Console.WriteLine((string)_reader["username"]);
				//Console.WriteLine((string)_reader["password"]);
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
			_query = $"SELECT * FROM Person;";
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
			_query = $"SELECT * FROM Person;";
			_reader = ReadQuery(_query);
			while (_reader.Read())
			{
				targetList.Add(new Client((string)_reader["name"], (string)_reader["family_Name"], (string)_reader["username"], (string)_reader["password"]));
			}
			return targetList;
		}
		public BikeStation[] PopulateBikeStations(BikeStation[] targetArray)
		{
			ConnectToDB();
			_query = $"SELECT * FROM Bike;";
            _reader = ReadQuery(_query);
            while (_reader.Read())
            {
				for (int i = 0; i < targetArray.Length; i++)
				{
                    foreach (BikeRack rack in targetArray[i].BikeRacks)
                    {
                        if(rack.RequiresMaintenance == true)
                        {
                            continue;
                        }
                        if (!rack.RackInUse)
                        {
                            rack.OccupyingBike = (Bike)Activator.CreateInstance(Type.GetType(_reader["Bike_Type"].ToString()));
                            rack.RackInUse = true;
                        }
                    }
				}
            }
			return targetArray;
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
