namespace PizzaHutAPI.Models
{
    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorMessage(int code,string message)
        {
            Message = message;
            Code = code;
            Console.Error.WriteLine($"Status Code: {code} Error: {message} ");
        }
    }
}
