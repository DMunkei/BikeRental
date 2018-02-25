///Author:Dominique Amir Köstler

///Class:IA116

///Description:Controller 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Controller
{
	class Controller
	{
		#region Members
		private BikeStation _bikeStation;
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
		#endregion
		#region Constructors
		public Controller()
		{
			this.BikeStation = new BikeStation();
		}
		#endregion
		#region Methods
		private void Run()
		{

		}
		#endregion
	}
}
