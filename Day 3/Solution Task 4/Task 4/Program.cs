namespace Task_4
{
    internal class Program
    {
        //getting user name
        static string getUserName()
        {
            return Console.ReadLine();
        }

        //finding length of user name
        static int findLengthOfUserName(string userName)
        {
            return userName.Length;
        }

        //printing the length of the user name
        static void printLengthOfUserName(int userNameLength)
        {
            Console.WriteLine("The length of user's name : "+userNameLength);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name :");
            string name = getUserName();
            int lengthOfUserName = findLengthOfUserName(name);
            printLengthOfUserName(lengthOfUserName);
            
        }
    }
}
