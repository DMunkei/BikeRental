/*****************************************************************************
h e i n r i c h -h e r t z -b e r u f s k o l l e g  d e r  s t a d t  b o n n
Autor:          Dominique Köstler
Klasse:         IA116
Datei:          Bike.cs
Einsatz:        Bike
Beschreibung:   Bases Klasse für Fahrräder
Funktionen:     -
*****************************************************************************/
using System;
using System.Collections.Generic;

namespace Bike_Rental
{
	abstract class Bike
	{
		#region Members
		private int _id;
		private int _size;
		private string _kind;
		private int _usedTime;
		private bool _lockStatus;	
		private double _cost;
		private double _powerLevel;
		private static int _bikeCounter;
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
		public bool LockStatus
		{
			get
			{
				return _lockStatus;
			}
			set
			{
				_lockStatus = value;
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
		public static int BikeCounter
		{
			get
			{
				return _bikeCounter;
			}
			set
			{
				_bikeCounter = value;
			}
		}
		#endregion
		#region Constructors
		public Bike()
		{

		}
		#endregion
		#region Methods
		public void IncrementBikeCount()
		{
			Bike.BikeCounter++;
		}
		public bool LockBike()
		{
			if (!this.LockStatus == false)
			{
				this.LockStatus = true;
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
