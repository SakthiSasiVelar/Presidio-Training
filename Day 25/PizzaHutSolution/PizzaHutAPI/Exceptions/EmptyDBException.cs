namespace PizzaHutAPI.Exceptions
{
    public class EmptyDBException : Exception
    {
        string message;

        public EmptyDBException()
        {
            message = "The Database is Empty";
        }
        public EmptyDBException(string database)
        {
            message = $"The Database {database} is Empty";
        }
        public override string Message => message;
    }
}
