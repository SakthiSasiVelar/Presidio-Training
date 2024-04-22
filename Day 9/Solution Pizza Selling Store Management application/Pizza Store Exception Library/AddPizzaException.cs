using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class AddPizzaException : Exception
    {
        string msg = string.Empty;

        public AddPizzaException()
        {
            msg = "Error in adding pizza , please check the given details and try again";
        }

        public override string Message => msg;
    }
}
