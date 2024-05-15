namespace PizzaHutAPI.Exceptions
{
    public class AlreadyUpToDateException : Exception
    {
        string message;
        public AlreadyUpToDateException()
        {
            message = "The Database is Already Up to Date";
        }
        public AlreadyUpToDateException(int id)
        {
            message = $"The Pizza with ID {id} is Already Up to Date";
        }
        public override string Message => message;
    }
}
