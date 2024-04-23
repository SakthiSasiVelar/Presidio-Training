using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public  class DeletePatientDeatilsException : Exception
    {
        string message = string.Empty;
        public DeletePatientDeatilsException()
        {
            message = "Error in deleting patient details , check the given id of patient is correct";
        }

        public override string Message => message;
    }
}
