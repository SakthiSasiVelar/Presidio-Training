using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class GetCustomerException : Exception
    {
        string msg = string.Empty;

        public GetCustomerException()
        {
            msg = "error in getting customer details , please enter correct customer id and try again";
        }

        public override string Message => msg;
    }
}
