﻿/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          Controller.cs
Einsatz:        Controller
Beschreibung:   Bestimmt program ablauf
Funktionen:     -
*****************************************************************************/
using System;
using System.Collections.Generic;


namespace Bike_Rental
{
	class Controller
	{
		#region Members
		//private List<BikeStation> _bikeStation;
		private BikeStation[] _bikeStation;
		private List<Person> _person;
		private IO _myIO;
		private Database _myDB;
		private string _hashedPassword;
		private bool _loginSuccess = false;
		private int _currentClientID;
		private string _userLogin;
		#endregion
		#region Properties
		internal IO MyIO
		{
			get
			{
				return _myIO;
			}

			set
			{
				_myIO = value;
			}
		}
		internal Database MyDB
		{
			get
			{
				return _myDB;
			}

			set
			{
				_myDB = value;
			}
		}
		internal List<Person> Person
		{
			get
			{
				return _person;
			}

			set
			{
				_person = value;
			}
		}
		public string HashedPassword
		{
			get
			{
				return _hashedPassword;
			}

			set
			{
				_hashedPassword = value;
			}
		}
		public bool LoginSuccess
		{
			get
			{
				return _loginSuccess;
			}

			set
			{
				_loginSuccess = value;
			}
		}
		public int CurrentClientID
		{
			get
			{
				return _currentClientID;
			}

			set
			{
				_currentClientID = value;
			}
		}
		internal BikeStation[] BikeStation
		{
			get
			{
				return _bikeStation;
			}

			set
			{
				_bikeStation = value;
			}
		}
		#endregion
		#region Constructors
		public Controller()
		{
			this.BikeStation = new BikeStation[100];
			Bike_Rental.BikeStation.InitializeBikeStation(this.BikeStation);
			this.Person = new List<Person>(200); 
			MyIO = new IO();
			MyIO.Splash();
			MyIO.Newline();
			MyIO.InitializingDB();
			MyDB = new Database();
			MyIO.DatabaseReady();
			MyDB.PopulatePersonsList(this.Person);
            MyDB.PopulateBikeStations(this.BikeStation);
        }
		#endregion
		#region Methods
		public void Run()
		{
			bool quit = false;
			MyIO.ClearScreen();
			while (quit == false)			
			{
				quit = MainMenu();
			}
		}

		public bool MainMenu()
		{
			MyIO.ClearScreen();
			MyIO.TestUsers();
			MyIO.Authorization();
			#region Invalid Choice
			string userInput = MyIO.MyConsoleReadLine(); // checking if user wants to register or login
			while (userInput != "1" && userInput != "2")
			{
				MyIO.ClearScreen();
				MyIO.WrongInput();
				MyIO.Authorization();
				userInput = MyIO.MyConsoleReadLine();
			}
			#endregion
			//Either Prompt the register method or login. Add a database to the application
			#region Registration
			if (userInput == "1")
			{
				MyIO.ClearScreen();
				MyIO.InputUsername();
				string username = MyIO.MyConsoleReadLine();
				while (String.IsNullOrEmpty(username))
				{
					MyIO.ClearScreen();
					MyIO.WrongInput();
					MyIO.InputUsername();
					username = MyIO.MyConsoleReadLine();
				}
				if (MyDB.usernameExists(username)) //If the username exists the function will return true.
				{
					MyIO.ClearScreen();
					MyIO.UsernameExists();
					MyIO.Newline();
					MyIO.TryAgain();
					string tryAgain = MyIO.MyConsoleReadLineToLower();
					switch (tryAgain)
					{
						case "j":
							username = MyIO.MyConsoleReadLine();
							break;
						case "n":
							return true;
						default:
							MyIO.MyConsoleWriteLine("Bitte geben sie entweder J oder N ein.");
							break;
					}
					//if (exit)// Exits the program
					//{
					//	break;
					//}
				}
				else
				{
					MyIO.InputPassword();
					string password = MyIO.MyConsoleReadLine();
					while (password.Length < 4)
					{
						MyIO.PasswordDenied();
						password = MyIO.MyConsoleReadLine();
					}
					//I know this isn't best practice, this is just to show that passwords shouldn't be stored in a database without masking the 
					//original password!!
					this.HashedPassword = Encryptor.MD5Hash(password);
					MyIO.MyConsoleWriteLine("write your name");
					string surname = MyIO.MyConsoleReadLine();
					string famName = MyIO.MyConsoleReadLine();
					this.Person.Add(new Client(surname, famName, username, HashedPassword));
					Client currentClient = this.Person[this.Person.Count - 1] as Client; // To get the current clientID;
					MyDB.InsertIntoPersonTable(currentClient.ClientID, surname, famName, username, HashedPassword, 1);
				}
			}
			#endregion
			#region Login
			else
			{
				MyIO.ClearScreen();
				MyIO.TestUsers();
				MyIO.Login();
				MyIO.GetUserName();
				_userLogin = MyIO.MyConsoleReadLineToLower();
				MyIO.GetPassword();
				string passLogin = MyIO.MyConsoleReadLine();
				this.HashedPassword = Encryptor.MD5Hash(passLogin);
				if (MyDB.CheckCredentials(_userLogin, HashedPassword))
				{
					//true then make them see the rest of the program
					this.CurrentClientID = MyDB.GetCurrentPersonID(_userLogin, HashedPassword);
					MyIO.ClearScreen();
					MyIO.Greetings(_userLogin);
					LoginSuccess = true;
				}
				else
				{
					//Prompt a message saying wrong login and get passwords again
				}
			}
			if (LoginSuccess == true)
			{
				switch (MyDB.GetUserType(this._userLogin, this.HashedPassword)) //Possible outputs 0,1,2
				{
					case 0:
						#region Mechanic Menu
						MyIO.MechanicMenu();
						return false;
						#endregion
						break;
					case 1://client
						#region Client Menu
						bool clientMenu = true;
						while (clientMenu)
						{
							MyIO.Newline();
							MyIO.ClientMenu();
							string menuSelection = MyIO.MyConsoleReadLine();
							#region Rent Bike
							if (menuSelection == "1")
							{
								Client currentClient = this.Person[this.CurrentClientID-1] as Client;
								MyIO.ClearScreen();
								MyIO.RentBike();
								string bikeType = MyIO.MyConsoleReadLine();
								if (bikeType == "1")
								{
									//TODO: Populate bikestations with bikes and get the bikes from 
									//a empty bike rack.

									//step 1. Check inside the first bikestation in the list.
									//step 2. look at the bike racks if they don't require maintanence, check if there is a bike inside with the wanted type.
									//step 3. if this bike station has no available bike, go to the next bike station
									///step 4. after finding the bike give the user the bike, set that bike rack empty 
									///step 5. set a flag in the database that the bike has been taken
									///step 6. create time stamp when it was taken.
									///step 7. when giving it back look at the field where it was taken then add a random amount of time as to when it was given bac
									///step 8. set flag that it was returned
									///steo 9. (maybe set it back that it needs to be inspected?)
									currentClient.RentedBike = new EBike();
									MyIO.ClearScreen();
								}
								else if (bikeType == "2")
								{
									currentClient.RentedBike = new LoadBike();
								}
								else if (bikeType == "3")
								{
									currentClient.RentedBike = new TourBike();
								}
								else if (bikeType == "4")
								{
									break;
								}
							}
							#endregion
							else if (menuSelection == "2")
							{
								Client currentClient = this.Person[this.CurrentClientID - 1] as Client;
								currentClient.ReturnBike();
								MyIO.ReturnBike();
							}
							else if (menuSelection == "3")
							{
								int freeRacks = 0;
								foreach (BikeStation station in BikeStation)
								{
									freeRacks += station.ShowFreeRacks();
								}
								MyIO.ClearScreen();
								MyIO.AvailableRacks(freeRacks);
								MyIO.Newline();
							}
							else if (menuSelection == "4")
							{
								//Create Bill
							}
							else if (menuSelection == "5")
							{
								return true;
							}
						}
						#endregion
						break;
					default:
						#region Admin Menu
						MyIO.AdminMenu();
						return false;
						#endregion
						break;
				}
				return false;
			}
			#endregion
			return true;
		}
	}
}
#endregion