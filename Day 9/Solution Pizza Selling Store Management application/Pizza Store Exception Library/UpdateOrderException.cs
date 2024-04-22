using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class UpdateOrderException : Exception
    {
        string msg = string.Empty;

        public UpdateOrderException()
        {
            msg = "Error in updating the order details , check the given details and try again";
        }

        public override string Message => msg;
    }
}
