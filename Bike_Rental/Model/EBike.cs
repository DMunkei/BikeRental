///Author:Dominique Amir Köstler
///Class:IA116
///Description: Electric bike class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{ 
    class EBike : Bike
    {
        #region Members
        private string _location;
        private double _powerLevel;
        private static int _eBikeCounter;
        #endregion
        #region Properties
        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }
        public double PowerLevel
        {
            get
            {
                return _powerLevel;
            }

            set
            {
                _powerLevel = value;
            }
        }
        public static int EBikeCounter
        {
            get
            {
                return _eBikeCounter;
            }

            set
            {
                _eBikeCounter = value;
            }
        }
        #endregion
        #region Constructor
        public EBike(string kindValue,string locationValue)
        {
            this.IncrementBikeCount();
            this.Id = EBike.BikeCounter;
            this.Size = 30;
            this.Kind = kindValue;
            this.UsedTime = 40;
            this.LockStatus = false;
            this.Location = locationValue;
            this.Cost = 7.5;
            this.PowerLevel = 9001; //OVER NINE THOUSAND!
        }
        #endregion
        #region Methods
        public void IncrementBikeCount()
        {
            EBike.BikeCounter += 1;
        }
		
		#endregion
	}
}
