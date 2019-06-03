using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Orders
    {
        public Guid OrdersId { get; set; }
        public DateTime DateOrderedUtc { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string CustomerName { get; set; }
    }
}
