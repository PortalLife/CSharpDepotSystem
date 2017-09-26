    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class Vehicle
    {

        protected string make;
        protected string model;
        protected int weight;
        protected string regNo;
        protected List<workSchedule> workSch;


       public string getRegNo()
        {

            return regNo;
        }

      
        public bool isAvailable(workSchedule newSched)
        {
            if (workSch == null)
            {
                return true;
            }
          
            int numberOfLoops = workSch.Count;
            int externalCounter = 0;


            for (int i = 0; i < numberOfLoops; i++)
            {

                int result1 = DateTime.Compare(DateTime.Now, newSched.getStartDate());
                int result2 = DateTime.Compare(newSched.getStartDate(), workSch[i].getEndDate());
                int result3 = DateTime.Compare(newSched.getEndDate(), workSch[i].getStartDate());

                if (result1 > 0)
                {
                    Console.WriteLine("The starting time for the job has passed.");
                    break;
                }
                //the only way clashes DONT happen(inverted logic makes this bit a lot easier)
                else if (result2 > 0 || result3 < 0)
                {
                    externalCounter++;
                }
                else
                {
                    Console.WriteLine("Vehicle Unavailable");
                    break;

                }
            }

            if (externalCounter == numberOfLoops)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Constructs a vehicle and initialises its list
        public Vehicle(string nMake, string nModel, string nRegNo, int nWeight)
        {
            this.make = nMake;
            this.model = nModel;
            this.regNo = nRegNo;
            this.weight = nWeight;
            this.workSch = new List<workSchedule>();

        }
        public Vehicle()
        {

        }
        public void setSchedule(workSchedule newSchedule)
        {
            this.workSch.Add(newSchedule);
        }

    }
}