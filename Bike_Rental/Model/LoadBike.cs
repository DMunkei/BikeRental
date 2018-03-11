///Author:Dominique Amir Köstler
///Class:IA116
///Description: Load bike class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{ 
    class LoadBike:Bike
    {
        #region Members
        private double _maximumLoad;
        private static int _bikeCounter;
        #endregion
        #region Properties
        public double MaximumLoad
        {
            get
            {
                return _maximumLoad;
            }

            set
            {
                _maximumLoad = value;
            }
        }
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
        public LoadBike()
        {
            this.IncrementBikeCount();
            this.MaximumLoad = 45;
        }
        #endregion
        #region Methods
        public void IncrementBikeCount()
        {
            LoadBike.BikeCounter ++;
        }
        #endregion
    }
}
