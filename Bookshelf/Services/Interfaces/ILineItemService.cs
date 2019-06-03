using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    interface ILineItemService
    {
        Task<IEnumerable<LineItemServ>> GetAllCustomersAsync();

        LineItemServ GetCustomer(Guid id);

        Task<Guid> SaveCustomerAsync(LineItemServ customer);

        bool UpdateCustomer(LineItemServ customer);

        bool RemoveCustomer(Guid id);
    }
}
