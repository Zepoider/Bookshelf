using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Controllers.Models
{
    public class BookAuthorContr
    {
        public Guid BooksId { get; set; }
        public Guid AuthorId { get; set; }
        public short AuthorOrder { get; set; }
    }
}
