using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class Entry
    {
        static void Main()
        {


            // Create two depots for testing. User input validation to ensure they cant enter a invalid depot. If the login is successful (program will close if not), user is taken to the menu as the driver they signed in as.

            Depot livDepot = new Depot();
            Depot manDepot = new Depot();

            livDepot.setLocation("Liverpool");
            manDepot.setLocation("Manchester");

            System eDepotSystem = new System(livDepot, manDepot);

            Console.WriteLine("Welcome to the EDepot System, enter your home depot");

            string userInput = Console.ReadLine();

            if (userInput != livDepot.getLocation())
            {

                Console.WriteLine("Invalid depot");
            }

            if (userInput == livDepot.getLocation())
            {

                livDepot.logOn(eDepotSystem, livDepot);
                eDepotSystem.mainMenu(livDepot.getDrivers()[1], livDepot);
            }

        }
    }
}
