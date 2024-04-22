namespace Pizza_Store_Exception_Library
{
    public class AddCustomerException  :Exception
    {
        string msg = string.Empty;

        public AddCustomerException()
        {
            msg = "Error in adding customer , please check the given details and try again";
        }

        public override string Message => msg;
    }
}
