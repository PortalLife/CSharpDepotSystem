using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class Driver
    {
        //constructor to allow hard coded drivers for test purposes
        public Driver(string userNameIn, string passWordIn)
        {

            userName = userNameIn;
            passWord = passWordIn;
            this.workSch = new List<workSchedule>();

        }
        protected string userName;
        protected string passWord;
        protected List<workSchedule> workSch;

        public bool checkPassword(string userPassword)
        {

            if (userPassword == passWord)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public bool checkUsername(string userNameIn)
        {

            if (userNameIn == userName)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public string getUsername()
        {
            return userName;
        }

        public List<workSchedule> getSchedule()
        {
            return workSch;
        }

        public bool isAvailable(workSchedule newSched)
        {

            if (workSch.Count == 0)
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
                    Console.WriteLine("Driver Unavailable");
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

        public void setSchedule(workSchedule newSchedule)
        {

            workSch.Add(newSchedule);

        }
    }

}
