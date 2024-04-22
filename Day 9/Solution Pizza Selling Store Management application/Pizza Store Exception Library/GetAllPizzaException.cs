using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class GetAllPizzaException : Exception
    {
        string msg = String.Empty;

        public GetAllPizzaException()
        {
            msg = "Currently no items(pizza) in the menu";
        }

        public override string Message => msg;
    }
}
