using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class UpdateCustomerException : Exception
    {
        string msg = string.Empty;

        public UpdateCustomerException()
        {
            msg = "Error in updating the customer details , check the given details and try again";
        }

        public override string Message => msg;
    }
}
