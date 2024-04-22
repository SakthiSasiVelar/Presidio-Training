using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Exception_Library
{
    public class DeletePizzaException : Exception
    {
        string msg = string.Empty;

        public DeletePizzaException()
        {
            msg = "Error in deleting pizza details , please give the correct pizza id and try again";
        }

        public override string Message => msg;
    }
}
