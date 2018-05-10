/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          EBike.cs
Einsatz:        -
Beschreibung:   Kind Klasse von Bike
Funktionen:     -
*****************************************************************************/
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
        public EBike()
        {
            this.IncrementBikeCount();
            this.Id = EBike.BikeCounter;
            this.Size = 30;
            this.Kind = "Model X";
            this.UsedTime = 40;
            this.LockStatus = false;
            this.Location = "Mars";
            this.Cost = 7.5;
            this.PowerLevel = 9001; //OVER NINE THOUSAND!
        }
        #endregion
        #region Methods
        public void IncrementBikeCount()
        {
            EBike.BikeCounter += 1;
        }
		public void LockBike()
		{
			base.LockBike();
		}
		
		#endregion
	}
}
