/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          TourBike.cs
Einsatz:        -
Beschreibung:   Kind Klasse von Bike
Funktionen:     -
*****************************************************************************/
using System;
using System.Collections.Generic;


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
		public void LockBike()
		{
			base.LockBike();
		}
		#endregion
	}
}
