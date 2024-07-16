using System;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            context.Items.Add(new Item { Name = "Test Item" });
            context.SaveChanges();

            foreach (var item in context.Items)
            {
                Console.WriteLine($"Item: {item.Id} - {item.Name}");
            }
        }
    }
}
