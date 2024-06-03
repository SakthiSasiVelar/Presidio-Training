using LearnLINQApp.Model;

namespace LearnLINQApp
{
    internal class Program
    {
        void PrintTitle()
        {
            pubsContext context = new pubsContext();
            var sales = context.Titles
                           .GroupBy(t => t.TitleId, t => t.Pub, (titleid , pub) => new { Key = titleid, Quantity = pub.ToList() });
        }
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            program.PrintNumberOfBooksFromType("mod_cook");
        }
    }
}
