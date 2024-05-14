using System.Runtime.Serialization;

namespace ClinicManagementApp.Exceptions
{
    
    public class DoctorNotFoundException : Exception
    {
        string msg = String.Empty;
        public DoctorNotFoundException()
        {
            msg = "Doctor details not found";
        }

        public override string Message => msg;


    }
}