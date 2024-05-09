namespace AB_Appication_BL_Custom_Exception_Library
{
    public class AddDoctorDetailsException : Exception
    {
        string message = string.Empty;
        public AddDoctorDetailsException() {
            message = "Error in adding doctor details,check the details given by you";
        }

        public override string Message => message;
    }
}
