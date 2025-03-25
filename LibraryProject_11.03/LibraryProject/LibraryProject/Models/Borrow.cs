using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class Borrow
    {
        public Reader Reader { get; set; } = null!;
        public Book Book { get; set; } = null!;
        public DateTime BorrowingDate { get; set; }
        public DateTime? ReturningDate { get; set; }
        public Borrow(Reader reader, Book book,DateTime borrowingDate, DateTime returningDate)
        {
            Reader = reader;
            Book = book;
            BorrowingDate = borrowingDate;
            ReturningDate = returningDate;
        }
        public Borrow(Reader reader, Book book,DateTime borrowingDate) 
        {
            Reader = reader;
            Book = book;
            BorrowingDate = borrowingDate;
        }
    }
}
