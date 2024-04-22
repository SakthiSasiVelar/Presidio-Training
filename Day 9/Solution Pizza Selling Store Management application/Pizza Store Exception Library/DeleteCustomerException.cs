using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class DeleteCustomerException : Exception
    {
        string msg = string.Empty;

        public DeleteCustomerException() 
        {
            msg = "Error in deleting customer details , please give the correct customer id and try again";
        }

        public override string Message => msg;
    }
}
