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
        #region Properties
        //public  int BikeRackID { get => _bikeRackID; set => _bikeRackID = value; }
        //public bool RackInUse { get => _rackInUse; set => _rackInUse = value; }
        //public int BikeID { get => _bikeID; set => _bikeID = value; }
        //public bool RequiresMaintenance { get => _requiresMaintenance; set => _requiresMaintenance = value; }
        //public static int RackCount { get => _rackCount; set => _rackCount = value; }

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
				IO.MyConsoleWriteLine("No bike is currently being stored.");
				return;
			}
			this.RackInUse = false;
			//TODO specify which bike model and bike ID 
			IO.MyConsoleWriteLine("Bike has been released.");
		}
		private void StoreBike()
		{
			if(this.RackInUse == true)
			{
				IO.MyConsoleWriteLine("Bike rack already in use.");
				return;
			}
			IO.MyConsoleWriteLine("Bike has been stored.");
			this.RackInUse = false;
			//TODO: add specific bike type
		}
		#endregion
	}
}
