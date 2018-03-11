///Author:Dominique Amir Köstler
///Class:IA116
///Description: Stores multiple bike racks
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	class BikeStation
	{
		#region Members
		private int _id;
		private static int _stationCounter;
		private List<BikeRack> _bikeRacks;
		private bool _stationStatus;
		private IO _myIO;
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
		#endregion
		#region Constructors
		public BikeStation()
		{
			BikeStation.IncrementStationID();
			this.Id = BikeStation.StationCounter;
			this.BikeRacks = new List<BikeRack>(50);
            this.InitializeBikeRacks();
            this.StationStatus = true;
			this.MyIO = new IO();
		}
        #endregion
        #region Methods

        private void InitializeBikeRacks()
        {
            for (int i = 1; i<= 50; i++)
            {
                this.BikeRacks.Add(new BikeRack());
            }
        }
        public void StoreBike(int BikeType)
		{
			//Figure out how to store bike into bike rack.
			for (int i = 0; i < BikeRacks.Count; i++)
			{
				if(BikeRacks[i].BikeID == 0)
				{
					BikeRacks[i].BikeID = BikeType;
					BikeRacks[i].RackInUse = true;
					break;
				}
			}
		}

		public void ActivateStation()
		{
			this.StationStatus = true;
		}
		public void DeactivateStation()
		{
			this.StationStatus = false;
		}
			
		public void GetInventory()
		{
			//TODO: Don't know what to add in here.
		}
		private static void IncrementStationID()
		{
			BikeStation.StationCounter++;
		}
		#endregion
	}
}
