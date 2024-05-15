using System.Runtime.Serialization;

namespace PizzaHutAPI.Exceptions
{
    [Serializable]
    internal class UnableToDoneActionException : Exception
    {
        string message;
        public UnableToDoneActionException()
        {
            message = "Unable to Done the Action";
        }

        public UnableToDoneActionException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}