/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          Client.cs
Einsatz:        Program ablauf
Beschreibung:   Bases Klasse für Fahrräder
Funktionen:     -
*****************************************************************************/


using System;
using System.Collections.Generic;


namespace Bike_Rental
{
    class Client:Person
    {
        #region Members
		private bool _isRegistered = false;
		private string _userName;
		private string _password;
        private static int _clientCounter;
        private int _clientID;
		private Bike _rentedBike;
		#endregion
		#region Properties
		public static int ClientCounter
        {
            get
            {
                return _clientCounter;
            }

            set
            {
                _clientCounter = value;
            }
        }
        public int ClientID
        {
            get
            {
                return _clientID;
            }

            set
            {
                _clientID = value;
            }
        }
		public bool IsRegistered
		{
			get
			{
				return _isRegistered;
			}

			set
			{
				_isRegistered = value;
			}
		}
		public string UserName
		{
			get
			{
				return _userName;
			}

			set
			{
				_userName = value;
			}
		}
		public string Password
		{
			get
			{
				return _password;
			}

			set
			{
				_password = value;
			}
		}

		internal Bike RentedBike
		{
			get
			{
				return _rentedBike;
			}

			set
			{
				_rentedBike = value;
			}
		}
		#endregion
		#region Constructors
		public Client(string name,string famName,string user,string pw) : base(name, famName)
        {
			this.UserName = user;
			this.Password = pw;
            Client.IncrementClientID();
            this.ClientID = Client.ClientCounter;
			this.RentedBike = null;
		}
        #endregion
        #region Methods
        private static void IncrementClientID()
        {
            Client.ClientCounter++;
        }
		public string ReturnBike()
		{
			string test = "";
			test = typeof(Bike).ToString();
			this._rentedBike = null;
			return test;
		}		
		public override void WhatAmI()
		{
			IO io = new IO();
			io.MyConsoleWriteLine("I am a client");
		}
        #endregion
    }
}
