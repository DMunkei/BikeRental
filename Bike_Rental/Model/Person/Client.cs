///Author:Dominique Amir 
///Class:Client
///Description: Client consisting of a Sur-/Family Name


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
        #endregion
        #region Methods
        private static void IncrementClientID()
        {
            Client.ClientCounter++;
        }
		public void ClientData()
		{
			//TODO think of a way to write the client's information without having to put a view reference inside this class.
		}
		//Use this when a Client passes registration process
		public void SuccesfulRegistration()
		{ 
			this.IsRegistered = true;
		}
		public void Register()
		{

		}
		public override void WhatAmI()
		{
			IO io = new IO();
			io.MyConsoleWriteLine("I am a client");
		}
        #endregion
    }
}
