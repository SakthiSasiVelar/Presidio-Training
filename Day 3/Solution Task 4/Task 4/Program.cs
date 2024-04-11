namespace Task_4
{
    internal class Program
    {
        //getting user name
        static string GetUserName()
        {
            return Console.ReadLine();
        }

        //finding length of user name
        static int FindLengthOfUserName(string userName)
        {
            return userName.Length;
        }

        //printing the length of the user name
        static void PrintLengthOfUserName(int userNameLength)
        {
            Console.WriteLine("The length of user's name : "+userNameLength);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name :");
            string name = GetUserName();
            int lengthOfUserName = FindLengthOfUserName(name);
            PrintLengthOfUserName(lengthOfUserName);
            
        }
    }
}
