using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public  class UpdateDoctorDeatilsException : Exception
    {
        string message = string.Empty;
        public UpdateDoctorDeatilsException() {
            message = "Error in updating the doctor details , please check the given details and try again";
        }

        public override string Message => message;
    }
}
