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
	static class IO
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
		public static void MyConsoleReadLine()
		{
			Console.ReadLine().ToLower();
		}
		#endregion
	}
}
