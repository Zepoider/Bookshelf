using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    interface IOrders
    {
        Task<IEnumerable<OrdersServ>> GetAllCustomersAsync();

        OrdersServ GetCustomer(Guid id);

        Task<Guid> SaveCustomerAsync(OrdersServ customer);

        bool UpdateCustomer(OrdersServ customer);

        bool RemoveCustomer(Guid id);
    }
}
