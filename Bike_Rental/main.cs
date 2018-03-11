using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Rental
{
    class main
    {
        static void Main(string[] args)
        {
            Controller cntrl1 = new Controller();
			cntrl1.Run();

            Console.ReadKey();
        }
    }
}
