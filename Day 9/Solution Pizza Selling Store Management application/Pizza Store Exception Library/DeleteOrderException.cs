using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class DeleteOrderException : Exception
    {
        string msg = string.Empty;

        public DeleteOrderException()
        {
            msg = "Error in deleting order details , please give the correct order id and try again";
        }

        public override string Message => msg;
    }
}
