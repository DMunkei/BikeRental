///Author:Dominique Amir 
///Class:Client
///Description: Person
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
	public abstract class Person
	{
		#region Members
		private string _surName;
		private string _familyName;
		#endregion
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

		#endregion
		#region Constructors
		public Person(string name,string famName)
		{
			this.SurName = name;
			this.FamilyName = famName;
		}
		#endregion
		#region Methods
		// Method to know what type of Person this object is
		public abstract void WhatAmI();

		public virtual void PrintName()
		{
			IO io = new Bike_Rental.IO();
			io.MyConsoleWriteLine($"{this.SurName}{this.FamilyName}");
		}
		#endregion
	}
}
