using System.Security;

namespace Task_7
{
    internal class Program
    {
        //getting input
        static string GetInput()
        {
            Console.WriteLine("Enter a string separated by commas");
            return Console.ReadLine();
        }

        //check char is vowel or not

        static bool IsVowel(char letter)
        {
            return letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u';
        }

        //repeating vowel count
        static int GetRepeatingVowelsCount(string word)
        {
            int maxVowelCount = 0;
            int curVowelCount = 0;
            for(int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i])) {
                    curVowelCount++;
                }
                else
                {
                    curVowelCount = 0;
                }
                maxVowelCount = Math.Max(maxVowelCount, curVowelCount);
            }
            return maxVowelCount;
        }
        //set word with least vowel count

        static string SetWordWithLeastVowelcount(int leastVowelsCount, int currentCount, string currentWord , string wordWithLeastVowelCount)
        {
            if (leastVowelsCount == currentCount && wordWithLeastVowelCount != "")
            {
                wordWithLeastVowelCount = wordWithLeastVowelCount + ',' + currentWord;
            }
            else
            {
                wordWithLeastVowelCount = currentWord;
            }
            return wordWithLeastVowelCount;
        }
        static void Main(string[] args)
        {
            string words = GetInput();
            string currentWord = "";
            string wordWithLeastVowelCount="";
            int leastVowelsCount = words.Length;
            for(int i=0;i<words.Length;i++)
            {
                if (words[i] != ',') currentWord += words[i];
                if (words[i] == ',' || i == words.Length - 1)
                {
                    int currentCount = GetRepeatingVowelsCount(currentWord);
                    if(leastVowelsCount >= currentCount)
                    {
                     
                        wordWithLeastVowelCount = SetWordWithLeastVowelcount(leastVowelsCount , currentCount, currentWord , wordWithLeastVowelCount);
                        leastVowelsCount = currentCount;
                    }
                    currentWord = "";
                }
            }
            Console.WriteLine($" Word with least repeating vowel : {wordWithLeastVowelCount}\n count : {leastVowelsCount}");
        }
    }
}
