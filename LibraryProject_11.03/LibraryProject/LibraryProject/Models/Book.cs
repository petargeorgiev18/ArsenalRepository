using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class Book
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int CopiesAvailableCount { get; set; }
        public int BorrowTimesCount { get; set; }
        public Book(string title, string author, string genre, int copiesAvailableCount)
        {
            Title = title;
            Author = author;
            Genre = genre;
            CopiesAvailableCount = copiesAvailableCount;
        }
    }
}
