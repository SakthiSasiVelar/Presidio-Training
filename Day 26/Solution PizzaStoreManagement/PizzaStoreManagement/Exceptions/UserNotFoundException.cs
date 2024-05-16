namespace PizzaStoreManagement.Exceptions
{
    public class UserNotFoundException : Exception
    {
        string message = string.Empty;

        public UserNotFoundException() {
            message = "User is not found,please check the id given";
        }

        public override string Message => message;
    }
}
