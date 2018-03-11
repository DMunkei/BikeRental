///Author:Dominique Amir Köstler
///Class:IA116
///Description: Tour bike class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
    class TourBike:Bike
    {
        #region Members
        private static int _bikeCounter;
		#endregion
		#region Properties
        public static int BikeCounter
        {
            get
            {
                return _bikeCounter;
            }

            set
            {
                _bikeCounter = value;
            }
        }
        #endregion
        #region Constructor
        public TourBike()
        {
            this.IncrementBikeCount();
            this.Id = TourBike.BikeCounter;
            this.Size = 30;
            this.Kind = "Model S";
            this.UsedTime = 40;
            this.LockStatus = false;
            this.Cost = 7.5;
        }
        #endregion
        #region Methods
        public void IncrementBikeCount()
        {
            TourBike.BikeCounter++;
        }
        #endregion
    }
}
