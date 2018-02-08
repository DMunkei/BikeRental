﻿///Author:Dominique Amir Köstler
///Class:IA116
///Description: Tour bike class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
    class TourBike
    {
        #region Members
        private int _id;
        private int _size;
        private string _kind;
        private int _usedTime;
        private bool _lockStatus;
        private string _location;
        private double _cost;
        private static int _bikeCounter;


        #endregion
        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public string Kind
        {
            get
            {
                return _kind;
            }

            set
            {
                _kind = value;
            }
        }

        public int UsedTime
        {
            get
            {
                return _usedTime;
            }

            set
            {
                _usedTime = value;
            }
        }

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

        public double Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
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
		public bool LockStatus { get => LockStatus; set => LockStatus = value; }
		#endregion
		#region Constructor
		public TourBike(string kindValue, string locationValue)
        {
            this.IncrementBikeCount();
            this.Id = TourBike.BikeCounter;
            this.Size = 30;
            this.Kind = kindValue;
            this.UsedTime = 40;
            this.LockStatus = true;
            this.Location = locationValue;
            this.Cost = 7.5;
        }
        #endregion
        #region Methods
        public void IncrementBikeCount()
        {
            TourBike.BikeCounter += 1;
        }
        public void LockBike()
        {
            if (this.LockStatus != true)
            {
				View.IO.MyConsoleWriteLine("Bike has been locked.");
				this.LockStatus = true;
			}
			View.IO.MyConsoleWriteLine("Bike already locked.");
		}
        #endregion
    }
}
