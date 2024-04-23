using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Appication_BL_Custom_Exception_Library
{
    public class GetDoctorException : Exception
    {
        string message = string.Empty;
        public GetDoctorException() {
            message = "error in getting doctor details , please check the given id";
        }

        public override string Message => message;
    }
}
