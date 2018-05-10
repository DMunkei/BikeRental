///Author:Dominique Amir Köstler
///Class:IA116
///Description: Stores multiple bike racks
using System;
using System.Collections.Generic;


namespace Bike_Rental
{
	class BikeStation
	{
		#region Members
		private int _id;
		private static int _stationCounter;
		private List<BikeRack> _bikeRacks;
		private bool _stationStatus; // if its on false then the station is working, doesn't need to be repaired
		private bool _isActive; 
		//private IO _myIO;
		#endregion
		#region Properties

		public int Id
		{
			get
			{
				return _id;
			}

			set
			{
				_id = value;
			}
		}
		public static int StationCounter
		{
			get
			{
				return _stationCounter;
			}

			set
			{
				_stationCounter = value;
			}
		}
		internal List<BikeRack> BikeRacks
		{
			get
			{
				return _bikeRacks;
			}

			set
			{
				_bikeRacks = value;
			}
		}
		public bool StationStatus
		{
			get
			{
				return _stationStatus;
			}

			set
			{
				_stationStatus = value;
			}
		}
		internal IO MyIO
		{
			get
			{
				return MyIO;
			}

			set
			{
				MyIO = value;
			}
		}

		public bool IsActive
		{
			get
			{
				return _isActive;
			}

			set
			{
				_isActive = value;
			}
		}
		#endregion
		#region Constructors
		public BikeStation()
		{
			BikeStation.IncrementStationID();
			this.Id = BikeStation.StationCounter;
			this.BikeRacks = new List<BikeRack>(50);
            this.InitializeBikeRacks();
            this.StationStatus = false;
			//this.MyIO = new IO();
		}
        #endregion
        #region Methods
		public static void InitializeBikeStation(BikeStation[] targets)
		{
			for (int i = 0; i < targets.Length; i++)
			{
				targets[i] = new BikeStation();
			}
		}
        public void InitializeBikeRacks()
        {
			for (int i = 1; i<= 50; i++)
			{
				this.BikeRacks.Add(new BikeRack());
			}
        }


		public int ShowFreeRacks()
		{
			int freeRacksCounter = 0;
			foreach (BikeRack rack in BikeRacks)
			{
				if(rack.RackInUse == false)
				{
					freeRacksCounter++;
				}
			}
			return freeRacksCounter;
		}

		public void ActivateStation()
		{
			this.IsActive = true;
		}
		public void DeactivateStation()
		{
			this.IsActive = false;
		}
			
		public void GetInventory()
		{
			//TODO: Don't know what to add in here.
			foreach (BikeRack Bike in BikeRacks)
			{
				if(Bike.OccupyingBike != null)
				{
					MyIO.MyConsoleWriteLine($"{Bike.OccupyingBike}");				
				}
				else
				{
					//Maybe break instead to make it faster?
					continue;
				}
			}
		}




		private static void IncrementStationID()
		{
			BikeStation.StationCounter++;
		}
		#endregion
	}
}
