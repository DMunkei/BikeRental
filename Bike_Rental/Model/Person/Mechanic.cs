using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
	class Mechanic:Person
	{
		#region Members

		#endregion
		#region Properties

		#endregion
		#region Constructors
		public Mechanic(string name,string famName) : base(name,famName)
		{

		}
		#endregion
		#region Methods
		public bool RepairRack(BikeRack rack)
		{
			if(rack.RequiresMaintenance == false)
			{
				return false;
			}
			else
			{
				rack.RequiresMaintenance = false;
				return true;
			}
		}
		public bool RepairStation(BikeStation station)
		{
			if (station.StationStatus == false)
			{
				return false;
			}
			else
			{
				station.StationStatus = false;
				return true;
			}
		}
		public override void WhatAmI()
		{
			IO io = new IO();
			io.MyConsoleWriteLine("I am a Mechanic");
		}
		#endregion
	}
}
