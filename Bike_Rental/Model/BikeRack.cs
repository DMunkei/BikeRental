/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          BikeRacks.cs
Einsatz:        -
Beschreibung:   Stellplätze
Funktionen:     -
*****************************************************************************/
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
		private Bike _occupyingBike;
		#endregion
		#region Properties
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
		internal Bike OccupyingBike
		{
			get
			{
				return _occupyingBike;
			}

			set
			{
				_occupyingBike = value;
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
				return false;
			}
			else
			{
				this.RackInUse = false;
				return true;
			}
		}
		public bool StoreBike(Bike BikeType)
		{
			//Bike Rack broken exit
			if (!this.RequiresMaintenance) return false;

			if (this.RackInUse == true)
			{
				return false;
			}
			else
			{
				if(BikeType is EBike)
				{
					this.OccupyingBike = new EBike();					
				}
				else if(BikeType is TourBike)
				{
					this.OccupyingBike = new TourBike();
				}
				else if(BikeType is LoadBike)
				{
					this.OccupyingBike = new LoadBike();
				}
				return true;
			}
		}
		#endregion
	}
}
