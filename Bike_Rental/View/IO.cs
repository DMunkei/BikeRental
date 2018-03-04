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
		#region Properties
		//public string Text { get => Text; set => Text = value; }		
		#endregion
		#region Constructors
		#endregion
		#region Methods
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
		}
		public void WrongInput()
		{
			MyConsoleWriteLine("Sie haben was falsch eingegeben.");
		}
		#endregion
	}
}
