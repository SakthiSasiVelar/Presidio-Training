using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public  class DeleteAppointmentDetailsException : Exception
    {
        string message = string.Empty;
        public DeleteAppointmentDetailsException() { 
            message = "Error in deleting apppointment details , check the given id of appointment is correct";
        }

        public override string Message => message;
    }
}
