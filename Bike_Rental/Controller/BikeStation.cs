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


		//private IO _io;
		#endregion
		#region Properties
		public int Id { get => _id; set => _id = value; }
		internal List<BikeRack> BikeRacks { get => _bikeRacks; set => _bikeRacks = value; }
		public bool StationStatus { get => _stationStatus; set => _stationStatus = value; }
		public static int StationCounter { get => _stationCounter; set => _stationCounter = value; }

		#endregion
		#region Constructors
		public BikeStation()
		{
			BikeStation.IncrementStationID();
			this.Id = BikeStation.StationCounter;
			this.BikeRacks = new List<BikeRack>(50);
			this.StationStatus = true;
		}
		#endregion
		#region Methods
		private void StoreBike()
		{
			//Figure out how to store bike into bike rack.
		}
		private void ActivateStation()
		{
			this.StationStatus = true;
		}
		private void DeactivateStation()
		{
			this.StationStatus = false;
		}
			
		private void GetInventory()
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
