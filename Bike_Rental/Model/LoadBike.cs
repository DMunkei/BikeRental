using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
    class LoadBike
    {
        #region Members
        private int _id;
        private int _size;
        private string _kind;
        private int _usedTime;
        private bool _status;
        private string _location;
        private double _cost;
        private int _maximumLoad;


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

        public bool Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
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

        public int MaximumLoad
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
        #endregion
        #region Constructor

        #endregion
        #region Methods

        #endregion
    }
}
