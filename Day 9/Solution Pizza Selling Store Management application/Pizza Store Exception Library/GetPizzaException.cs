using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class GetPizzaException : Exception
    {
        string msg = string.Empty;
        public GetPizzaException() {
            msg = "error in getting pizza details , please enter correct pizza id and try again";
        }

        public override string Message => msg;
    }
}
