using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ReadMoreDbContext();

            
            bool isCreated = context.Database.EnsureCreated();
            Console.WriteLine($"Database Created: {isCreated}");

            
            var author = new Author
            {
                FirstName = "Naguib",
                LastName = "Mahfouz",
                Email = "naguib@readmore.com",
                Biography = "Egyptian writer who won the 1988 Nobel Prize in Literature.",
                DateOfBirth = new DateTime(1911, 12, 11)
            };

            var category = new Category
            {
                Name = "Literature",
                Description = "Classic novels and fiction",
                IsActive = true
            };

            var book = new Book
            {
                Title = "The Cairo Trilogy",
                ISBN = "978-0375713378",
                Price = 250.00m,
                NumberOfPages = 1360,
                PublishedYear = 1956,
                InStock = true,
                Author = author,
                Category = category
            };

            context.Books.Add(book);
            context.SaveChanges();

            var savedBook = context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .First();

            Console.WriteLine("--- Saved Book Details ---");
            Console.WriteLine($"Title: {savedBook.Title} ({savedBook.PublishedYear})");
            Console.WriteLine($"Author: {savedBook.Author.FirstName} {savedBook.Author.LastName}");
            Console.WriteLine($"Category: {savedBook.Category.Name}");
            Console.WriteLine($"Price: {savedBook.Price} | In Stock: {savedBook.InStock}");

            context.Database.EnsureCreated();
            Console.WriteLine("Database and Tables created successfully!");
        }
    }
}
