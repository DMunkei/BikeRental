///Author:Dominique Amir Köstler
///Class:IA116
///Description: Static Input Output class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	class IO
	{
		#region Members
		private string _text;

		#endregion
		#region Properties
		public string Text
		{
			get
			{
				return _text;
			}

			set
			{
				_text = value;
			}
		}
		#endregion
		#region Constructors
		#endregion
		#region Methods
		public void ClearScreen()
		{
			Console.Clear();
		}
		public void MyConsoleWriteLine(string text)
		{
			Console.WriteLine(text);
		}
		public void MyConsoleWrite(string text)
		{
			Console.Write(text);
		}
		public string MyConsoleReadLine()
		{
			return Console.ReadLine();
		}
		public string MyConsoleReadLineToLower()
		{
			return Console.ReadLine().ToLower();
		}
		public void Splash()
		{
			MyConsoleWriteLine("Autor: Dominique Köstler\nFahrradstation Simulation");
		}
		public void BikeLockingSuccess()
		{
			MyConsoleWriteLine("Fahhrad wurde erfolgreich entsperrt.");
		}
		public void BikeLockingFailed()
		{
			MyConsoleWriteLine("Fahrrad wurde nicht entsperrt.");
		}
		public void Authorization()
		{
			MyConsoleWriteLine("1.Registrieren.");
			MyConsoleWriteLine("2.Einloggen.");
		}
		public void Menu()
		{
			MyConsoleWriteLine("1.Fahrrad Ausleihen.");
			MyConsoleWriteLine("2.Fahrrad Zurückgeben.");
			MyConsoleWriteLine("3.Freie plätze anzeigen.");
			MyConsoleWriteLine("4.Beenden.");
		}
		public void WrongInput()
		{
			MyConsoleWriteLine("Sie haben was falsch eingegeben.");
		}
		public void UsernameExists()
		{
			MyConsoleWriteLine("Der Username ist nicht verfügbar. Versuchen Sie ein anderen Username.");
		}
		public void PasswordDenied()
		{
			MyConsoleWriteLine("Das Passwort muss mindestens länger als 4 Zeichen sein. Bitte geben Sie ein längeres Passwort ein.");
		}
		public void InputUsername()
		{
			MyConsoleWriteLine("Bitte geben Sie ein Username ein.");
		}
		public void InputPassword()
		{
			MyConsoleWriteLine("Geben Sie bitten ein Passwort ein dass mindestens 4 Zeichen lang ist.");
		}
		public void Greetings(string currentUser)
		{
			MyConsoleWriteLine($"Guten Tag {currentUser}");
		}
		public void TryAgain()
		{
			MyConsoleWriteLine("Geben Sie bitte J ein wenn Sie nochmal ein Username eingeben möchten. Geben Sie N um abzubrechen.");
		}
		#endregion
	}
}
