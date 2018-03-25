///Author:Dominique Amir Köstler

///Class:IA116

///Description:Controller 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	class Controller
	{
		#region Members
		private List<BikeStation> _bikeStation;
		private List<Person> _person;
		private IO _myIO;
		private Database _myDB;
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
		internal List<BikeStation> BikeStation
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
		#endregion
		#region Constructors
		public Controller()
		{
			this.BikeStation = new List<BikeStation>(100);
			this.Person = new List<Bike_Rental.Person>(200);
			MyIO = new IO();
			MyDB = new Database();
		}
		#endregion
		#region Methods
		public void Run()
		{
			bool exit = false;
			MyIO.Splash();
			Task.Delay(5000);
			MyIO.ClearScreen();			
			while (exit != true)
			{
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
						MyIO.UsernameExists();
						MyIO.TryAgain();
						string tryAgain = MyIO.MyConsoleReadLineToLower();
						switch (tryAgain)
						{
							case "j":
								username = MyIO.MyConsoleReadLine();
								break;
							case "n":
								exit = true;
								break;
							default:
								MyIO.MyConsoleWriteLine("Bitte geben sie entweder J oder N ein.");
								break;
						}
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
						string hashedPassword;
						hashedPassword = Encryptor.MD5Hash(password);
						MyIO.MyConsoleWriteLine("wriet your name");
						string surname = MyIO.MyConsoleReadLine();
						string famName = MyIO.MyConsoleReadLine();
						this.Person.Add(new Client(surname, famName, username, hashedPassword));
						MyDB.InsertIntoClientTable(surname, famName, username, hashedPassword);
					}

				}
				#endregion
				#region Login
				else
				{
					MyIO.Login();
					MyIO.GetUserName();
					string userLogin = MyIO.MyConsoleReadLineToLower();
					MyIO.GetPassword();
					string passLogin = MyIO.MyConsoleReadLine();
					string hashedPassword = Encryptor.MD5Hash(passLogin);
					if(MyDB.CheckCredentials(userLogin, hashedPassword))
					{
						//true then make them see the rest of the program
					}
					else
					{
						//Prompt a message saying wrong login and get passwords again
					}
				}
				#endregion
				MyIO.ClearScreen();
				//MyIO.Greetings(userInput)

				MyIO.Menu();
				string menuSelection = MyIO.MyConsoleReadLine();
			}
		}
	}
	#endregion
}
