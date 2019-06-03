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
    public class LineItemService : ILineItemService
    {
        public Task<IEnumerable<LineItemServ>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public LineItemServ GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveCustomerAsync(LineItemServ customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(LineItemServ customer)
        {
            throw new NotImplementedException();
        }
    }
}
