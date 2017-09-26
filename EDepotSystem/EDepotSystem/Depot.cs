using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class Depot
    {

        private List<Vehicle> vehicleList;
        private List<Driver> driverList;
        private string location;

        public Depot()
        {

            this.vehicleList = new List<Vehicle>();
            this.driverList = new List<Driver>();
            this.location = "";
        }
        public void logOn(System system, Depot depot)
        {

            //hard coded objects to test solution with
            driverList.Add(new Manager("Alex123", "123"));
            driverList.Add(new Driver("Dean456", "456"));
            driverList.Add(new Driver("Scott789", "789"));

            vehicleList.Add(new Vehicle("BenQ", "Sports", "101", 10));

            string tempPassword = "";
            string tempUsername = "";

            //if we want to deal with bad names
            //if (tempUsername == "") return badUser; 
            Console.WriteLine("Enter your username");
            tempUsername = Console.ReadLine();


            //if we want to deal with bad passwords
            //if (tempPassword == "") return badPass;
            Console.WriteLine("Enter your password");
            tempPassword = Console.ReadLine();

            for (int i = 0; i < 2; i++)
            {
                // If the username and password match and its the right depot, else exit the program (error check)
                if (driverList[i].checkUsername(tempUsername) && driverList[i].checkPassword(tempPassword) && system.getDepots()[i].getLocation() == depot.getLocation())
                {
                    system.mainMenu(driverList[i], system.getDepots()[i]);
                    break;
                }

                    else if (driverList[i].checkUsername(tempUsername) || driverList[i].checkPassword(tempPassword) == false)
                    {

                        Console.WriteLine("Invalid user name or password");
                        Environment.Exit(1);
                    }
                }
            }

        

        // Get set methods
        public List<Vehicle> getVehicles()
        {
            return vehicleList;
        }

        public List<Driver> getDrivers()
        {
            return driverList;
        }

        public Vehicle getVehiclefromList (int index)
       {
           return vehicleList[index];
       }
      
        public string getLocation()
        {
            return location;
        }


        public void setLocation(string nLocation)
        {
            this.location = nLocation;
        }

        // Utilty methods for changing the list
        public void addDriver(Driver nDriver)
        {
            this.driverList.Add(nDriver);
        }

        public void removeDriver(Driver nDriver)
        {
            this.driverList.Remove(nDriver);
        }

        public void addVehicle(Vehicle nVehicle)
        {

            this.vehicleList.Add(nVehicle);

        }

        public void removeVehicle(string id)
        {

            for (int i = 0; i < vehicleList.Count(); i++)
            {

                if (vehicleList[i].getRegNo() == id)
                {
                    vehicleList.RemoveAt(i);
                    break;
                }
            }
        }


        
        // This function hasn't been used very much - found not required
        public void setupWorkSchedule(ref workSchedule newSched, DateTime start, DateTime end, string cilent)
        {
            newSched = new workSchedule(start, end, cilent);
        }

    }

}
