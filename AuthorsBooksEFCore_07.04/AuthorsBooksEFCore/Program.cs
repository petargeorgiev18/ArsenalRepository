using AuthorsBooksEFCore.Data;
using AuthorsBooksEFCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorsBooksEFCore
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using LibraryDbContext libraryDbContext = new LibraryDbContext();
            //await libraryDbContext.Database.EnsureDeletedAsync();
            //await libraryDbContext.Database.EnsureCreatedAsync();
            //Console.WriteLine(await ImportAuthorData(libraryDbContext));
            //Console.WriteLine(await ImportBookData(libraryDbContext));
            await AllBooksWithPriceBetween20And25(libraryDbContext);
            Console.WriteLine("-------------------------------");
            await AllBooksWithTitleShorterThan10Symbols(libraryDbContext);
            Console.WriteLine("-------------------------------");
            await AllBulgarianAuthors(libraryDbContext);
            Console.WriteLine("-------------------------------");
            await AllBooksByPublisher(libraryDbContext);
            Console.WriteLine("-------------------------------");
            await AllAuthorsByNationality(libraryDbContext);
            Console.WriteLine("-------------------------------");
            await AllBooksByAuthorFamily(libraryDbContext);
        }
        public static async Task<string> ImportAuthorData(LibraryDbContext context)
        {
            var authors = new List<Author>();
            while (true)
            {
                if (authors.Count() == 5)
                {
                    break;
                }
                string command = Console.ReadLine();
                string[] authorData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Author author = new Author()
                {
                    First_Name = authorData[0],
                    Last_Name = authorData[1],
                    Nationality = authorData[2]
                };
                authors.Add(author);
            }
            await context.Authors.AddRangeAsync(authors);
            await context.SaveChangesAsync();
            return $"Successfully imported {context.Authors.Count()} authors!";
        }
        public static async Task<string> ImportBookData(LibraryDbContext context)
        {
            var books = new List<Book>();
            while (true)
            {
                if (books.Count() == 5)
                {
                    break;
                }
                string command = Console.ReadLine();
                string[] bookData = command.Split("; ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Author author = context.Authors.FirstOrDefault(a => a.ID == int.Parse(bookData[1]))!;
                Book book = new Book()
                {
                    Title = bookData[0],
                    AutorId = int.Parse(bookData[1]),
                    Author = author,
                    Publisher = bookData[2],
                    Price = decimal.Parse(bookData[3])
                };
                author.Books.Add(book);
                books.Add(book);
            }
            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
            return $"Successfully imported {context.Books.Count()} books!";
        }
        public static async Task AllBooksWithPriceBetween20And25(LibraryDbContext context)
        {
            var books = await context.Books
                .Where(b => b.Price >= 20 && b.Price <= 25)
                .Select(b => new
                {
                    b.Title,
                })
                .ToListAsync();
            Console.WriteLine("Books with price between 20 and 25:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }
        public static async Task AllBooksWithTitleShorterThan10Symbols(LibraryDbContext context)
        {
            var books = await context.Books
                .Where(b => b.Title.Length < 10)
                .Select(b => new
                {
                    b.Title,
                })
                .ToListAsync();
            Console.WriteLine("Books with title shorter than 10 symbols:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }
        public static async Task AllBulgarianAuthors(LibraryDbContext context)
        {
            var authors = await context.Authors
                .Where(a => a.Nationality=="Bulgarian")
                .Select(a => new
                {
                    a.First_Name,
                    a.Last_Name
                })
                .ToListAsync();
            Console.WriteLine("Bulgarian authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.First_Name} {author.Last_Name}");
            }
        }
        public static async Task AllBooksByPublisher(LibraryDbContext context)
        {
            Console.Write("Enter publisher: ");
            string publisher = Console.ReadLine();
            var books = await context.Books
                .Where(b => b.Publisher == publisher)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToListAsync();
            Console.WriteLine($"Books by {publisher}:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }
        public static async Task AllAuthorsByNationality(LibraryDbContext context)
        {
            Console.Write("Enter author nationality: ");
            string authorNationality = Console.ReadLine();
            var authors = await context.Authors
                .Where(a => a.Nationality == authorNationality)
                .Select(a => new
                {
                    a.First_Name,
                    a.Last_Name
                })
                .ToListAsync();
            Console.WriteLine($"Books by {authorNationality} authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.First_Name} {author.Last_Name}");
            }
        }
        public static async Task AllBooksByAuthorFamily(LibraryDbContext context)
        {
            Console.Write("Enter author family: ");
            string authorFamily = Console.ReadLine();
            var books = await context.Books
                .Where(b => b.Author.Last_Name == authorFamily)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToListAsync();
            Console.WriteLine($"Books by {authorFamily}:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }
    }
}
