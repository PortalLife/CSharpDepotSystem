using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class System
    {
        private List<Depot> depots;

        public List<Depot> getDepots()
        {
            return depots;
        }

        public System(Depot depot1, Depot depot2)
        {

            this.depots = new List<Depot>();
            depots.Add(depot1);
            depots.Add(depot2);
        }

        public void mainMenu(Driver loggedOnDriver, Depot loggedonDepot)
        {

            // Main menu loop.
            while (true)
            {

                int userInput;
                Console.WriteLine("Please choose an option");
                Console.WriteLine("1 - View Work Schedules");

                // Display additional options if the logged in driver is of type Manager
                if (loggedOnDriver is Manager)
                {
                    Console.WriteLine("2 - Set new Work Schedule");
                    Console.WriteLine("3 - Move vehicle");
                    Console.WriteLine("4 - Register new driver");

                }

                // Convert string into number for user input

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {

                    case 1:


                        // Print the logged in drivers work schedule
                        for (int i = 0; i < loggedOnDriver.getSchedule().Count(); i++)
                        {

                            Console.WriteLine(loggedOnDriver.getSchedule()[i].getStartDate());
                            Console.WriteLine(loggedOnDriver.getSchedule()[i].getEndDate());
                            Console.WriteLine(loggedOnDriver.getSchedule()[i].getCilent());

                        }

                        break;

                    case 2:

                        // Create variables for userinput.
                        DateTime startDate;
                        DateTime endDate;
                        string cilent;


                        Console.WriteLine("Enter the start date, end date, cilent.");
                        startDate = Convert.ToDateTime(Console.ReadLine());
                        endDate = Convert.ToDateTime(Console.ReadLine());
                        cilent = Console.ReadLine();

                        workSchedule newSched = new workSchedule(startDate, endDate, cilent);

                        Console.WriteLine("Enter the driver name and vehicle reg number");

                        string driverName = Console.ReadLine();
                        // Loop through the logged in depots drivers and if there is no match, driver is not found.
                        for (int a = 0; a < loggedonDepot.getDrivers().Count(); a++)
                        {

                            if (loggedonDepot.getDrivers()[a].getUsername() == driverName)
                            {

                                if (loggedonDepot.getDrivers()[a].isAvailable(newSched) == true)
                                {

                                    loggedonDepot.getDrivers()[a].setSchedule(newSched);
                                    break;

                                }
                                else
                                {
                                    Console.WriteLine("Driver not found");
                                    break;
                                }
                            }
                        }

                        // Same code for the vehicles. When the match is found, set the schedule.
                        string vehicleRegNo = Console.ReadLine();

                        for (int b = 0; b < loggedonDepot.getVehicles().Count(); b++)
                        {
                            if (loggedonDepot.getVehicles()[b].getRegNo() != vehicleRegNo)
                            {
                                Console.WriteLine("Invalid vehicle ID");
                                break;
                            }

                            if (loggedonDepot.getVehicles()[b].getRegNo() == vehicleRegNo)
                            {
                                if (loggedonDepot.getVehicles()[b].isAvailable(newSched) == true)
                                {
                                    loggedonDepot.getVehicles()[b].setSchedule(newSched);
                                }
                            }

                        }
                        break;
               

                    case 3:


                        // Reads in the vehicle to be moved and removes it from the old depot and adds it to the new depot

                        Console.WriteLine("Please enter the vehicles registration number");
                        string tempRegNo = Console.ReadLine();

                        Console.WriteLine("Please enter the depot location of where it is being moved to");
                        string endLocation = Console.ReadLine();

                        workSchedule RightNow = new workSchedule(DateTime.Now, DateTime.MaxValue, endLocation);

                        for (int i = 0; i < loggedonDepot.getVehicles().Count; i++)
                        {
                            if ((loggedonDepot.getVehicles()[i].getRegNo() == tempRegNo) && loggedonDepot.getVehicles()[i].isAvailable(RightNow))
                            {
                                if (endLocation != loggedonDepot.getLocation())
                                {
                                    foreach (Depot depot in depots)
                                    {
                                        if (endLocation == depot.getLocation())
                                        {
                                            depots[i].addVehicle(loggedonDepot.getVehiclefromList(i));
                                            loggedonDepot.getVehicles().RemoveAt(i);

                                        }

                                    }

                                }

                            }

                        }

                        Console.WriteLine("Vehicle moved to", endLocation);
                        break;
               
                    case 4:

                        // Read in the new drivers details and add it to the depots list of drivers.
                        string newUser;
                        string newPass;

                        Console.WriteLine("Enter the new drivers username and password");

                        newUser = Console.ReadLine();
                        newPass = Console.ReadLine();
                        Driver newDriver = new Driver(newUser, newPass);
                        loggedonDepot.addDriver(newDriver);
                        Console.WriteLine("Driver registered");
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
