using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class workSchedule
    {

        private string cilent;
        private DateTime startDate;
        private DateTime endDate;

        public void setCilent(string nCilent) 
        {
            cilent = nCilent;
        }

        public void setStartDate(DateTime nStartDate)
        {

            startDate = nStartDate;
        }

        public void setEndDate(DateTime nEndDate)
        {

            endDate = nEndDate;
        }

        public DateTime getStartDate()
        {

            return startDate;
        }

        public DateTime getEndDate()
        {
            return endDate;
        }

        public string getCilent()
        {
            return cilent;
        }

        public workSchedule(DateTime start, DateTime end, string aCilent)
        {
            setStartDate(start);
            setEndDate(end);
            setCilent(aCilent);

        }
    }
}
