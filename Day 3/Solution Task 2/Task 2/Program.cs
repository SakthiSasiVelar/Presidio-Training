using System.Xml.Linq;

namespace Task_2
{
    internal class Program
    {
        //getting input
        static double GetInput()
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input))   // validating given input is a number
            {
                Console.WriteLine("Enter a number");
            }
            return input;
        }

        //printing maximum Number
        static void PrintMaximumNumber(double maxNumber)
        {
            Console.WriteLine("The greatest of the given numbers : " + maxNumber);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            double maxElement = double.MinValue;
            double input = GetInput();
            while(input > 0)     // getting input until the given number is negative
            {
               if(input > maxElement)
                {
                    maxElement = input;
                }
               input = GetInput();
            }
            
            PrintMaximumNumber(input > maxElement ? input : maxElement);
        }
    }
}
