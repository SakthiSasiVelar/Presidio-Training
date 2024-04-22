using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public  class UpdatePizzaException : Exception
    {
        string msg = string.Empty;

        public UpdatePizzaException() {
            msg = "Error in updating the pizza details , check the given details and try again";
        }

        public override string Message => msg;
    }
}
