namespace Task_1
{
    internal class Program
    {
        //getting Input from user
        static void GetInput(out double number)
        {
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Please , Enter the number");
            }
        }

        //Adding two numbers
        static double Add(double firstNumber , double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        //multiplying two numbers
        static double Product(double firstNumber , double secondNumber)
        {
            return firstNumber * secondNumber; 
        }

        //Dividing two numbers 
        static double Divide(double firstNumber , double secondNumber)
        {
            return firstNumber / secondNumber;
           
        }

        //Subtracting two numbers (second - first)
        static double Subtract(double firstNumber , double secondNumber)
        {
            return secondNumber - firstNumber;
        }

        //Remainder of two numbers
        static double Remainder(double firstNumber , double secondNumber)
        {
            return firstNumber % secondNumber;   
        }
       
         // printing result for arithmetic operation
         static void PrintResult(double resultForAddition , double resultForMultiplication , double resultForSubtraction)
        {
            Console.WriteLine($" Addition : {resultForAddition}\n Multiplication : {resultForMultiplication}\n Subtraction : {resultForSubtraction}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first Number : ");
            double firstNumber;
            GetInput(out firstNumber);
            Console.WriteLine("Enter the second Number : ");
            double secondNumber;
            GetInput(out secondNumber);
            double resultForAddition = Add(firstNumber, secondNumber);
            double resultForMultiplication = Product(firstNumber, secondNumber);
            double resultForSubtraction = Subtract(firstNumber, secondNumber);
            Console.WriteLine("--------Results--------");
            PrintResult(resultForAddition , resultForMultiplication, resultForSubtraction);
            if (secondNumber == 0)
            {
                Console.WriteLine("Since second number is zero , we cannot Divide and find Remainder");
            }
            else
            {
                double resultForDivison = Divide(firstNumber, secondNumber);
                double resultForRemainder = Remainder(firstNumber, secondNumber);
                Console.WriteLine($" Division : {resultForDivison}\n Remainder : {resultForRemainder}");
            }
        }
    }
}
