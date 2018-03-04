///Author:Dominique Amir 
///Class:Client
///Description: Client consisting of a Sur-/Family Name


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
    class Client
    {
        #region Members
        private string _surName;
        private string _familyName;
		private bool _isRegistered = false;
        private static int _clientCounter;
        private int _clientID;

        #region Properties
        public string SurName
        {
            get
            {
                return _surName;
            }

            set
            {
                _surName = value;
            }
        }

        public string FamilyName
        {
            get
            {
                return _familyName;
            }

            set
            {
                _familyName = value;
            }
        }

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

		public bool IsRegistered { get => _isRegistered; set => _isRegistered = value; }

		#endregion
		#region Constructors
		public Client(string name,string famName)
        {
            Client.IncrementClientID();
            this.ClientID = Client.ClientCounter;
            this.SurName = name;
            this.FamilyName = famName;
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
        #endregion
    }
}
