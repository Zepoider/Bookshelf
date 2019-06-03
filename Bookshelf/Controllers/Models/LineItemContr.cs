using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Controllers.Models
{
    public class LineItemContr
    {
        public Guid LineItemId { get; set; }
        public Guid BooksId { get; set; }
        public Guid OrdersId { get; set; }
        public Guid LineNum { get; set; }
        public string BookNum { get; set; }
        public decimal BookPrice { get; set; }
    }
}
