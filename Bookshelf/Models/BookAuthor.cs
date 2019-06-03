using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class BookAuthor
    {
        public Guid BooksId { get; set; }
        public Guid AuthorId { get; set; }
        public short AuthorOrder { get; set; }
    }
}
