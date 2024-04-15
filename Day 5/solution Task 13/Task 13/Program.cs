namespace Task_13
{
    internal class Program
    {
        static int[] GetArrayInput(int n)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter three digit number");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            return numbers;
        }

        static int getRepeatingThreeDigitNumberCount(int[] numbers , int sizeOfArray)
        {
            int countRepeatingThreeDigitNumber = 0;
            for(int i = 0; i < sizeOfArray; i++)
            {
                string number = numbers[i].ToString();
                char req_digit = number[0];
                int j;
                for (j=0; j < number.Length; j++)
                {
                    if (number[j] != req_digit) break;
                }
                 if(j == number.Length) countRepeatingThreeDigitNumber++;
            }
            return countRepeatingThreeDigitNumber;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of an array");
            int sizeOfAnArray = Convert.ToInt32(Console.ReadLine());
            int[] numbers = GetArrayInput(sizeOfAnArray);
            int countOfRepeatingThreeDigitNumber = getRepeatingThreeDigitNumberCount(numbers , sizeOfAnArray);
            Console.WriteLine("The count of repeating three digit number : " +  countOfRepeatingThreeDigitNumber);

        }
    }
}
