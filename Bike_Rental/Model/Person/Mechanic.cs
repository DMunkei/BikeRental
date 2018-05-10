/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          Mechanic.cs
Einsatz:        Kind Klasse von Person
Beschreibung:   Repariert Fahrräder und Stationen
Funktionen:     -
*****************************************************************************/

using System;
using System.Collections.Generic;



namespace Bike_Rental.Model
{
	class Mechanic:Person
	{
		#region Members

		#endregion
		#region Properties

		#endregion
		#region Constructors
		public Mechanic(string name,string famName) : base(name,famName)
		{

		}
		#endregion
		#region Methods
		public bool RepairRack(BikeRack rack)
		{
			if(rack.RequiresMaintenance == false)
			{
				return false;
			}
			else
			{
				rack.RequiresMaintenance = false;
				return true;
			}
		}
		public bool RepairStation(BikeStation station)
		{
			if (station.StationStatus == false)
			{
				return false;
			}
			else
			{
				station.StationStatus = false;
				return true;
			}
		}
		public override void WhatAmI()
		{
			IO io = new IO();
			io.MyConsoleWriteLine("I am a Mechanic");
		}
		#endregion
	}
}
