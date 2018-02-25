///Author:Dominique Amir Köstler
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
		private EBike _eBike;
		private LoadBike _loadBike;
		private TourBike _tourBike;

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

		public EBike EBike
		{
			get
			{
				return _eBike;
			}
			set
			{
				_eBike = value;
			}
		}
		public TourBike TourBike
		{
			get
			{
				return _tourBike;
			}
			set
			{
				_tourBike = value;
			}
		}
		public LoadBike LoadBike
		{
			get
			{
				return _loadBike;
			}
			set
			{
				_loadBike= value;
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
		private void ReleaseBike()
		{
			if(this.RackInUse == false)
			{
				IO.MyConsoleWriteLine("Stellplatz ist schon Leer.");
				return;
			}
			this.RackInUse = false;
			IO.MyConsoleWriteLine("Fahrrad ausgegeben.");
		}
		private void StoreBike(int BikeType)
		{
			if(this.RackInUse == true)
			{
				IO.MyConsoleWriteLine("Stellplatz besetzt.");
				return;
			}

			if (BikeType == 1)
			{
				this.EBike = new EBike("awesome", "Kai world");
			}
			else if (BikeType == 2)
			{
				this.TourBike = new TourBike("tourAwesome", "wot face");
			}
			else
			{
				this.LoadBike = new LoadBike("awesomeLoad", "Yeaaaaaaaa baby");
			}
			IO.MyConsoleWriteLine("Fahrrad wurde entgegen genommen.");
			this.RackInUse = false;
		}
		#endregion
	}
}
