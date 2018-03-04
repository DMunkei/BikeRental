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
		private BikeStation _bikeStation;
		private IO _myIO;
		#endregion
		#region Properties
		public BikeStation BikeStation
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

		internal IO MyIO { get => _myIO; set => _myIO = value; }
		#endregion
		#region Constructors
		public Controller()
		{
			this.BikeStation = new BikeStation();
		}
		#endregion
		#region Methods
		public void Run()
		{
            bool exit = false;
            MyIO.Splash();
            while (exit != true)
            {
				MyIO.Authorization();
				string userInput = MyIO.MyConsoleReadLine();
				while(userInput != "1" || userInput != "2")
				{
					MyIO.WrongInput();
				}

                MyIO.Menu();
                string userInput2 = MyIO.MyConsoleReadLine();

            }
		}
		#endregion
	}
}
