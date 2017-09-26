using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDepotSystem
{
    class Manager : Driver
    {
        //constructor to allow testing of the manager class, using the driver constructor as a base
        public Manager(string userNameIn, string passWordIn)
            : base(userNameIn, passWordIn)
        {

            userName = userNameIn;
            passWord = passWordIn;
        }
    }
}
