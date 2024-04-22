using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class GetAllOrderException : Exception
    {
        string msg = String.Empty;

        public GetAllOrderException()
        {
            msg = "Currently no orders are done to show......";
        }

        public override string Message => msg;
    }
}
