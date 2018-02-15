///Author:Dominique Amir Köstler
///Class:IA116
///Description: Bike
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	class BikeLot
	{
		#region Members
		private int _bikeLotID;
		private List<BikeRack> _bikeRacks;
		private bool _requiresMaintanence;

        public int BikeLotID
        {
            get
            {
                return _bikeLotID;
            }

            set
            {
                _bikeLotID = value;
            }
        }

        public bool RequiresMaintanence
        {
            get
            {
                return _requiresMaintanence;
            }

            set
            {
                _requiresMaintanence = value;
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


        #endregion
        #region Properties
        //public int BikeLotID { get => _bikeLotID; set => _bikeLotID = value; }
        //internal List<BikeRack> BikeRacks { get => _bikeRacks; set => _bikeRacks = value; }
        //public bool RequiresMaintanence { get => _requiresMaintanence; set => _requiresMaintanence = value; }
        #endregion
        #region Constructors


        #endregion
        #region Methods

        #endregion
    }
}
