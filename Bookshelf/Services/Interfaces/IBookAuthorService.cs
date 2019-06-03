using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Services.Models;

namespace Bookshelf.Services.Interfaces
{
    interface IBookAuthorService
    {
        Task<IEnumerable<BookAuthorServ>> GetAllCustomersAsync();

        BookAuthorServ GetCustomer(Guid id);

        Task<Guid> SaveCustomerAsync(BookAuthorServ customer);

        bool UpdateCustomer(BookAuthorServ customer);

        bool RemoveCustomer(Guid id);
    }
}
