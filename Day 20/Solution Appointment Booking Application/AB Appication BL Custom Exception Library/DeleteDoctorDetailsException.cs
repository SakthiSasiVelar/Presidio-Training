using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public class DeleteDoctorDetailsException : Exception
    {
        string message = string.Empty;
        public DeleteDoctorDetailsException() {
            message = "Error in deleting doctor details , check the given id of doctor is correct";
        }

        public override string Message => message;
    }
}
