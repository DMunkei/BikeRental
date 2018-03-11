///Author:Dominique Amir 
///Class:Client
///Description: Person
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
	class Person
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

		#endregion
		#region Methods

		#endregion
	}
}
