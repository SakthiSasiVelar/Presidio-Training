using System.Runtime.Serialization;

namespace PizzaHutAPI.Exceptions
{
    public class NoPizzaInThisID : Exception
    {
        string message;

        public NoPizzaInThisID()
        {
            message = "No Pizza in this ID";
        }

        public NoPizzaInThisID(int key)
        {
            message = $"No Pizza in this ID: {key}";
        }
        public override string Message => message;
    }
}