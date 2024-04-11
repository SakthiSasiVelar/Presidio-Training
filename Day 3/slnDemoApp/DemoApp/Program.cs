namespace DemoApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string str1 = "hello";
            string str2 = str1;

            str1 += "world";
            str2  = str1;

            Console.WriteLine(str2.GetHashCode());
            Console.WriteLine(str1.GetHashCode());
          

        }
    }
}
