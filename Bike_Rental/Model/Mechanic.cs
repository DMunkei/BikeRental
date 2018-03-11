using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental.Model
{
	class Mechanic:Person
	{
		#region Members

		#endregion
		#region Properties

		#endregion
		#region Constructors

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
		public bool RepairRack(BikeRack rack)
		{
			if (rack.RequiresMaintenance == false)
			{
				return false;
			}
			else
			{
				rack.RequiresMaintenance = false;
				return true;
			}
		}
		#endregion
	}
}
