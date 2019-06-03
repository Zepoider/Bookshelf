using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;
using Bookshelf.Services.Interfaces;
using FluentValidation;
using Bookshelf.Models;

namespace Bookshelf.Services
{
    public class OrdersService : IOrders
    {
        public Task<IEnumerable<OrdersServ>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public OrdersServ GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveCustomerAsync(OrdersServ customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(OrdersServ customer)
        {
            throw new NotImplementedException();
        }
    }
}
