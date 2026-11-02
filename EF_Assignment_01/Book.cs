using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_01
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishedYear { get; set; }
        public bool InStock { get; set; }

       
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

       
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
