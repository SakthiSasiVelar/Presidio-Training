namespace PizzaStoreManagement.Exceptions
{
    public class PizzaNotFoundException : Exception
    {
        string message = string.Empty;

        public PizzaNotFoundException() {
            message = "pizza is not found , please check the id ";
        }

        public override string Message => message;
    }
}
