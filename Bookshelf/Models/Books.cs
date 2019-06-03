using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Books
    {
        public Guid BooksId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string PromotionalText { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal OrgPrice { get; set; }
        public bool SoftDeleted { get; set; }
    }
}
