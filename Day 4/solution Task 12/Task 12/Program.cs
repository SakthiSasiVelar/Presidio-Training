using System.Text;

namespace Task_12
{
    internal class Program
    {

        //getting card number

        static long GetCardNumber()
        {
            long cardNumber;
            while (!long.TryParse(Console.ReadLine(), out cardNumber))
            {
                Console.WriteLine("Enter only the number ");
            };
            return cardNumber;
        }

        //checking valid input

        static bool IsValidInput(long cardNumber)
        {
            if(cardNumber < 0) return false;
            if(cardNumber.ToString().Length != 16) return false;
            return true;
        }

        // reverse the card number

        static long ReverseTheCardNumber(long cardNumber)
        {
            long reverseCardNumber = 0;
            while (cardNumber > 0)
            {
               reverseCardNumber = (reverseCardNumber * 10) + (cardNumber % 10);
               cardNumber = cardNumber / 10;
            }
            return reverseCardNumber;
        }


        //checking  number is two digit

        static bool IsNumberAtEvenPositionIsTwoDigit(int number)
        {
            return number > 9;
        }

        // adding the digits
        
        static int AddTheDigit(int number)
        {
            return (number % 10) + (number / 10);
        }

        // multiply by TWO in even positions

        static long MultiplyByTwoInEvenPosition(long cardNumber)
        {
           string stringConversionOfCardNumber = cardNumber.ToString();
           StringBuilder reverseOfCardNumber = new StringBuilder(stringConversionOfCardNumber);
            for (int i = 1; i < reverseOfCardNumber.Length; i=i+2)
            {
                int numberAtEvenPosition = reverseOfCardNumber[i] - '0';
                numberAtEvenPosition = numberAtEvenPosition * 2;
                if(IsNumberAtEvenPositionIsTwoDigit(numberAtEvenPosition))
                {
                    numberAtEvenPosition = AddTheDigit(numberAtEvenPosition);
                }
                reverseOfCardNumber[i] = (char)(numberAtEvenPosition+ '0');    
            }
            return Convert.ToInt64(reverseOfCardNumber.ToString());
        }

        // checking card number divisible by 10 

        static bool IsDivisibleByTen(long cardNumber)
        {

            return cardNumber % 10 == 0;
        }

        //sum all digits 

        static long SumAllDigits(long number)
        {
            long totalSum = 0;
            while (number > 0)
            {
                totalSum +=  number % 10;
                number /= 10;
            }
            Console.WriteLine(totalSum);
            return totalSum;
        }


        //checking valid card number

        static bool IsValidCardNumber(long cardNumber)
        {
           long  reverseCardNumber = ReverseTheCardNumber(cardNumber);
           long cardNumberAfterMultiplyTwo = MultiplyByTwoInEvenPosition(reverseCardNumber);
           long summationOfAllNumbers = SumAllDigits(cardNumberAfterMultiplyTwo);
           if (IsDivisibleByTen(summationOfAllNumbers)) return true;
           return false;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter the card Number : ");
            long cardNumber = GetCardNumber();
            while (!IsValidInput(cardNumber))
            {
                Console.WriteLine("Enter the valid card number");
                cardNumber = GetCardNumber();
            }
            if (IsValidCardNumber(cardNumber)) Console.WriteLine("Given card Number is valid");
            else Console.WriteLine("Given cartd number is not valid");
        }
    }
}
