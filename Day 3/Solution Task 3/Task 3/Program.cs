namespace Task_3
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

        //printing average of the number divisible by 7
        static void PrintAverage(double average)
        {
            Console.WriteLine("The average of numbers divisible by 7 : " + average);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            double sum = 0.0;
            double count = 0;
            double input = GetInput();
            while (input > 0)     // getting input until the given number is negative
            {
                if (input % 7 == 0)
                {
                    sum += input;
                    count++;
                }
                input = GetInput();
            }

            if(count > 0)
            {
                PrintAverage(sum / count);
            }
            else
            {
                Console.WriteLine("No number you given are divisible by 7");
            }
        }
    }
}
