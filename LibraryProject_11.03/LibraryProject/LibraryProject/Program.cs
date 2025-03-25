using LibraryProject.Models;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace LibraryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Reader> readers = new List<Reader>();
            List<Borrow> borrows = new List<Borrow>();
            Console.WriteLine("Choose one of the comands below:");
            Console.WriteLine("1. Entering information about books and readers");
            Console.WriteLine("2. Borrowing book/s");
            Console.WriteLine("3. Outputing information from queries");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=======================================");
            int command = int.Parse(Console.ReadLine());
            while (true)
            {
                switch (command)
                {
                    case 1:
                        Console.Write("What do you wanna enter information for? (book/reader): ");
                        string input = Console.ReadLine()!;
                        if (input == "book")
                        {
                            Console.Write("Enter the quantity books we are going to add: ");
                            int countBooks = int.Parse(Console.ReadLine());
                            for (int i = 0; i < countBooks; i++)
                            {
                                Console.WriteLine("Enter the information about book splitted by comma " +
                                    "and interval(', ')");
                                string[] bookInfo = Console.ReadLine()!.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                                string title = bookInfo[0];
                                string author = bookInfo[1];
                                string genre = bookInfo[2];
                                int copiesAvailableCount = int.Parse(bookInfo[3]);
                                Book book = new Book(title!, author!, genre!, copiesAvailableCount);
                                books.Add(book);
                                Console.WriteLine("Book added successfully!");
                            }
                        }
                        if (input == "reader")
                        {
                            Console.Write("Enter the quantity of readers we are going to add: ");
                            int countReaders = int.Parse(Console.ReadLine());
                            for (int i = 0; i < countReaders; i++)
                            {
                                Console.WriteLine("Enter the information about reader splitted by comma and " +
                                    "interval(', ')");
                                string[] readerInfo = Console.ReadLine()!.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                                string name = readerInfo[0];
                                int id = int.Parse(readerInfo[1]);
                                int age = int.Parse(readerInfo[2]);
                                Reader reader = new Reader(name, id, age);
                                Console.WriteLine("Enter info about the reader's book/s (when you've entered the books type " +
                                    "'that's it'):");
                                string inputBooks = Console.ReadLine()!;
                                while (true)
                                {
                                    if (inputBooks == "that's it")
                                    {
                                        break;
                                    }
                                    string[] booksInfo = inputBooks!.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                                    string title = booksInfo[0];
                                    Book book = books.FirstOrDefault(b => b.Title == title);
                                    if (book is null)
                                    {
                                        Console.WriteLine("The book doesn't exist, we can't add it.");
                                        break;
                                    }
                                    if (book.CopiesAvailableCount <= 0)
                                    {
                                        Console.WriteLine("This book doesn't have copies in our library, we're sorry. " +
                                            "Try to check the next week!");
                                        break;
                                    }
                                    book.CopiesAvailableCount--;
                                    book.BorrowTimesCount++;
                                    reader.BorrowedBooks.Add(book);
                                    Borrow borrow = new Borrow(reader, book, DateTime.Now);
                                    borrows.Add(borrow);
                                    Console.WriteLine($"{book.Title} borrowed successfully!");
                                }
                                readers.Add(reader);
                                Console.WriteLine("Reader added successfully!");
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Enter the count of readers borrowing books: ");
                        int countBorrowers = int.Parse(Console.ReadLine());
                        for (int i = 0; i < countBorrowers; i++)
                        {
                            Console.Write("Enter info for readers:");
                            string[] borrowerInfo = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                            string borrowerName = borrowerInfo[0];
                            int borrowerId = int.Parse(borrowerInfo[1]);
                            int borrowerAge = int.Parse(borrowerInfo[2]);
                            Reader borrower = readers.FirstOrDefault(r => r.Name == borrowerName
                                && r.Id == borrowerId && r.Age == borrowerAge)!;
                            if (borrower is null)
                            {
                                Console.WriteLine("Reader not found.");
                                continue;
                            }
                            Console.Write("Enter the number of books you want to borrow: ");
                            int borrowCount = int.Parse(Console.ReadLine());
                            for (int j = 0; j < borrowCount; j++)
                            {
                                Console.Write("Enter info for readers:");
                                string[] bookInfo = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                                string title = bookInfo[0];
                                string author = bookInfo[1];
                                string genre = bookInfo[2];
                                int copiesAvailableCount = int.Parse(bookInfo[3]);
                                Book bookToBorrow = books.FirstOrDefault(b => b.Title == title);
                                if (bookToBorrow is null)
                                {
                                    Console.WriteLine("Book not found.");
                                    continue;
                                }
                                if (bookToBorrow.CopiesAvailableCount > 0)
                                {
                                    bookToBorrow.CopiesAvailableCount--;
                                    borrower.BorrowedBooks.Add(bookToBorrow);
                                    Borrow borrow = new Borrow(borrower, bookToBorrow, DateTime.Now);
                                    borrows.Add(borrow);
                                    Console.WriteLine($"{bookToBorrow.Title} borrowed successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("No available copies.");
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the number of query you want to execute " +
                                "(if you want to stop executing type 'end')");
                        Console.WriteLine("1. Get every book ");
                        Console.WriteLine("2. Get every reader");
                        Console.WriteLine("3. Get books with readers");
                        Console.WriteLine("4. Get readers with active borrows");
                        Console.WriteLine("5. Get the available books");
                        Console.WriteLine("6. Get late returnings");
                        Console.WriteLine("7. Get top 3 of the most borrowed books");
                        string queryToExecute = Console.ReadLine();
                        while (true)
                        {
                            if (queryToExecute == "end")
                            {
                                break;
                            }
                            int queryNum = int.Parse(queryToExecute);
                            switch (queryNum)
                            {
                                case 1:
                                    Console.WriteLine("Books info:");
                                    foreach (var book in books)
                                    {
                                        Console.WriteLine($"{book.Title} {book.Author} {book.Genre}" +
                                            $" {book.CopiesAvailableCount} {book.BorrowTimesCount}");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Readers info:");
                                    foreach (var reader in readers)
                                    {
                                        Console.WriteLine($"{reader.Name} {reader.Id} {reader.Age} " +
                                            $"({string.Join(" ", reader.BorrowedBooks)})");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Books, borrowed by readers:");
                                    foreach (var reader in readers.Where(r => r.BorrowedBooks != null))
                                    {
                                        foreach (var book in reader.BorrowedBooks)
                                        {
                                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}" +
                                                $" - Borrower: {reader.Name} {reader.Id} {reader.Age}");
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Books, borrowed by readers:");
                                    foreach (var reader in readers.Where(r => r.BorrowedBooks.Count() > 0))
                                    {
                                        Console.WriteLine($"Borrower: {reader.Name} {reader.Id} {reader.Age} - {reader.BorrowedBooks.Count()} " +
                                            $"active borrows");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("The available books:");
                                    foreach (var book in books.Where(b => b.CopiesAvailableCount > 0))
                                    {
                                        Console.WriteLine($"{book.Title} {book.Author} {book.Genre}" +
                                            $" {book.CopiesAvailableCount} {book.BorrowTimesCount}");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("Late returnings:");
                                    foreach (var borrow in borrows.Where(br => br.ReturningDate!.Value >
                                        br.ReturningDate.Value.AddDays(30)))
                                    {
                                        Console.WriteLine($"Reader: {borrow.Reader.Name} (ID: {borrow.Reader.Id}) - Book: {borrow.Book.Title} (Due: {borrow.ReturningDate:dd-MM-yyyy})");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine("Top 3 most borrowed books:");
                                    foreach (var book in books.OrderByDescending(b => b.BorrowTimesCount).Take(3))
                                    {
                                        Console.WriteLine($"{book.Title} {book.Author} {book.Genre}" +
                                            $" {book.CopiesAvailableCount} {book.BorrowTimesCount}");
                                    }
                                    break;
                            }
                            queryToExecute = Console.ReadLine();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you for participating in our program! Goodbye!");
                        return;
                }
                command = int.Parse(Console.ReadLine());
            }
        }
    }
}