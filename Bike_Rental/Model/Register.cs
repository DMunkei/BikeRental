///Author:Dominique Amir 
///Class:
///Description: Bike
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
    class Register
    {
        #region Members
        private string _userName;
        private string _password;


        #endregion
        #region Properties
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

        #endregion
        #region Constructors
        public Register()
        {
            SetUsername();
        }
        #endregion
        #region Methods
        private void SetUsername()
        {
            IO.MyConsoleWrite("Bitte Username eingeben:");
            string userInput = IO.MyConsoleReadLine();
            bool result = false;
            while (!result)
            {
                if (!String.IsNullOrEmpty(userInput))
                {
                    this.UserName = userInput;
                    result = true;
                }
                else
                {
                    IO.MyConsoleWriteLine("Sie haben eine invalide Eingabe eingegeben. Versuchen Sie es erneut.");
                }
            }
        }
        //TODO: Make the user input the password twice, checking his input with the 2nd input to match them.
        private void SetPassword()
        {

        }
        #endregion
    }
}
