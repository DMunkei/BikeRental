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
	static class IOold
	{
		#region Members
		private static string _text;

        public static string Text
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
        //public static string Text { get => Text; set => Text = value; }		
        #endregion
        #region Constructors
        #endregion
        #region Methods
        public static void MyConsoleWriteLine(string text)
		{
			Console.WriteLine(text);
		}
		public static void MyConsoleWrite(string text)
		{
			Console.Write(text);
		}
		public static string MyConsoleReadLine()
		{
			return Console.ReadLine().ToLower();
		}
		public static void Splash()
		{
			MyConsoleWriteLine("Autor: Dominique Köstler\nFahrradstation Simulation");
		}
		public static void Menu()
		{
			MyConsoleWriteLine("1.Fahrrad Ausleihen.");
			MyConsoleWriteLine("2.Fahrrad Zurückgeben.");
			MyConsoleWriteLine("3.Freie plätze anzeigen.");
		}
		#endregion
	}
}
