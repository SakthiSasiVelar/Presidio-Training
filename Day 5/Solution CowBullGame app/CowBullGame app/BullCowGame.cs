namespace CowBullGame_app
{
    internal class BullCowGame
    {
        static string GetWord()
        {
            return Console.ReadLine();
        }

        static int CheckSameCharacterAndPosition(string word , char characterToFind , int indexOfCharacter) {
            for(int i = 0;i < word.Length;i++)
            {
                if (word[i] == characterToFind)
                {
                    if (indexOfCharacter == i) return 1;
                    return 2;
                }
            }
            return 0;
        }

        static void PrintValueOfCowsAndBulls(int cows , int bulls )
        {
            Console.WriteLine($"cows - {cows} , bulls - {bulls}");
        }

        static void PrintCongratsMessage()
        {
            Console.WriteLine("Congrats!!!you won!!!");
        }
        static bool IsWordMatches(string wordToBeFind , string guessWord)
        {
            int cows = 0, bulls = 0;
            for(int i = 0; i < guessWord.Length; i++)
            {
                int result = CheckSameCharacterAndPosition(wordToBeFind, guessWord[i] , i) ;
                if (result == 1) cows++;
                else if (result == 2) bulls++;
            }
            PrintValueOfCowsAndBulls(cows, bulls);
            if(cows == 4)
            {
                PrintCongratsMessage();
                return true;
            }
            return false;
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter four letter word to find :");
            string wordToBeFind = GetWord();
            Console.WriteLine("Start the guess : ");
            string guessWord = GetWord();
            while(!IsWordMatches(wordToBeFind, guessWord))
            {
                guessWord = GetWord();
            }

        }
    }
}
