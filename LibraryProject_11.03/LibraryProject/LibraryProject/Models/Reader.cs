using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class Reader
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public int Age { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public Reader(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
            BorrowedBooks = new List<Book>();
        }
    }
}
