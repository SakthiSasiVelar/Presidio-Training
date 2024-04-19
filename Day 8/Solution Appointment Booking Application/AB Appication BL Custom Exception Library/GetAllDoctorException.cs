using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public class GetAllDoctorException : Exception
    {
        string message  = string.Empty;
        public GetAllDoctorException() {
            message = "Error in fetching all doctors list , please try again";
        }

        public override string Message => message;
    }
}
