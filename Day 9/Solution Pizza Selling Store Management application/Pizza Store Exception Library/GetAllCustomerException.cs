using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public  class GetAllCustomerException : Exception
    {
        string msg = String.Empty;

        public GetAllCustomerException() {
            msg = "No customers are there in the list ......";
        }

        public override string Message => msg;
    }
}
