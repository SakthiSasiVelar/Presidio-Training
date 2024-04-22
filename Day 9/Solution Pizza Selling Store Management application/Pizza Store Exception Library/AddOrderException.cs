using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class AddOrderException : Exception
    {
        string msg = string.Empty;

        public AddOrderException()
        {
            msg = "Error in adding order , please check the given details and try again";
        }

        public override string Message => msg;
    }
}
