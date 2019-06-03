using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Controllers.Models
{
    public class ReviewContr
    {
        public Guid ReviewId { get; set; }
        public Guid BooksId { get; set; }
        public string VoterName { get; set; }
        public string Comment { get; set; }
        public short StarNum { get; set; }
    }
}
