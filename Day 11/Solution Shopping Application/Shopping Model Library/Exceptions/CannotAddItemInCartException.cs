using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Model_Library.Exceptions
{
    public class CannotAddItemInCartException : Exception
    {
        string message;
        public CannotAddItemInCartException()
        {
            message = "Already 5 quantity of current item is added in the cart , so you cannot add anymore current item in this cart";
        }

        public override string Message => message;
    }
}
