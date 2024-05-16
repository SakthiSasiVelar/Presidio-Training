namespace PizzaStoreManagement.Exceptions
{
    public class CustomerNotFoundException  : Exception
    {
        string message = string.Empty;
        public CustomerNotFoundException() {
            message = "Customer not found , please check the id";
        }

        public override string Message => message;
    }
}
