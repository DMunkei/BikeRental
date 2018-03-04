using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
    class Program
    {
        static void Main(string[] args)
        {
            //EBike Ebike1 = new EBike("waddup", "Bonn");
            //EBike Ebike2 = new EBike("waddup1", "Konn");
            //EBike Ebike3 = new EBike("waddup2", "Lonn");

            //BikeStation station1 = new BikeStation();

            Controller cntrl1 = new Controller();

			//cntrl1.Run();

			cntrl1.BikeStation.StoreBike(1);



            Console.ReadKey();
        }
    }
}
