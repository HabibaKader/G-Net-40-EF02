using Microsoft.EntityFrameworkCore;

namespace Assignment02_EntityFrameworkCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Database created successfully!");
        }
    }
}
