﻿///Author:Dominique Amir Köstler
///Class:IA116
///Description: Can load and unload different types of bikes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	class BikeRack
	{
		#region Members
		private int _bikeRackID;
		private static int _rackCount;
		private bool _rackInUse;
		private int _bikeID;
		private bool _requiresMaintenance;
		
		#endregion
		#region Properties
		//public  int BikeRackID { get => _bikeRackID; set => _bikeRackID = value; }
		//public bool RackInUse { get => _rackInUse; set => _rackInUse = value; }
		//public int BikeID { get => _bikeID; set => _bikeID = value; }
		//public bool RequiresMaintenance { get => _requiresMaintenance; set => _requiresMaintenance = value; }
		//public static int RackCount { get => _rackCount; set => _rackCount = value; }
		public int BikeRackID
		{
			get
			{
				return _bikeRackID;
			}

			set
			{
				_bikeRackID = value;
			}
		}

		public static int RackCount
		{
			get
			{
				return _rackCount;
			}

			set
			{
				_rackCount = value;
			}
		}

		public bool RackInUse
		{
			get
			{
				return _rackInUse;
			}

			set
			{
				_rackInUse = value;
			}
		}

		public int BikeID
		{
			get
			{
				return _bikeID;
			}

			set
			{
				_bikeID = value;
			}
		}

		public bool RequiresMaintenance
		{
			get
			{
				return _requiresMaintenance;
			}

			set
			{
				_requiresMaintenance = value;
			}
		}
		#endregion
		#region Constructors
		public BikeRack()
		{
			BikeRack.IncrementID();
			this.BikeRackID = BikeRack.RackCount;
			this.RackInUse = false;
			this.RequiresMaintenance = false;
		}
		#endregion
		#region Methods
		private static void IncrementID()
		{
			BikeRack.RackCount++;
		}
		public bool ReleaseBike()
		{
			//Bike Rack broken exit
			if (!this.RequiresMaintenance) return false;

			if (this.RackInUse == false)
			{
				//IO.MyConsoleWriteLine("Stellplatz ist schon Leer.");
				return false;
			}
			else
			{
				this.RackInUse = false;
				return true;
			}
			//IO.MyConsoleWriteLine("Fahrrad ausgegeben.");
		}
		public bool StoreBike(int BikeType)
		{
			//Bike Rack broken exit
			if (!this.RequiresMaintenance) return false;

			if (this.RackInUse == true)
			{
				//IO.MyConsoleWriteLine("Stellplatz besetzt.");
				return false;
			}
			else
			{
				this.BikeID = BikeType;
				return true;
			}
	
		}
		#endregion
	}
}
