using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public class GetAllPatientExceptioncs : Exception
    {
        string msg= string.Empty;
        public GetAllPatientExceptioncs() {
            msg = "Error in fetching all patients list , please try again";
        }

        public override string Message => msg;
    }
}
