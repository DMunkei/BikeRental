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
		private BikeStation[] _bikeStation;
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
			this.BikeStation = new BikeStation[99];
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
				string userInput = MyIO.MyConsoleReadLine(); // checking if user wants to register or login
				while(userInput != "1" && userInput != "2")
				{
					MyIO.ClearScreen();
					MyIO.WrongInput();
					userInput = MyIO.MyConsoleReadLine();
				}
				//Either Prompt the register method or login. Add a database to the application
				if(userInput == "1")
				{
					MyIO.ClearScreen();
					MyIO.InputUsername();
					string username= MyIO.MyConsoleReadLine();
					if (String.IsNullOrEmpty(username))
					{
						MyIO.WrongInput();
					}
					else
					{
						while ((MyDB.usernameExists(username))) //If the username exists the function will return true.
						{
							MyIO.UsernameExists();
							MyIO.TryAgain();
							string tryAgain = MyIO.MyConsoleReadLine();
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
						MyIO.InputPassword();
						string password = MyIO.MyConsoleReadLine();
						while(password.Length < 4)
						{
							MyIO.PasswordDenied();
							password = MyIO.MyConsoleReadLine();
						}
						MyDB.InsertIntoClientTable(username, password);				
					}
				}
				MyIO.ClearScreen();
				//MyIO.Greetings(userInput)

				MyIO.Menu();
                string userInput2 = MyIO.MyConsoleReadLine();

            }
		}
		#endregion
	}
}
