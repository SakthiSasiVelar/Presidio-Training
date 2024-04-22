using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class GetOrderException : Exception
    {
        string msg = string.Empty;

        public GetOrderException()
        {
            msg = "error in getting order details , please enter correct order id and try again";
        }

        public override string Message => msg;
    }
}
