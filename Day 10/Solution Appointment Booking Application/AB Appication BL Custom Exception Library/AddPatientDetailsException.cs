using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public  class AddPatientDetailsException : Exception
    {
        string message = string.Empty;
        public AddPatientDetailsException() {
            message = "Error in adding patient details , check the details given by you";
        }

        public override string Message => message;
    }
}
