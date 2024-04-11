namespace Task_5
{
    internal class Program
    {
        //getting input (username , password)
        static void GetUserNamePassword(out string userName, out string password)
        {
            Console.WriteLine("Enter userName : ");
            userName = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            password = Console.ReadLine();
        }

        //check userNmae and password

        static bool CheckUserNamePassword(string userName , string password)
        {
            return userName == "ABC" && password == "123";
           
        }
        //Welcome message

        static void PrintWelcomeMessage(string userName) {
            Console.WriteLine("Welcome , "+userName);
        }

        //Attempts exceed message 

        static void PrintAttemptsExceedMessage()
        {
            Console.WriteLine("Sorry , you exceeded the number of attemps ");
        }
        static void Main(string[] args)
        {
            string userName, password;
            int loginTimes = 0;
            while(loginTimes < 3)
            {
                GetUserNamePassword(out userName, out password);
                if(CheckUserNamePassword(userName, password))
                {
                    PrintWelcomeMessage(userName);
                    return;
                }
                loginTimes++;
              
            }
            PrintAttemptsExceedMessage();
        }

    }
   
}
